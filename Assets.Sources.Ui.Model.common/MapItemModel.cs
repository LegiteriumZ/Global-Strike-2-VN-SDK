using System.Collections.Generic;
using Assets.Sources.Components.Rader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class MapItemModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private MapItemViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	public IMiniMapData MapData;

	public bool IsInRadar;

	public int Index;

	private readonly NotifyGroup _notifyGroup = new NotifyGroup();

	private AssetInfo _currImage;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MapItemViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		if (IsInRadar)
		{
			_viewModel.HpShow = false;
		}
		_viewModel.ViewGameObject.transform.SetParent(MapData.Container.transform);
		_viewModel.ViewGameObject.transform.localEulerAngles = Vector3.zero;
		base.DoSubscribe();
		_viewModel.MapItemShow = false;
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(GetName, SetName, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetPosition, SetPositon, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetHp, SetHp, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetSmallMapImage, SetSmallMapImage, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetTacticsSoundTime, SetTacticsSoundTime, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetAlpha, SetAlpha, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetRotation, SetRotation, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetImageSize, SetImageSize, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetImageScale, SetImageScale, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetHideNameAndHp, SetHideNameAndHp, null, initinvoke: true, isFrameSeparation: true));
		int id = NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		if (MapData.NotifyGroup != null)
		{
			MapData.NotifyGroup.Add(id);
		}
	}

	private void SetVisible(bool oldfs, bool newfs)
	{
		_viewModel.MapItemShow = newfs;
		_notifyGroup.SetSuspend(!newfs);
	}

	private bool GetVisible()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			if (_gameRuleContext.currentRule.Rule.IsHideRadarDeadImage())
			{
				return item.DeadTime <= 8000;
			}
			return true;
		}
		return false;
	}

	private void SetImageScale(Vector3 oldfs, Vector3 newfs)
	{
		_viewModel.ImageScale = newfs;
	}

	protected virtual Vector3 GetImageScale()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			if (!item.FreeRadar)
			{
				if (item.Mask == 7)
				{
					_ = MapData.WorldMax - MapData.WorldMin;
					return new Vector3(item.ScaleX * MapData.ScaleX / 30f, item.ScaleY * MapData.ScaleX / 30f) * 2f;
				}
				return new Vector3(item.ScaleX, item.ScaleY);
			}
			if (item.Mask <= 0)
			{
				return new Vector3(item.ScaleX, item.ScaleY) * item.SmallMapScale;
			}
		}
		return Vector3.one;
	}

	private void SetAlpha(float oldfs, float newfs)
	{
		_viewModel.MapItemAlpha = newfs;
	}

	private float GetAlpha()
	{
		return GetItem()?.Alpha ?? 0f;
	}

	private bool GetHideNameAndHp()
	{
		return GetItem()?.IsHideNameAndHp ?? false;
	}

	private void SetHideNameAndHp(bool oldfs, bool newfs)
	{
		if (!IsInRadar)
		{
			_viewModel.HpShow = !newfs;
		}
		if (newfs)
		{
			bool flag = false;
			ISmallMapImageItem item = GetItem();
			if (item != null)
			{
				flag = item.IsShowName;
			}
			if (!flag)
			{
				_viewModel.NameShow = false;
			}
		}
	}

	private void SetTacticsSoundTime(bool oldfs, bool newfs)
	{
		_viewModel.TacticsShow = newfs;
	}

	public bool GetTacticsSoundTime()
	{
		return GetItem()?.TacticsSoundTime ?? false;
	}

	private void SetImageSize(float oldfs, float newfs)
	{
		if (newfs > 0f)
		{
			_viewModel.ImageSize = new Vector3(newfs, newfs, 1f);
		}
	}

	private float GetImageSize()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null && item.RealWidth > 0f && item.Mask <= 0)
		{
			return MapData.RealWidth * item.RealWidth / (MapData.WorldMax.x - MapData.WorldMin.x);
		}
		return 0f;
	}

	private void SetRotation(float oldfs, float newfs)
	{
		_viewModel.RotationRotation = Quaternion.Euler(0f, 0f, newfs);
	}

	private float GetRotation()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			if (IsInRadar)
			{
				if (!item.AddRotateSelfInRadar && !item.IsSos && item.SceneObj && !item.FreeRadar)
				{
					return 0f;
				}
				return item.Rotation;
			}
			if ((item.SceneObj && !item.FreeRadar) || (!string.IsNullOrEmpty(item.SmallMapImage.AssetName) && item.IsSos))
			{
				return 0f;
			}
			return item.Rotation;
		}
		return 0f;
	}

	private void SetSmallMapImage(AssetInfo oldfs, AssetInfo newfs)
	{
		if (string.IsNullOrEmpty(newfs.AssetName) || newfs.AssetName == "null")
		{
			_viewModel.ImageShow = false;
			return;
		}
		_currImage = newfs;
		_viewModel.ImageSprite = this.GetLoader().RetriveSprite(newfs, delegate(Sprite v)
		{
			if (_currImage == newfs)
			{
				_viewModel.ImageShow = true;
				_viewModel.ImageSprite = v;
				ISmallMapImageItem item = GetItem();
				if (item != null && item.RealWidth <= 0f)
				{
					_viewModel.ImageNtvsize();
				}
			}
		});
	}

	protected virtual AssetInfo GetSmallMapImage()
	{
		ISmallMapImageItem item = GetItem();
		if (item == null || (item.Mask > 0 && item.Mask != 7))
		{
			return new AssetInfo("null", "null");
		}
		return item.SmallMapImage;
	}

	private void SetPositon(Vector3 oldfs, Vector3 newfs)
	{
		_viewModel.MapItemPosition = newfs;
	}

	protected virtual Vector3 GetPosition()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			Vector3 result = item.Position - MapData.WorldMin;
			result.x *= MapData.ScaleX;
			result.y *= MapData.ScaleY;
			result.z = 0f;
			return result;
		}
		return Vector3.zero;
	}

	private void SetHp(long oldfs, long newfs)
	{
		bool[] shows = new bool[4];
		ConvertLargeNummber(newfs, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], newfs >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		_viewModel.SetHealthShowLargenumber(shows);
		_viewModel.SetHealthPosiLargenumber(positions);
		_viewModel.SetHealthTextLargenumber(wholeStr, decimalStr);
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 6f;
		float num2 = 15f;
		float num3 = (usingDot ? (-9.5f) : (-19.5f));
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[5]
		{
			new Vector3(num2 + offset.x, -8f + offset.y),
			new Vector3(-24.5f + (float)num4 * num, 1.5f),
			new Vector3(10f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 4.5f),
			new Vector3(num3 + (float)num4 * num, 4.5f)
		};
	}

	protected virtual long GetHp()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			if (item.IsHideNameAndHp)
			{
				return 0L;
			}
			return item.Hp;
		}
		return 0L;
	}

	private void SetName(string oldfs, string newfs)
	{
		_viewModel.NameString = newfs;
	}

	protected virtual string GetName()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null && item.IsShowName)
		{
			return item.Name;
		}
		if (item == null || item.SceneObj || item.IsBot)
		{
			return "";
		}
		return item.Name;
	}

	protected ISmallMapImageItem GetItem()
	{
		List<ISmallMapImageItem> minimapData_ImageList = UiIEventCondition.Get_minimapData_ImageList();
		if (minimapData_ImageList.Count > Index)
		{
			return minimapData_ImageList[Index];
		}
		return null;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

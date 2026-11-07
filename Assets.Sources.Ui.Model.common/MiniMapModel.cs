using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Components.Rader;
using Assets.Sources.Framework;
using Assets.Sources.Free.UI;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Input;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.EventSystems;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

public class MiniMapModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext, IKeyboardResponder, ICursorControl, ISetPlayerContext, IMiniMapData
{
	protected readonly MinimapViewModel _viewModel = new MinimapViewModel();

	protected Vector3 _worldMin = Vector3.zero;

	protected Vector3 _worldMax = Vector3.zero;

	protected float _scaleX = 1f;

	protected float _scaleY = 1f;

	private Vector3 _mapPosition = Vector3.zero;

	protected float _width;

	protected float _height;

	private float _left;

	private float _bottom;

	private float _realWidth;

	private float _realHeight;

	protected GameRuleContext _gameRuleContext;

	protected CircleImage _duwuImage;

	protected readonly NotifyGroup _notifyGroup = new NotifyGroup();

	protected bool _freeMark;

	protected readonly List<MapItemModel> _itemList = new List<MapItemModel>();

	protected Vector3 _lastClickPos;

	private AssetInfo _duwuAsset;

	private BattleRoomContext _battleRoomContext;

	private int _closeDelay;

	private float _radius;

	private PlayerContext _playerContext;

	protected override List<UiAssetInfo> ConfigRequests => new List<UiAssetInfo>
	{
		new UiAssetInfo(_battleRoomContext.mapInfo.MapInfo.AssetBundleName, "scenemapdataconfig")
	};

	protected override IUiViewModel ViewModel => _viewModel;

	public Vector3 WorldMax => _worldMax;

	public float ScaleX => _scaleX;

	public float ScaleY => _scaleY;

	public float RealWidth => _realWidth;

	public float RealHeight => _realHeight;

	public float Radius => _radius;

	public GameObject Container => _viewModel.CommonItemsObj;

	public NotifyGroup NotifyGroup => _notifyGroup;

	public Vector3 WorldMin => _worldMin;

	public int CloseDelay
	{
		get
		{
			return _closeDelay;
		}
		set
		{
			_closeDelay = value;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	protected override void GetConfigValue()
	{
		_left = float.Parse(GetValue("left"));
		float num = float.Parse(GetValue("right"));
		float num2 = float.Parse(GetValue("top"));
		_bottom = float.Parse(GetValue("bottom"));
		_width = float.Parse(GetValue("width"));
		_height = float.Parse(GetValue("height"));
		_realWidth = _width - (_left + num);
		_realHeight = _height - (num2 + _bottom);
		Vector3 uiPyEngine_Min = UiIEventCondition.Get_uiPyEngine_Min();
		Vector3 uiPyEngine_Max = UiIEventCondition.Get_uiPyEngine_Max();
		if (uiPyEngine_Min != uiPyEngine_Max)
		{
			Vector3 vector = uiPyEngine_Max - uiPyEngine_Min;
			_scaleX = _realWidth / vector.x;
			_scaleY = _realHeight / vector.y;
		}
		_worldMin = UiIEventCondition.Get_uiPyEngine_Min();
		_worldMax = UiIEventCondition.Get_uiPyEngine_Max();
		SetMapPosition();
	}

	protected void SetMapPosition()
	{
		MinimapViewModel viewModel = _viewModel;
		Vector3 imageBackPosition = (_viewModel.DuwuMaskPosition = new Vector3((int)(512f - _width / 2f), -(int)(512f - _height / 2f)));
		viewModel.ImageBackPosition = imageBackPosition;
		_viewModel.HelpInfoPosition = new Vector3(_width - 512f, 512f);
		_viewModel.ItemsPosition = new Vector3(-(int)(_width / 2f - _left), -(int)(_height / 2f - _bottom));
		_viewModel.PathsPosition = new Vector3(-(int)(_width / 2f - _left), -(int)(_height / 2f - _bottom));
		_viewModel.DuwuPosition = -_viewModel.ImageBackPosition + _viewModel.ItemsPosition;
		UpdateMapPosition(UiIEventCondition.Get_cameraOwnerData_Position());
	}

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		_duwuImage = _viewModel.DuwuObj.GetComponent<CircleImage>();
		_freeMark = _gameRuleContext.currentRule.Rule.EnableFreeMark;
		SetMapPosition();
		_viewModel.ShowShow = false;
		_viewModel.HelpInfoShow = _freeMark;
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Yaw, SetYaw, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TacticsSoundTime, SetTacticsSoundTime, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Position, SetPosition, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsDead, SetIsDead, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_PlayerName, SetPlayerName, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, SetHp, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_minimapData_MapInfo, SetMapInfo, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ShowDuwu, SetShowDuwu, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetDuwuImage, SetDuwuImage, null, initinvoke: true, isFrameSeparation: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetInnerOffset, SetInnerOffset, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetThickness, SetThickness, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetHideSelf, SetHideSelf, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetGray, SetGray, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetSafeSize, SetSafeSize, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetSafePosition, SetSafePosition, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetMinimapPathChanged, SetMinimapPathChanged, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ImageListCount, SetImageListCount, null, initinvoke: true));
		_notifyGroup.SetSuspend(suspend: true);
		if (!_freeMark)
		{
			return;
		}
		_viewModel.CreateTriggerEntry(_viewModel.ImageBackTriggers, EventTriggerType.PointerClick, delegate(BaseEventData data)
		{
			if (data is PointerEventData { button: PointerEventData.InputButton.Right } pointerEventData && pointerEventData.position.x < (float)Display.main.systemWidth * 0.5f + _width * 0.5f && pointerEventData.position.y > (float)Display.main.systemHeight * 0.5f - _height * 0.5f)
			{
				Vector3 vector = new Vector3(pointerEventData.position.x - (float)Display.main.systemWidth * 0.5f - _viewModel.ItemsPosition.x, pointerEventData.position.y - (float)Display.main.systemHeight * 0.5f - _viewModel.ItemsPosition.y);
				vector = new Vector2(vector.x / _scaleX + _worldMin.x, vector.y / _scaleY + _worldMin.y);
				MonoBehaviourSingleton<FreeUiManager>.Instance.ClickSmallMap(vector, Vector3.Distance(_lastClickPos, pointerEventData.position));
				_lastClickPos = pointerEventData.position;
			}
		});
	}

	protected void SetSafePosition(Vector3 arg1, Vector3 arg2)
	{
		_viewModel.SafePosition = arg2;
	}

	private bool GetMinimapPathChanged()
	{
		return _gameRuleContext.rpgPathGuide.minimapPathChanged;
	}

	private void SetMinimapPathChanged(bool arg1, bool arg2)
	{
		if (!arg2)
		{
			return;
		}
		_gameRuleContext.rpgPathGuide.minimapPathChanged = false;
		GameObject pathsObj = _viewModel.PathsObj;
		for (int i = 0; i < pathsObj.transform.childCount; i++)
		{
			pathsObj.transform.GetChild(i).gameObject.SetActive(value: false);
		}
		int num = 0;
		foreach (KeyValuePair<int, ZhishiData> minimapPath in _gameRuleContext.rpgPathGuide.minimapPaths)
		{
			if (num >= pathsObj.transform.childCount)
			{
				GameObject gameObject = Object.Instantiate(pathsObj.transform.GetChild(0).gameObject);
				gameObject.transform.parent = pathsObj.transform;
				gameObject.transform.localScale = Vector3.one;
			}
			GameObject gameObject2 = pathsObj.transform.GetChild(num).gameObject;
			gameObject2.SetActive(value: true);
			UpdatePathGuide(gameObject2, minimapPath.Value.PointList);
			num++;
		}
	}

	private void UpdatePathGuide(GameObject item, List<Vector3> paths)
	{
		for (int i = 0; i < item.transform.childCount; i++)
		{
			item.transform.GetChild(i).gameObject.SetActive(value: false);
		}
		int num = 19;
		Vector3 miniMapPosition = GetMiniMapPosition(paths[0]);
		int num2 = 0;
		item.transform.localPosition = miniMapPosition;
		for (int j = 1; j < paths.Count; j++)
		{
			Vector3 vector = GetMiniMapPosition(paths[j - 1]) - miniMapPosition;
			Vector3 vector2 = GetMiniMapPosition(paths[j]) - miniMapPosition;
			float num3 = Vector3.Distance(vector, vector2) - 4f;
			if (num3 < 0f)
			{
				continue;
			}
			Vector3 vector3 = vector2 - vector;
			float z = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
			float num4 = 0f;
			while (num4 < num3)
			{
				if (num2 >= item.transform.childCount)
				{
					GameObject gameObject = Object.Instantiate(item.transform.GetChild(0).gameObject);
					gameObject.transform.parent = item.transform;
					gameObject.transform.localScale = Vector3.one;
				}
				GameObject gameObject2 = item.transform.GetChild(num2).gameObject;
				gameObject2.SetActive(value: true);
				updateWidth(gameObject2, Mathf.Min(num, num3 - num4));
				gameObject2.transform.localPosition = Vector3.Lerp(vector, vector2, num4 / num3);
				gameObject2.transform.localEulerAngles = new Vector3(0f, 0f, z);
				num4 += (float)(num * 2);
				num2++;
			}
		}
	}

	private void updateWidth(GameObject obj, float width)
	{
		RectTransform component = obj.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(width, component.sizeDelta.y);
	}

	private Vector3 GetMiniMapPosition(Vector3 origin)
	{
		Vector3 result = origin - _worldMin;
		result.x *= _scaleX;
		result.y *= _scaleY;
		result.z = 0f;
		result.x = (int)result.x;
		result.y = (int)result.y;
		return result;
	}

	protected Vector3 GetSafePosition()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			if (minimapData_Image.Safe)
			{
				_mapPosition = minimapData_Image.Position - _worldMin;
				_mapPosition.x *= _scaleX;
				_mapPosition.y *= _scaleY;
				_mapPosition.z = 0f;
				if (minimapData_Image.Mask == 6)
				{
					return new Vector3(_mapPosition.x, _mapPosition.y) - _viewModel.DuwuMaskPosition + _viewModel.ItemsPosition;
				}
				return new Vector3(_mapPosition.x, _mapPosition.y) + _viewModel.ItemsPosition;
			}
		}
		return Vector3.zero;
	}

	protected void SetSafeSize(float arg1, float arg2)
	{
		_viewModel.SafeSize = new Vector3(arg2, arg2, 1f);
	}

	protected float GetSafeSize()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			if (minimapData_Image.Safe)
			{
				if (minimapData_Image.Mask == 6)
				{
					return RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x) * 2f;
				}
				return RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x);
			}
		}
		return 0f;
	}

	protected void SetImageListCount(int arg1, int arg2)
	{
		while (arg2 > _itemList.Count)
		{
			MapItemModel mapItemModel = new MapItemModel
			{
				Index = _itemList.Count,
				MapData = this,
				IsInRadar = false
			};
			_itemList.Add(mapItemModel);
			mapItemModel.SetGameRuleContext(_gameRuleContext);
			mapItemModel.Initialize();
		}
	}

	protected void SetInnerOffset(Vector3 oldfs, Vector3 newfs)
	{
		_duwuImage.inneroffset = Vector3.zero;
		_duwuImage.SetVerticesDirty();
		_viewModel.DuwuPosition = newfs;
	}

	protected Vector3 GetInnerOffset()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			switch (minimapData_Image.Mask)
			{
			case 1:
			case 4:
				_mapPosition = minimapData_Image.Position - _worldMin;
				_mapPosition.x *= _scaleX;
				_mapPosition.y *= _scaleY;
				_mapPosition.z = 0f;
				return new Vector3(_mapPosition.x, _mapPosition.y) + _viewModel.ItemsPosition;
			case 5:
				_mapPosition = minimapData_Image.Position - _worldMin;
				_mapPosition.x *= _scaleX;
				_mapPosition.y *= _scaleY;
				_mapPosition.z = 0f;
				return new Vector3(_mapPosition.x, _mapPosition.y) - _viewModel.DuwuMaskPosition + _viewModel.ItemsPosition;
			}
		}
		return Vector3.zero;
	}

	protected void SetDuwuImage(AssetInfo oldfs, AssetInfo newfs)
	{
		if (newfs.AssetName != "null" && !string.IsNullOrEmpty(newfs.AssetName) && _duwuAsset != newfs)
		{
			_duwuAsset = newfs;
			this.GetLoader().RetriveSprite(newfs, delegate(Sprite v)
			{
				_viewModel.DuwuSprite = v;
			});
		}
	}

	protected AssetInfo GetDuwuImage()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			if (minimapData_Image.Mask == 4 || minimapData_Image.Mask == 5)
			{
				return minimapData_Image.SmallMapImage;
			}
		}
		return new AssetInfo("null", "null");
	}

	protected void SetThickness(float oldfs, float newfs)
	{
		_duwuImage.thickness = newfs;
		_duwuImage.SetVerticesDirty();
	}

	protected float GetThickness()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			if (minimapData_Image.FreeRadar)
			{
				if (minimapData_Image.Mask == 1)
				{
					if (minimapData_Image.RealWidth > 0f)
					{
						return 128f - 128f * _realWidth / 2048f * (minimapData_Image.RealWidth / (_worldMax.x - _worldMin.x));
					}
					return 128f - minimapData_Image.ScaleX * 224f / 256f;
				}
			}
			else if (minimapData_Image.Mask == 5)
			{
				float num = RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x) * 2f;
				return (256f - num / _viewModel.DuwuObj.transform.localScale.x) / 2f;
			}
		}
		return 0f;
	}

	protected void SetHideSelf(bool arg1, bool arg2)
	{
		_viewModel.SelfPositionShow = !arg2;
	}

	protected bool GetHideSelf()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.skill != null)
		{
			return cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HIDE_IN_MAP.ID);
		}
		return false;
	}

	protected bool GetGray()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.skill != null)
		{
			return cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.MAP_DISTRACTION.ID);
		}
		return false;
	}

	protected void SetGray(bool arg1, bool arg2)
	{
		_viewModel.MapGrayShow = arg2;
	}

	protected void SetShowDuwu(bool arg1, bool arg2)
	{
		_viewModel.DuwuMaskShow = arg2;
	}

	protected void SetHp(long arg1, long arg2)
	{
		bool[] shows = new bool[4];
		ConvertLargeNummber(arg2, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], arg2 >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		_viewModel.SetSelfHealthShowLargenumber(shows);
		_viewModel.SetSelfHealthPosiLargenumber(positions);
		_viewModel.SetSelfHealthTextLargenumber(wholeStr, decimalStr);
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 6f;
		float num2 = 25f;
		float num3 = (usingDot ? (-9.5f) : (-19.5f));
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[5]
		{
			new Vector3(num2 + offset.x, -11f + offset.y),
			new Vector3(-24.5f + (float)num4 * num, 1.5f),
			new Vector3(10f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 4.5f),
			new Vector3(num3 + (float)num4 * num, 4.5f)
		};
	}

	protected void SetPlayerName(string arg1, string arg2)
	{
		_viewModel.SelfNameString = arg2;
	}

	protected void SetIsDead(bool arg1, bool arg2)
	{
		_viewModel.SelfDeadEnabled = arg2;
		_viewModel.SelfAliveShow = !arg2;
	}

	protected void SetPosition(Vector3 arg1, Vector3 arg2)
	{
		if (_viewModel.ShowShow)
		{
			UpdateMapPosition(arg2);
		}
	}

	protected void SetTacticsSoundTime(bool arg1, bool arg2)
	{
		_viewModel.SelfSoundEnabled = arg2;
	}

	protected void SetYaw(float arg1, float arg2)
	{
		_viewModel.SelfRotationRotation = Quaternion.Euler(0f, 0f, arg2 - 90f);
	}

	protected void SetMapInfo(IMapInfo ov, IMapInfo mapInfo)
	{
		if (mapInfo != null)
		{
			string assetBundleName = mapInfo.AssetBundleName;
			string assetName = mapInfo.AssetName;
			_viewModel.MapImageSprite = base.Loader.RetriveSprite(assetBundleName, UiAssetBundleUtils.GetRadarMapFullPath(assetName), delegate(Sprite sprite)
			{
				_viewModel.MapImageSprite = sprite;
			});
			_viewModel.ImageBackSprite = base.Loader.RetriveSprite(assetBundleName, UiAssetBundleUtils.GetMiniMapBackFullPath(assetName), delegate(Sprite sprite)
			{
				MinimapViewModel viewModel = _viewModel;
				Sprite imageBackSprite = (_viewModel.DuwuMaskSprite = sprite);
				viewModel.ImageBackSprite = imageBackSprite;
				_viewModel.ImageBackEnabled = sprite != null;
			});
		}
	}

	protected void UpdateMapPosition(Vector3 origin)
	{
		_mapPosition = origin - _worldMin;
		_mapPosition.x *= _scaleX;
		_mapPosition.y *= _scaleY;
		_mapPosition.z = 0f;
		_mapPosition.x = (int)_mapPosition.x;
		_mapPosition.y = (int)_mapPosition.y;
		_viewModel.SelfPositionPosition = _mapPosition;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.BackQuote)
		{
			_viewModel.ShowShow = true;
			_notifyGroup.SetSuspend(suspend: false);
			UpdateMapPosition(UiIEventCondition.Get_cameraOwnerData_Position());
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.BackQuote)
		{
			_viewModel.ShowShow = false;
			_notifyGroup.SetSuspend(suspend: true);
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow || !_freeMark)
		{
			return 0;
		}
		return 2048;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}

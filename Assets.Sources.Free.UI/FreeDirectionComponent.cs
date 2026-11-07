using System.Collections;
using System.Collections.Generic;
using Assets.RUI;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;
using math;

namespace Assets.Sources.Free.UI;

public class FreeDirectionComponent : FreeBaseComponent
{
	private FreeBaseImage _image;

	private string _imageUrl;

	private IEnumerator _enumerator;

	private float _playerYaw;

	private Vector3 _selfPos;

	private bool _reverseX;

	private bool _reverseY;

	private FreeSmallMapComponent _smallMap;

	private readonly Dictionary<long, IFreeComponent> _teamMarkImages = new Dictionary<long, IFreeComponent>();

	private readonly string[] _personMarkUrl = new string[5] { "commonfree/map/yellowTri.atf", "commonfree/map/blueTri.atf", "commonfree/map/greenTri.atf", "commonfree/map/orangeTri.atf", "commonfree/map/whiteTri.atf" };

	private readonly List<IFreeComponent> _persons = new List<IFreeComponent>();

	private int _personMarkPosDiff = -19;

	private readonly string[] _teamMarkUrl = new string[4] { "commonfree/map/yellow.atf", "commonfree/map/blue.atf", "commonfree/map/orange.atf", "commonfree/map/green.atf" };

	private List<IFreeComponent> _teams = new List<IFreeComponent>();

	private int _teamMarkPosDiff = -19;

	private Dictionary<long, MapInfoComponent.PointInfo> MapPointInfos => Contexts.sharedInstance.battleRoom.mapInfo.MarkedPositions;

	public string ImageUrl
	{
		get
		{
			return _imageUrl;
		}
		set
		{
			if (_imageUrl == value || value == null)
			{
				return;
			}
			_imageUrl = value;
			if (FreeBaseComponent.IsNullString(_imageUrl) || !_imageUrl.EndsWith(".atf"))
			{
				_image.sprite = null;
				return;
			}
			if (_enumerator != null)
			{
				BaseAsyncManager.Instance.StopCoroutine(_enumerator);
				_enumerator = null;
			}
			AssetInfo assetInfoGenImageUrl = GetAssetInfoGenImageUrl(_imageUrl);
			if (!FreeResourceUtility.CheckSetImage(_image, assetInfoGenImageUrl, ComponentData))
			{
				_enumerator = FreeResourceUtility.LoadImage(_image, assetInfoGenImageUrl, ComponentData);
				BaseAsyncManager.Instance.StartCoRoutine(_enumerator);
			}
		}
	}

	public FreeDirectionComponent()
	{
		base.Type = 11;
		base.ValueType = 2;
		ComponentData = new FreeImageComponent.ImageComponentData(1176, 30, 588, 30);
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject gameObject = new GameObject("Image");
		_image = gameObject.AddComponent<FreeBaseImage>();
		_image.raycastTarget = false;
		_image.sprite = TextureUtility.GetTransparentSprite();
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
		string[] personMarkUrl = _personMarkUrl;
		foreach (string imageUrl in personMarkUrl)
		{
			CommonSetChild(imageUrl, _persons);
		}
		personMarkUrl = _teamMarkUrl;
		foreach (string imageUrl2 in personMarkUrl)
		{
			CommonSetChild(imageUrl2, _teams);
		}
	}

	private void CommonSetChild(string imageUrl, List<IFreeComponent> list)
	{
		IFreeComponent freeComponent = new FreeImageComponent();
		((FreeImageComponent)freeComponent).ComponentData = new FreeImageComponent.ImageComponentData(32, 32, 64, 32);
		((FreeImageComponent)freeComponent).ImageUrl = imageUrl;
		freeComponent.ToUI().ActiveVisible = false;
		list.Add(freeComponent);
		UnityObject.AddChild(freeComponent.ToUI());
	}

	public override void Frame(IUIDataManager uiDataManager, int frammeTime, IComponentGroup gGroup)
	{
		if (IsCanFrame(gGroup))
		{
			base.Frame(uiDataManager, frammeTime, gGroup);
		}
		if (!(MonoBehaviourSingleton<FreeUiManager>.Instance.GetSmallMap() == null))
		{
			_smallMap = MonoBehaviourSingleton<FreeUiManager>.Instance.GetSmallMap().SmallMapComponent;
			if (_smallMap != null && Contexts.sharedInstance.player != null && Contexts.sharedInstance.player.myPlayerEntity != null)
			{
				HideMarkImages();
				UpdateSelfPlayerInfo();
				UpdateDirectionImageWithPlayerYaw();
				UpdateMarkImageForSelfPlayer();
				UpdateTeamMarkImages();
			}
		}
	}

	private bool IsCanFrame(IComponentGroup gGroup)
	{
		if (gGroup is SimpleFreeUI)
		{
			return (gGroup as SimpleFreeUI).Visible;
		}
		return false;
	}

	private void HideMarkImages()
	{
		for (int i = 0; i < _persons.Count; i++)
		{
			_persons[i].ToUI().ActiveVisible = false;
		}
		for (int j = 0; j < _teams.Count; j++)
		{
			_teams[j].ToUI().ActiveVisible = false;
		}
	}

	private void UpdateSelfPlayerInfo()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		_playerYaw = myPlayerEntity.orientation.Yaw;
		_selfPos.x = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()).x;
		_selfPos.y = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()).y;
		_selfPos.z = 0f;
	}

	private void UpdateDirectionImageWithPlayerYaw()
	{
		float num = (float)AngleUtils.MakeAngleInRange(90f - _playerYaw);
		float x = (num - 90f) / 360f;
		float z = (num + 90f) / 360f;
		Vector4 uvControl = new Vector4(x, 0f, z, 1f);
		_image.SetUvControl(uvControl);
	}

	private void UpdateMarkImageForSelfPlayer()
	{
		if (_persons.Count >= 5)
		{
			_persons[4].ToUI().PosX = (float)ToUI().Width / 2f;
			_persons[4].ToUI().PosY = _personMarkPosDiff;
			_persons[4].ToUI().ActiveVisible = true;
		}
	}

	private void UpdateTeamMarkImages()
	{
		foreach (KeyValuePair<long, MapInfoComponent.PointInfo> mapPointInfo in MapPointInfos)
		{
			long key = mapPointInfo.Key;
			if (!_teamMarkImages.TryGetValue(key, out var value))
			{
				int imageIndexForPlayer = _smallMap.GetMarkInfo().GetImageIndexForPlayer(key);
				if (imageIndexForPlayer < _teams.Count && imageIndexForPlayer >= 0)
				{
					value = _teams[imageIndexForPlayer];
					_teamMarkImages[key] = value;
				}
			}
			if (value != null)
			{
				UpdateMark(value, mapPointInfo.Value);
			}
		}
	}

	private void UpdateMark(IFreeComponent freeComponent, MapInfoComponent.PointInfo pointInfo)
	{
		freeComponent.ToUI().ActiveVisible = true;
		float num = AngleUtility.MakeAngleInRange(AngleUtility.MakeAngleInRange(AngleUtility.Vector3DAngles(new Vector3(pointInfo.Position.x - _selfPos.x, pointInfo.Position.y - _selfPos.y, 0f)).y) - _playerYaw);
		if (num < 90f && num > -90f)
		{
			float num2 = num / 90f * (float)ToUI().Width / 2f;
			freeComponent.ToUI().PosX = (float)ToUI().Width / 2f - num2;
			freeComponent.ToUI().PosY = _teamMarkPosDiff;
		}
		if (num >= 90f)
		{
			freeComponent.ToUI().PosX = 5f;
			freeComponent.ToUI().PosY = _teamMarkPosDiff;
		}
		if (num <= -90f)
		{
			freeComponent.ToUI().PosX = ToUI().Width - 5;
			freeComponent.ToUI().PosY = _teamMarkPosDiff;
		}
	}

	protected override void SetPureValue(string value)
	{
		ImageUrl = value;
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 1)
		{
			string[] array2 = array[1].Split(',');
			if (array2.Length == 2)
			{
				_image.rectTransform.pivot = new Vector2(float.Parse(array2[0]), float.Parse(array2[1]));
			}
		}
		_ = array.Length;
		_ = 2;
		string t = "";
		if (FreeDataHelperUtility.GetStringArrayIdx(array, 3, ref t))
		{
			int result = 0;
			if (int.TryParse(t, out result))
			{
				if (result == 1)
				{
					_reverseX = true;
				}
				if (result == 2)
				{
					_reverseY = true;
				}
				if (result == 3)
				{
					_reverseX = true;
					_reverseY = true;
				}
			}
		}
		FreeDataHelperUtility.GetStringArrayIdx(array, 4, ref DataElement.ComponentName);
		_image.SetImageUvReverse(_reverseX, _reverseY, ComponentData.ComponentWidth, ComponentData.ComponentHeight);
		SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
		SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
		data.SetValueInt = 0;
		data2.SetValueStr = array[0];
		SetValue(data, data2);
		SetValueAdapter.Instance.Release(data, data2);
	}

	public override IFreeComponent Clone()
	{
		return new FreeDirectionComponent();
	}
}

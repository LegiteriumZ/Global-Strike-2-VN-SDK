using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Components.Rader;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

public class RadarMapModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext, ISetPlayerContext, IMiniMapData
{
	private const string AssetMap = "map.png";

	private readonly Dictionary<int, string> _mapInfoDic = new Dictionary<int, string>();

	protected readonly RadarmapViewModel _viewModel = new RadarmapViewModel();

	private int _raceType;

	protected GameRuleContext _gameRuleContext;

	private string _configName;

	private Vector3 _worldMin = Vector3.zero;

	private Vector3 _worldMax = Vector3.zero;

	private float _scaleX = 1f;

	private float _scaleY = 1f;

	private float _radius = 1f;

	private Vector3 _mapPosition = Vector3.zero;

	private float _width;

	private float _height;

	private float _left;

	private float _bottom;

	private float _realWidth;

	private float _realHeight;

	private bool _stopLoadingNameConfig;

	protected CircleImage _duwuImage;

	protected IListNotify _listener;

	protected readonly List<MapItemModel> _itemList = new List<MapItemModel>();

	private AssetInfo _duwuAsset;

	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override List<UiAssetInfo> ConfigRequests => new List<UiAssetInfo>
	{
		new UiAssetInfo(_battleRoomContext.mapInfo.MapInfo.AssetBundleName, "scenemapdataconfig"),
		new UiAssetInfo(UiAssetBundleUtils.UiConfigBundleName, "RadarMap")
	};

	public float ScaleX => _scaleX;

	public float ScaleY => _scaleY;

	public Vector3 WorldMin => _worldMin;

	public Vector3 WorldMax => _worldMax;

	public float RealWidth => _realWidth;

	public float RealHeight => _realHeight;

	public GameObject Container => _viewModel.CommonItemsObj;

	public NotifyGroup NotifyGroup => null;

	public float Radius => _radius;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	protected override void GetConfigValue()
	{
		if (!float.TryParse(GetValue("radius"), out _radius))
		{
			_radius = 220f;
		}
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
		_viewModel.MapBasePosition = new Vector3(512f - _left, _height - _bottom - 512f) / 2f;
		UpdateMapPosition(UiIEventCondition.Get_cameraOwnerData_Position());
	}

	protected override void OnGameobjectInitialized()
	{
		_raceType = _battleRoomContext.roomData.Data.RaceType;
		_viewModel.ModeNameShow = false;
		_viewModel.MaskShow = false;
		_viewModel.DifficultyShow = false;
		base.OnGameobjectInitialized();
		_configName = Contexts.sharedInstance.gameRule.currentRule.Rule.GetModeConfig;
		ShowMapName();
	}

	protected void SetMapInfo(IMapInfo ov, IMapInfo mapInfo)
	{
		if (mapInfo != null)
		{
			if (!_mapInfoDic.ContainsKey(mapInfo.Id))
			{
				_mapInfoDic[mapInfo.Id] = mapInfo.AssetBundleName;
			}
			_viewModel.MapPositionSprite = base.Loader.RetriveSprite(_mapInfoDic[mapInfo.Id], "map.png", LoadMapPosition);
		}
	}

	private void LoadMapPosition(Sprite sprite)
	{
		_viewModel.MapPositionSprite = sprite;
		_viewModel.MaskShow = sprite != null;
		UpdateMapPosition(UiIEventCondition.Get_cameraOwnerData_Position());
	}

	public virtual void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		_duwuImage = _viewModel.DuwuObj.GetComponent<CircleImage>();
		SetMapPosition();
		_listener = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_minimapData_ImageList);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Yaw, SetYaw, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TacticsSoundTime, SetTacticsSoundTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Position, SetPosition, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_minimapData_MapInfo, SetMapInfo, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ShowDuwu, SetShowDuwu, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDuwuImage, SetDuwuImage, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetInnerOffset, SetInnerOffset, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetThickness, SetThickness, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetHideSelf, SetHideSelf, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetGray, SetGray, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSafeSize, SetSafeSize, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSafePosition, SetSafePosition, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_minimapData_ImageListCount, SetImageListCount, null, initinvoke: true);
		NotifyManager.MakeNotify(71, UiIEventCondition.Get_RadarMap_Show, SetRadarActive);
		NotifyManager.MakeNotify(72, UiIEventCondition.Get_RadarMap_Hide, SetRadarActive);
		SetBotLevel();
	}

	protected void SetRadarActive(bool ov, bool changed)
	{
		_viewModel.ViewGameObjectShow = changed;
	}

	protected void SetSafePosition(Vector3 arg1, Vector3 arg2)
	{
		_viewModel.SafePosition = arg2;
	}

	protected Vector3 GetSafePosition()
	{
		foreach (ISmallMapImageItem minimapData_Image in UiIEventCondition.Get_minimapData_ImageList())
		{
			if (minimapData_Image.Safe)
			{
				_mapPosition = minimapData_Image.Position - UiIEventCondition.Get_cameraOwnerData_Position();
				_mapPosition.x *= _scaleX;
				_mapPosition.y *= _scaleY;
				_mapPosition.z = 0f;
				return new Vector2(_mapPosition.x, _mapPosition.y) * 0.5f;
			}
		}
		return Vector3.zero;
	}

	protected void SetSafeSize(float arg1, float arg2)
	{
		_viewModel.SafeShow = arg2 > 0f;
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
					return RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x);
				}
				return RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x) * 0.5f;
			}
		}
		return 0f;
	}

	protected virtual void SetImageListCount(int arg1, int arg2)
	{
		while (arg2 > _itemList.Count)
		{
			RadarMapItemModel radarMapItemModel = new RadarMapItemModel
			{
				Index = _itemList.Count,
				MapData = this,
				IsInRadar = true
			};
			_itemList.Add(radarMapItemModel);
			radarMapItemModel.SetGameRuleContext(_gameRuleContext);
			radarMapItemModel.Initialize();
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
			int mask = minimapData_Image.Mask;
			if (mask == 1 || (uint)(mask - 4) <= 1u)
			{
				_mapPosition = minimapData_Image.Position - UiIEventCondition.Get_cameraOwnerData_Position();
				_mapPosition.x *= _scaleX;
				_mapPosition.y *= _scaleY;
				_mapPosition.z = 0f;
				return new Vector2(_mapPosition.x, _mapPosition.y) * 0.5f;
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
				return minimapData_Image.RadarImage;
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
				float num = RealWidth * minimapData_Image.RealWidth / (WorldMax.x - WorldMin.x);
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
		_viewModel.GrayMapShow = arg2;
	}

	protected void SetBotLevel()
	{
		string text = "";
		if (_gameRuleContext.currentRule.Rule.IsBot())
		{
			switch (_battleRoomContext.roomData.Data.BotLevel)
			{
			case 1:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/botrookie.png";
				break;
			case 2:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/botnormal.png";
				break;
			case 3:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/bothard.png";
				break;
			default:
				_ = 4;
				break;
			}
		}
		if (_battleRoomContext.roomData.Data.StrikeLevel > 0)
		{
			switch (_battleRoomContext.roomData.Data.StrikeLevel)
			{
			case 1:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/strikelevel1.png";
				break;
			case 2:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/strikelevel2.png";
				break;
			case 3:
				text = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModel/strikelevel3.png";
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/gameModel", text, delegate(Sprite sprite)
			{
				_viewModel.DifficultyShow = true;
				_viewModel.DifficultySprite = sprite;
				_viewModel.DifficultyNtvsize();
			});
		}
		else
		{
			_viewModel.DifficultyShow = false;
		}
	}

	protected void SetShowDuwu(bool arg1, bool arg2)
	{
		_viewModel.DuwuShow = arg2;
	}

	protected void SetPosition(Vector3 arg1, Vector3 arg2)
	{
		UpdateMapPosition(arg2);
		_listener.ForceInvoke();
	}

	protected void SetTacticsSoundTime(bool ov, bool flag)
	{
		_viewModel.TacticsSoundShow = flag;
	}

	protected virtual void SetYaw(float ov, float yaw)
	{
		if (UiIEventCondition.Get_cameraOwnerData_Observer() != 0 || UiIEventCondition.Get_cameraOwnerData_ControlId() == 0)
		{
			_viewModel.MapRotationRotation = Quaternion.Euler(0f, 0f, 0f - yaw + 90f);
			_listener.ForceInvoke();
		}
	}

	protected void UpdateMapPosition(Vector3 origin)
	{
		_mapPosition = origin - _worldMin;
		_mapPosition.x *= 0f - _scaleX;
		_mapPosition.y *= 0f - _scaleY;
		_mapPosition.z = 0f;
		_viewModel.MapPositionPosition = _mapPosition;
	}

	private bool IsHideTitlImage()
	{
		if (_raceType != 1100 && _raceType != 134)
		{
			return RuleUtilty.isCyberSpace(_raceType);
		}
		return true;
	}

	protected void ShowMapName()
	{
		if (_stopLoadingNameConfig || string.IsNullOrEmpty(_configName))
		{
			return;
		}
		AssetInfo modeResourceConfigAssetInfo = UiAssetBundleUtils.GetModeResourceConfigAssetInfo(_configName);
		base.Loader.GetConfig(modeResourceConfigAssetInfo.BundleName, modeResourceConfigAssetInfo.AssetName, delegate(TextAsset configText)
		{
			if (null == configText)
			{
				_viewModel.ModeNameShow = false;
			}
			else if (IsHideTitlImage())
			{
				_viewModel.ModeNameShow = false;
			}
			else
			{
				ModeResourcesConfig modeResourcesConfig = ModeResourcesConfigParser.ParseConfig(configText.text);
				if (modeResourcesConfig.Inited)
				{
					if (string.IsNullOrEmpty(modeResourcesConfig.ModeImage))
					{
						_stopLoadingNameConfig = true;
					}
					else
					{
						AssetInfo modeNameAssetInfo = UiAssetBundleUtils.GetModeNameAssetInfo(modeResourcesConfig.ModeImage);
						base.Loader.RetriveSprite("ui/halfloadedres/gameModel", modeNameAssetInfo.AssetName, _viewModel.ModeNameImage, autosetnative: true);
						_viewModel.ModeNameShow = true;
					}
				}
			}
		});
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}

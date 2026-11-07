using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using UnityEngine.Rendering.PostProcessing;
using share.constant;

namespace Assets.Sources.Modules.WorldCamera;

public class CameraPostProcessSystem : IRenderSystem
{
	private readonly WorldCameraContext _wordCameraContext;

	private readonly PlayerContext _playerContext;

	private readonly BattleRoomContext _battleRoomContext;

	private PostProcessVolume _postProcessVolume;

	private PostProcessVolume _handpostProcessVolume;

	private PostProcessLayer _handLayer;

	private PostProcessLayer _mainLayer;

	private PostProcessProfile _grayScaleSetting;

	private PostProcessProfile _shadowSetting;

	private bool _setProcess;

	private string _lastWeaponName = "";

	private PostProcessProfile grayScaleSetting
	{
		get
		{
			if (_grayScaleSetting == null)
			{
				_grayScaleSetting = GrayScaleSetting();
			}
			return _grayScaleSetting;
		}
	}

	private PostProcessProfile shadowSetting
	{
		get
		{
			if (_shadowSetting == null)
			{
				_shadowSetting = ShadowSetting();
			}
			return _shadowSetting;
		}
	}

	public CameraPostProcessSystem(Contexts contexts)
	{
		_wordCameraContext = contexts.worldCamera;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnRender()
	{
		if (!_battleRoomContext.hasRoomData || _battleRoomContext.roomData.Data == null || _battleRoomContext.roomData.Data.RaceType != 127)
		{
			return;
		}
		if (_handLayer == null && _playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.hasFirstPersonUnityObjects && _playerContext.cameraOwnerEntity.firstPersonUnityObjects.HandCameraObject != null)
		{
			_handLayer = _playerContext.cameraOwnerEntity.firstPersonUnityObjects.HandCameraObject.GetComponent<PostProcessLayer>();
		}
		if (_mainLayer == null && _wordCameraContext.hasUnityObjects && _wordCameraContext.unityObjects.mainCamera.GetComponent<PostProcessVolume>() == null)
		{
			_mainLayer = _wordCameraContext.unityObjects.mainCamera.GetComponent<PostProcessLayer>();
			SetLayer(_mainLayer);
		}
		if (_playerContext.cameraOwnerEntity == null || !(_mainLayer != null) || !(_handLayer != null))
		{
			return;
		}
		if (_postProcessVolume == null)
		{
			_postProcessVolume = _wordCameraContext.unityObjects.mainCamera.gameObject.AddComponent<PostProcessVolume>();
			_handpostProcessVolume = _playerContext.cameraOwnerEntity.firstPersonUnityObjects.HandCameraObject.AddComponent<PostProcessVolume>();
			_postProcessVolume.isGlobal = true;
			_postProcessVolume.enabled = true;
			_handpostProcessVolume.isGlobal = true;
			_handpostProcessVolume.enabled = true;
		}
		if (_lastWeaponName != _playerContext.cameraOwnerEntity.currentWeapon.Name)
		{
			_lastWeaponName = _playerContext.cameraOwnerEntity.currentWeapon.Name;
			_setProcess = false;
		}
		if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.InXRaySee.ID))
		{
			if (!_setProcess)
			{
				_postProcessVolume.sharedProfile = grayScaleSetting;
				_mainLayer.enabled = true;
				WeaponUtility.UseInputShader(_playerContext.cameraOwnerEntity, "SSJJ/DiffuseGrayscale");
				_setProcess = true;
			}
		}
		else if (_playerContext.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.InShadowSee.ID))
		{
			if (!_setProcess)
			{
				_handpostProcessVolume.sharedProfile = shadowSetting;
				_handLayer.enabled = true;
				_setProcess = true;
			}
		}
		else if (_setProcess)
		{
			_mainLayer.enabled = false;
			_handLayer.enabled = false;
			WeaponUtility.UseInputShader(_playerContext.cameraOwnerEntity, "SSJJ/Diffuse");
			_setProcess = false;
		}
	}

	private void SetLayer(PostProcessLayer layer)
	{
		if (!(layer == null))
		{
			layer.volumeLayer = 1;
			layer.enabled = false;
			layer.volumeTrigger = null;
		}
	}

	private PostProcessProfile GrayScaleSetting()
	{
		PostProcessProfile postProcessProfile = new PostProcessProfile();
		postProcessProfile.AddSettings(new ColorGrading
		{
			active = true,
			enabled = 
			{
				value = true
			},
			saturation = 
			{
				overrideState = true,
				value = -100f
			}
		});
		return postProcessProfile;
	}

	private PostProcessProfile ShadowSetting()
	{
		PostProcessProfile postProcessProfile = new PostProcessProfile();
		postProcessProfile.AddSettings(new ColorGrading
		{
			active = true,
			enabled = 
			{
				value = true
			},
			postExposure = 
			{
				overrideState = true,
				value = 1f
			},
			hueShift = 
			{
				overrideState = true,
				value = -13f
			},
			saturation = 
			{
				overrideState = true,
				value = -60f
			},
			contrast = 
			{
				overrideState = true,
				value = -36f
			},
			mixerRedOutRedIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerRedOutGreenIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerRedOutBlueIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerGreenOutRedIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerGreenOutGreenIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerGreenOutBlueIn = 
			{
				overrideState = true,
				value = -200f
			},
			mixerBlueOutRedIn = 
			{
				overrideState = true,
				value = 15f
			},
			mixerBlueOutGreenIn = 
			{
				overrideState = true,
				value = 15f
			},
			mixerBlueOutBlueIn = 
			{
				overrideState = true,
				value = 200f
			}
		});
		return postProcessProfile;
	}
}

using Assets.Sources.Framework;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.WorldCamera;

public class WorldCameraRenderSystem : IAfterPredicationSystem
{
	private readonly WorldCameraContext _context;

	private float fov;

	private float timer;

	private SSJJPostProcess _ssjjPostProcess;

	private PlayerContext _playerEntity;

	public WorldCameraRenderSystem(Contexts contexts)
	{
		_context = contexts.worldCamera;
		_playerEntity = contexts.player;
	}

	public void OnAfterPredication()
	{
		if (!_context.hasCameraTransform)
		{
			return;
		}
		Camera mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;
		if (_playerEntity.myPlayerEntity != null && _playerEntity.myPlayerEntity.HasPlayerInfo(PlayerInfoStatusConstant.STAR_DEBRIS_SPECIAL_MODE.ID))
		{
			if (fov == 0f)
			{
				timer = 0f;
				fov = mainCamera.fieldOfView;
				if (_ssjjPostProcess == null)
				{
					_ssjjPostProcess = mainCamera.gameObject.AddComponent<SSJJPostProcess>();
					_ssjjPostProcess.PostProcessMaterial.SetColor("_Color0", new Color32(90, 70, 35, 1));
					_ssjjPostProcess.PostProcessMaterial.SetFloat("_lerp2", 0.15f);
				}
				else
				{
					_ssjjPostProcess.enabled = true;
				}
			}
			timer += (float)Contexts.sharedInstance.time.time.FrameInterval / 1000f;
			mainCamera.fieldOfView = Mathf.Lerp(fov, fov * 2f, timer);
			float value = Mathf.Lerp(0f, 1f, timer);
			_ssjjPostProcess.PostProcessMaterial.SetFloat("_lerp", value);
		}
		else
		{
			if (_ssjjPostProcess != null)
			{
				_ssjjPostProcess.enabled = false;
			}
			if (fov != 0f)
			{
				mainCamera.fieldOfView = fov;
				fov = 0f;
			}
			_context.unityObjects.mainCamera.fieldOfView = FovUtility.SsjjFovToUnityFov(_context.cameraTransform.Fov, Screen.width, Screen.height);
		}
		_context.unityObjects.nodeEye.transform.localEulerAngles = YawPitchUtility.SsjjYawPitchRollToUnityEularAngle(_context.cameraTransform.Yaw, _context.cameraTransform.Pitch, _context.cameraTransform.Roll);
		_context.unityObjects.nodeEye.transform.position = VectorCoordConverter.SsjjToUnity(_context.cameraTransform.position);
		if (Contexts.sharedInstance.player.myPlayerEntity != null)
		{
			if (Contexts.sharedInstance.player.myPlayerEntity.basicInfo != null && Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current != null && Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.IsThirdMode && Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.Career == "kunlungongzhu")
			{
				_context.unityObjects.mainCamera.depth = 10f;
			}
			else
			{
				_context.unityObjects.mainCamera.depth = 0f;
			}
		}
	}
}

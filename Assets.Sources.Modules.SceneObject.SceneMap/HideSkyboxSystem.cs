using Assets.Sources.Config;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class HideSkyboxSystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private WorldCameraContext _worldCameraContext;

	private bool _hideScene;

	public HideSkyboxSystem(Contexts contexts)
	{
		_worldCameraContext = contexts.worldCamera;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.Skybox, SceneObjectMatcher.SkyboxUnityObjects).NoneOf(SceneObjectMatcher.MadeInUnity));
	}

	public void OnPlayback()
	{
		if (!_worldCameraContext.hasUnityObjects)
		{
			return;
		}
		Camera mainCamera = _worldCameraContext.unityObjects.mainCamera;
		if (mainCamera == null)
		{
			return;
		}
		bool flag = GameSetting.Config.OpenSkyboxEffect != 1 || (_worldCameraContext.hasCameraEffect && _worldCameraContext.cameraEffect.HideScene);
		bool flag2 = false;
		foreach (SceneObjectEntity item in _group)
		{
			flag2 = true;
			if (item.skyboxUnityObjects.Skybox.IsActiveSelf() && flag)
			{
				item.skyboxUnityObjects.Skybox.SetObjectActive(isactive: false);
				mainCamera.clearFlags = CameraClearFlags.Color;
			}
			else if (!item.skyboxUnityObjects.Skybox.IsActiveSelf() && !flag)
			{
				item.skyboxUnityObjects.Skybox.SetObjectActive(isactive: true);
				mainCamera.clearFlags = CameraClearFlags.Depth;
			}
		}
		if (!flag2 && _worldCameraContext.hasCameraEffect && _worldCameraContext.cameraEffect.HideScene != _hideScene)
		{
			_hideScene = _worldCameraContext.cameraEffect.HideScene;
			mainCamera.clearFlags = (_hideScene ? CameraClearFlags.Color : CameraClearFlags.Depth);
		}
	}
}

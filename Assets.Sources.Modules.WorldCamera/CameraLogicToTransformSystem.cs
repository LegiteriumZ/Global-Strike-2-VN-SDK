using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.WorldCamera;

public class CameraLogicToTransformSystem : IAfterPredicationSystem
{
	private readonly WorldCameraContext _worldCameraContext;

	public CameraLogicToTransformSystem(Contexts contexts)
	{
		_worldCameraContext = contexts.worldCamera;
	}

	public void OnAfterPredication()
	{
		ICameraLogic cameraLogic = _worldCameraContext.cameraLogic.CameraLogic;
		if (cameraLogic != null)
		{
			_worldCameraContext.cameraMode.Mode = cameraLogic.CameraMode();
			_worldCameraContext.cameraTransform.Fov = cameraLogic.Fov();
			_worldCameraContext.cameraTransform.Pitch = cameraLogic.Pitch();
			_worldCameraContext.cameraTransform.Roll = cameraLogic.Roll();
			_worldCameraContext.cameraTransform.Yaw = cameraLogic.Yaw();
			_worldCameraContext.cameraTransform.position = cameraLogic.Position();
		}
	}
}

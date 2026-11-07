using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Framework;
using SSJJBase.Manager;

namespace Assets.Sources.Modules.WorldCamera;

public class CameraLogicUpdateSystem : IAfterPredicationSystem
{
	private readonly PlayerContext _playerContext;

	private readonly WorldCameraContext _worldCameraContext;

	public CameraLogicUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_worldCameraContext = contexts.worldCamera;
	}

	public void OnAfterPredication()
	{
		if (_playerContext.cameraOwnerEntity == null)
		{
			return;
		}
		bool flag = false;
		foreach (ICameraLogic cameraLogic in BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList)
		{
			if (cameraLogic.IsActive())
			{
				if (_worldCameraContext.cameraLogic.CameraLogic != cameraLogic)
				{
					cameraLogic.ReActive();
				}
				cameraLogic.Update();
				_worldCameraContext.cameraLogic.CameraLogic = cameraLogic;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			_worldCameraContext.cameraLogic.CameraLogic = null;
		}
	}
}

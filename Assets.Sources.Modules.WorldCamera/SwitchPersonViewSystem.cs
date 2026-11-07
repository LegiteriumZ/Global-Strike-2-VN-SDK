using Assets.Sources.Framework;
using SSJJBase.Constant;

namespace Assets.Sources.Modules.WorldCamera;

public class SwitchPersonViewSystem : IAfterPredicationSystem
{
	private PlayerContext _playerContext;

	private WorldCameraContext _worldCameraContext;

	public SwitchPersonViewSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_worldCameraContext = contexts.worldCamera;
	}

	public void OnAfterPredication()
	{
		SetHideFlag();
	}

	private void SetHideFlag()
	{
		foreach (PlayerEntity item in _playerContext.GetGroup(PlayerMatcher.EntityId))
		{
			if (item.isCameraOwner)
			{
				SetCameraFlags(item);
			}
			else
			{
				ClearCameraFlags(item);
			}
		}
	}

	private static void ClearCameraFlags(PlayerEntity playerEntity)
	{
		playerEntity.isThirdPersonView = true;
		playerEntity.isFirstPersonView = false;
	}

	private void SetCameraFlags(PlayerEntity playerEntity)
	{
		if (_worldCameraContext.cameraMode.Mode == PlayerCameraModeEnum.Third)
		{
			playerEntity.isFirstPersonView = false;
			playerEntity.isThirdPersonView = true;
		}
		else
		{
			playerEntity.isFirstPersonView = true;
			playerEntity.isThirdPersonView = false;
		}
	}
}

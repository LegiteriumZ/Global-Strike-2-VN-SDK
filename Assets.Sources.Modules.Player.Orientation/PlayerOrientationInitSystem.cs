using Assets.Sources.Components.Common;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerOrientationInitSystem : PredicationInitSystemBase<OrientationComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	public override OrientationComponent CurrentComponent => _playerContext.predictionEntity.orientation;

	public PlayerOrientationInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override void GetComponentFromSnapshot(OrientationComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private static void InitComponent(OrientationComponent comp, PlayerEntity player)
	{
		comp.Pitch = player.basicInfo.Current.ViewPitch;
		comp.Yaw = player.basicInfo.Current.ViewYaw;
		comp.MoveYaw = player.basicInfo.Current.MoveYaw;
		comp.ActThirdMoveInterYaw = player.basicInfo.Current.ActThirdMoveInterYaw;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isPrediction && item.hasOrientation)
			{
				InitComponent(item.orientation, item);
			}
		}
	}
}

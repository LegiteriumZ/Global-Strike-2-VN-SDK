using Assets.Sources.Components.Player;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerPunchOrientationInitSystem : PredicationInitSystemBase<PunchOrientationComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	public override PunchOrientationComponent CurrentComponent => _playerContext.predictionEntity.punchOrientation;

	public PlayerPunchOrientationInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override void GetComponentFromSnapshot(PunchOrientationComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private static void InitComponent(PunchOrientationComponent comp, PlayerEntity player)
	{
		comp.PunchPitch = player.basicInfo.Current.PunchPitch;
		comp.PunchYaw = player.basicInfo.Current.PunchYaw;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isPrediction && item.hasPunchOrientation)
			{
				InitComponent(item.punchOrientation, item);
			}
		}
	}
}

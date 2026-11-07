using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerDecayInitSystem : PredicationInitSystemBase<DecayComponent>
{
	private readonly PlayerContext _playerContext;

	public override DecayComponent CurrentComponent => _playerContext.predictionEntity.decay;

	public PlayerDecayInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override void GetComponentFromSnapshot(DecayComponent comp)
	{
		PlayerEntityData current = _playerContext.predictionEntity.basicInfo.Current;
		comp.DecayTime = current.DecayTime;
	}
}

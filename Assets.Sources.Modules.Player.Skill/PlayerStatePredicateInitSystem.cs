using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerStatePredicateInitSystem : PredicationInitSystemBase<StateComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public override StateComponent CurrentComponent => _playerContext.predictionEntity.state;

	public PlayerStatePredicateInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = _playerContext.GetGroup(PlayerMatcher.State);
	}

	public override void GetComponentFromSnapshot(StateComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private void InitComponent(StateComponent comp, PlayerEntity player)
	{
		comp.StateFlag = player.basicInfo.Current.PlayerStateFlag;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.state, item);
			}
		}
	}
}

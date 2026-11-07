using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Dead;

public class PlayerLifePredicationInitSystem : PredicationInitSystemBase<LifeComponent>, IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public override LifeComponent CurrentComponent => _playerContext.myPlayerEntity.life;

	public PlayerLifePredicationInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = _playerContext.GetGroup(PlayerMatcher.Life);
	}

	public override void GetComponentFromSnapshot(LifeComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	private static void InitComponent(LifeComponent comp, PlayerEntity player)
	{
		comp.IsDead = player.basicInfo.Current.IsDead;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.life, item);
			}
		}
	}
}

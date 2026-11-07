using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.AttackInfo;

public class PlayerAttackInfoEffectDestorySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	public PlayerAttackInfoEffectDestorySystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerAttackEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerAttackEffect.TargetId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else if (entityWithEntityId.IsDead())
			{
				item.isDestroy = true;
			}
			else if (!entityWithEntityId.HasStatus(item.playerAttackEffect.StateId))
			{
				item.isDestroy = true;
			}
		}
	}
}

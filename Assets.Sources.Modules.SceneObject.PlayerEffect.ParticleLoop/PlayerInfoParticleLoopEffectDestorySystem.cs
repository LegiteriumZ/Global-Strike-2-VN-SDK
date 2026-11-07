using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.ParticleLoop;

public class PlayerInfoParticleLoopEffectDestorySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	public PlayerInfoParticleLoopEffectDestorySystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerParticleLoopEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerParticleLoopEffect.TargetId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else if (entityWithEntityId.IsDead())
			{
				item.isDestroy = true;
			}
			else if (!entityWithEntityId.HasStatus(item.playerParticleLoopEffect.StateId))
			{
				item.isDestroy = true;
			}
		}
	}
}

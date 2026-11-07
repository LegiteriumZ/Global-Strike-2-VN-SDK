using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.ShowBodyEffect;

public class ShowBodyEffectDestorySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	public ShowBodyEffectDestorySystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.ShowBodyEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.showBodyEffect.OwnerId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else if (entityWithEntityId.IsDead())
			{
				item.isDestroy = true;
			}
		}
	}
}

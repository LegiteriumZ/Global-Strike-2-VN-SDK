using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerTitleEffectExpireDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	public PlayerTitleEffectExpireDestroySystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerTitleEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerTitleEffect.TargetId);
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

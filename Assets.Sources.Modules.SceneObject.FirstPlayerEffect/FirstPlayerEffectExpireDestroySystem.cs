using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.SceneObject.FirstPlayerEffect;

public class FirstPlayerEffectExpireDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	public FirstPlayerEffectExpireDestroySystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.FirstPlayerEffect));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.firstPlayerEffect.TargetId);
			if (entityWithEntityId == null || !item.firstPlayerEffect.EffectInfo.IsEffectOn(entityWithEntityId, _battleRoomAdapter))
			{
				item.isDestroy = true;
				this.DebugFormat("Expire Destroy firstPlayerEffect {0}", item.playerEffectId);
			}
		}
	}
}

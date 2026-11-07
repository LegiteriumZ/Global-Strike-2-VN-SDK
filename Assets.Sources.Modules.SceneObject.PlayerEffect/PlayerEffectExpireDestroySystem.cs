using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerEffectExpireDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	public PlayerEffectExpireDestroySystem(Contexts contexts)
	{
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerEffect.TargetId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else if (entityWithEntityId.IsDead() && !item.playerEffect.EffectInfo.IsEffectOnPlayerDead())
			{
				int lifeTimeWhenTargetDead = item.playerEffect.EffectInfo.GetLifeTimeWhenTargetDead();
				if (lifeTimeWhenTargetDead > 0)
				{
					item.ReplaceLifeTime(DateTime.Now, lifeTimeWhenTargetDead);
				}
				else
				{
					item.isDestroy = true;
				}
			}
			else if (!item.playerEffect.EffectInfo.IsEffectOn(entityWithEntityId, _battleRoomAdapter))
			{
				item.isDestroy = true;
			}
			if (item.isDestroy && item.hasUnityObjects && item.unityObjects.LoadResults != null && item.unityObjects.LoadResults.ContainsKey(0))
			{
				LodUtility.RemoveInstanceLod(item.unityObjects.LoadResults[0].GameObject);
			}
		}
	}
}

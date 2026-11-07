using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerStateEffectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _effectGroup;

	private readonly TimeContext _timeContext;

	private readonly IBattleRoom _battleRoomAdapter;

	private readonly PlayerContext _playerContext;

	public PlayerStateEffectRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerEffect.TargetId);
			if (entityWithEntityId != null && item.hasPlayerEffectRender)
			{
				IPlayerEffectRender render = item.playerEffectRender.Render;
				render.Render(_timeContext.time.FrameInterval, entityWithEntityId, _battleRoomAdapter);
				render.Update(_timeContext.time.FrameInterval, entityWithEntityId, item, _battleRoomAdapter);
			}
		}
	}
}

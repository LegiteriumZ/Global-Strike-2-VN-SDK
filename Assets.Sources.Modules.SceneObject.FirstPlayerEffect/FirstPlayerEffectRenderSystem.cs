using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.FirstPlayerEffect;

public class FirstPlayerEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private TimeContext _timeContext;

	private IBattleRoom _battleRoomAdapter;

	private PlayerContext _playerContext;

	public FirstPlayerEffectRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.FirstPlayerEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.firstPlayerEffect.TargetId);
			if (entityWithEntityId != null)
			{
				if (item.hasFirstPlayerEffectRender)
				{
					IFirstPlayerEffectRender render = item.firstPlayerEffectRender.Render;
					render.Render(_timeContext.time.FrameInterval, entityWithEntityId, _battleRoomAdapter);
					item.position.Origin = render.GetOffset(entityWithEntityId, _battleRoomAdapter);
					item.scale.Scale = render.GetScale(entityWithEntityId, _battleRoomAdapter);
				}
				Vector3 inv = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()) + item.position.Origin;
				Vector3 scale = item.scale.Scale;
				GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
				gameObject.transform.position = VectorCoordConverter.SsjjToUnity(inv);
				gameObject.transform.localScale = VectorCoordConverter.SsjjScaleToUnity(scale);
			}
		}
	}
}

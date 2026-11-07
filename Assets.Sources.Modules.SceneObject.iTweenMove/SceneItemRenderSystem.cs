using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Npc;
using Entitas;
using SSJJAnim.Animator;
using SSJJMath;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class SceneItemRenderSystem : IRenderSystem
{
	private BattleRoomContext _contexts;

	private IGroup<SceneObjectEntity> _group;

	private TimeComponent _time;

	public SceneItemRenderSystem(Contexts contexts)
	{
		_contexts = contexts.battleRoom;
		_time = contexts.time.time;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove, SceneObjectMatcher.SceneItemUnity, SceneObjectMatcher.Position, SceneObjectMatcher.Rotation));
	}

	private void SetEntity(SceneObjectEntity entity)
	{
		entity.sceneItemUnity.Container.transform.position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		entity.sceneItemUnity.Container.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
		if (_contexts.gameStateEntity.hasEntityStatus && _contexts.gameStateEntity.entityStatus.StatusDictionary.ContainsKey(entity.entityId.Value))
		{
			foreach (KeyValuePair<int, string> item in _contexts.gameStateEntity.entityStatus.StatusDictionary[entity.entityId.Value])
			{
				int key = item.Key;
				if (key == 1)
				{
					entity.isOutline = "true" == item.Value;
				}
			}
		}
		if (entity.hasSJAnim)
		{
			(entity.sJAnim.sjAnim as SJAnimator).PlayAtFixedTime(0, AbstractBattlePetInfo.GetAnimName(null, entity.iTweenMove.Data.Anim, 0), (float)entity.sJAnim.playTime / 1000f, 1f, isLoop: true);
			entity.sJAnim.playTime += _time.FrameInterval;
		}
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			SetEntity(item);
		}
	}
}

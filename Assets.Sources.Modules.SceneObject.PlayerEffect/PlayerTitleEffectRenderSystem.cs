using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Free.Const;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerTitleEffectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _effectGroup;

	private readonly TimeContext _timeContext;

	private readonly IBattleRoom _battleRoomAdapter;

	private readonly PlayerContext _playerContext;

	public PlayerTitleEffectRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_playerContext = contexts.player;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerTitleEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.playerTitleEffect.TargetId);
			if (entityWithEntityId == null || entityWithEntityId.isMyPlayer || item.unityObjects.LoadResults.Count <= 0)
			{
				continue;
			}
			GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
			if (!(gameObject == null))
			{
				Vector3 position = VectorCoordConverter.SsjjToUnity(entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()));
				if (item.playerTitleEffect.viewHeightTop)
				{
					float num = 0f;
					Vector3 one = Vector3.one;
					int fov = (Contexts.sharedInstance.player.isCameraOwner ? Contexts.sharedInstance.player.cameraOwnerEntity.fov.Fov : 90);
					num = UpdateScaleV(Contexts.sharedInstance.worldCamera.cameraTransform.position, entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()), 400);
					one = UpdateScale(fov, one, num);
					gameObject.transform.localScale = one;
					position.y += (float)PlayerCareerUtil.GetCareerHeight(entityWithEntityId.GetCareer()) + 15f + one.x * 28f;
				}
				gameObject.transform.position = position;
			}
		}
	}

	protected Vector3 UpdateScale(int fov, Vector3 obj_scale, float scale)
	{
		if (90 == fov)
		{
			obj_scale = scale * obj_scale;
		}
		else if (40 == fov)
		{
			obj_scale = scale * obj_scale * FOVConstant.AWP_FOV1_SCALE_Result;
		}
		else if (10 == fov)
		{
			obj_scale = scale * obj_scale * FOVConstant.AWP_FOV2_SCALE_Result;
		}
		else if (55 == fov)
		{
			obj_scale = scale * obj_scale * FOVConstant.AUG_FOV1_SCALE_Result;
		}
		return obj_scale;
	}

	protected float UpdateScaleV(Vector3 viewOrg, Vector3 pos, int distanceSacle = 200)
	{
		return Vector3.Distance(pos, viewOrg) / (float)distanceSacle;
	}
}

using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.AttackInfo;

public class PlayerAttackInfoEffectPlayBackSystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private PlayerContext _playerContext;

	public PlayerAttackInfoEffectPlayBackSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerAttackEffect, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			if (item.unityObjects.LoadResults.Count <= 0)
			{
				continue;
			}
			int targetId = item.playerAttackEffect.TargetId;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(targetId);
			int num = 0;
			if (_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.hasEntityId)
			{
				num = _playerContext.myPlayerEntity.entityId.Value;
			}
			if (entityWithEntityId != null && entityWithEntityId.hasFpos)
			{
				GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
				VectorCoordConverter.SsjjToUnity(new Vector3
				{
					x = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).x,
					y = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).y,
					z = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).z + ViewHeightUtility.GetViewHeight(entityWithEntityId)
				}, out var dest);
				gameObject.transform.position = dest;
				gameObject.transform.eulerAngles = YawPitchUtility.SsjjYawToUnityEularAngle(entityWithEntityId.orientation.Yaw + entityWithEntityId.punchSmooth.TempPunchYaw) + YawPitchUtility.SsjjPitchToUnityEularAngle(entityWithEntityId.orientation.Pitch + entityWithEntityId.punchSmooth.TempPunchPitch);
				bool isactive = true;
				if (num != targetId && entityWithEntityId.hasSkill && entityWithEntityId.skill.getStealthAlpha() < 1f && !entityWithEntityId.HasStatus(PlayerInfoStatusConstant.InSlime.ID) && !entityWithEntityId.HasStatus(PlayerInfoStatusConstant.InSlime_NEON.ID) && !entityWithEntityId.HasStatus(PlayerInfoStatusConstant.InSlime_GALAXY.ID) && (entityWithEntityId.HasStatus(PlayerInfoStatusConstant.Bio_Attack.ID) || entityWithEntityId.HasStatus(PlayerInfoStatusConstant.BioMoving.ID) || entityWithEntityId.HasStatus(PlayerInfoStatusConstant.BioJumping.ID)))
				{
					isactive = false;
				}
				gameObject.SetObjectActive(isactive);
			}
		}
	}
}

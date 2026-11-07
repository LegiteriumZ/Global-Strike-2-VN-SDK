using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public abstract class AbstractPlayerEffectRender : IPlayerEffectRender
{
	protected GameObject EffectObject;

	private int FrameTime;

	public int AttachTime { get; set; }

	public virtual void Init(PlayerEntity player, GameObject effectGameObject)
	{
		EffectObject = effectGameObject;
	}

	public virtual Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return Vector3.zero;
	}

	public virtual Vector3 GetScale(PlayerEntity targetPlayer, SceneObjectEntity effectEntity, IBattleRoom battleRoom)
	{
		if (effectEntity.scale.Scale != Vector3.zero)
		{
			return effectEntity.scale.Scale;
		}
		return Vector3.one;
	}

	public abstract void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom);

	protected float GetHeight(PlayerEntity targetPlayer)
	{
		return PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer());
	}

	protected virtual int GetLifeTime()
	{
		return -1;
	}

	protected virtual void Reset(PlayerEntity player)
	{
	}

	public virtual void Update(int frameTime, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room)
	{
		FrameTime = frameTime;
		if (effectEntity.unityObjects.LoadResults.Count <= 0)
		{
			return;
		}
		bool flag = true;
		if (!effectEntity.playerEffect.EffectInfo.IsThirdEffectAlwaysDisplay())
		{
			flag = player.hasThirdPersonUnityObjects && player.thirdPersonUnityObjects.ThirdTran.RootContainer.IsActiveSelf();
			if (effectEntity.playerEffect.EffectInfo.IsThirdEffectHide())
			{
				flag = false;
			}
		}
		if (effectEntity.playerEffect.EffectInfo.IsFirstEffectHide())
		{
			flag = !player.hasFirstPersonUnityObjects || !player.firstPersonUnityObjects.HandCameraObject.IsActiveSelf();
		}
		if (effectEntity.playerEffect.EffectInfo.IsFirstEffectAlwaysDisplay() && player.hasFirstPersonUnityObjects && player.firstPersonUnityObjects.HandCameraObject.IsActiveSelf())
		{
			flag = true;
		}
		if (player.hasSkill && Mathf.Approximately(player.skill.getStealthAlpha(), 0f) && !player.HasStatus(PlayerInfoStatusConstant.ACG_SERIOUS_INJURY_FLAG.ID) && !player.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) && !player.HasStatus(PlayerInfoStatusConstant.THUNDER_SHOTGUN_THUNDER_STATE.ID) && !player.HasStatus(10160098) && !player.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID) && !player.HasStatus(PlayerInfoStatusConstant.HideBody.ID))
		{
			flag = false;
		}
		if (player.hasSkill && player.skill.getStealthAlpha() < 1f && !player.HasStatus(PlayerInfoStatusConstant.InSlime.ID) && !player.HasStatus(PlayerInfoStatusConstant.InSlime_NEON.ID) && !player.HasStatus(PlayerInfoStatusConstant.InSlime_GALAXY.ID) && (player.HasStatus(PlayerInfoStatusConstant.Bio_Attack.ID) || player.HasStatus(PlayerInfoStatusConstant.BioMoving.ID) || player.HasStatus(PlayerInfoStatusConstant.BioJumping.ID)))
		{
			flag = false;
		}
		if (EffectObject != null)
		{
			if (EffectObject.activeSelf != flag)
			{
				EffectObject.SetActive(flag);
			}
			if (flag)
			{
				PlayerVolumeConfig.ConfigData config = default(PlayerVolumeConfig.ConfigData);
				bool autosize = InAutoSize(EffectObject, player, effectEntity, out config);
				UpdatePosition(EffectObject, player, effectEntity, room, autosize, ref config);
				UpdateRotation(EffectObject, player, effectEntity, room, autosize, ref config);
				UpdateScale(EffectObject, player, effectEntity, room, autosize, ref config);
			}
		}
		AttachTime += frameTime;
		if (GetLifeTime() > 0 && AttachTime > GetLifeTime())
		{
			Reset(player);
		}
	}

	private bool InAutoSize(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, out PlayerVolumeConfig.ConfigData config)
	{
		if (!effectEntity.hasParticleFlag)
		{
			effectEntity.AddParticleFlag(effectObject.GetComponentInChildren<PaticlePrefabInstancecs>(includeInactive: true) != null);
		}
		config = default(PlayerVolumeConfig.ConfigData);
		if (player != null)
		{
			if (effectEntity.particleFlag.HasParticle && !ParticleManager.Instance().GetVolumeConfigData(player.basicInfo.CareerInfo.Name, out config))
			{
				return false;
			}
			return effectEntity.playerEffect.EffectInfo.IsAutoSize();
		}
		return false;
	}

	protected virtual void UpdatePosition(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
		IPlayerEffectInfo effectInfo = effectEntity.playerEffect.EffectInfo;
		Vector3 zero = Vector3.zero;
		if (!autosize)
		{
			zero = GetOffset(player, room);
			if (effectInfo is CommonPlayerStatusEffectInfo && player.hasThirdPersonUnityObjects)
			{
				if (effectInfo.GetConfigViewHeight(player) != 0)
				{
					zero.z = (float)(PlayerCareerConstantUtility.GetHeight(player.GetCareer()) * 2) / 3f;
				}
				if (effectInfo.GetConfigViewHeightTop(player) != 0)
				{
					zero.z = PlayerCareerConstantUtility.GetHeight(player.GetCareer());
				}
				if (!string.IsNullOrEmpty(effectInfo.GetJointName()))
				{
					GameObject joint = effectEntity.playerEffect.Joint;
					if (joint == null)
					{
						Transform bone = player.thirdPersonUnityObjects.Animator.GetBone(effectInfo.GetJointName());
						if (bone != null)
						{
							joint = bone.gameObject;
							effectEntity.playerEffect.Joint = joint;
						}
					}
				}
			}
		}
		else
		{
			zero = config.Position;
			if (!string.IsNullOrEmpty(config.Root) && effectEntity.playerEffect.Joint == null)
			{
				Transform bone2 = player.thirdPersonUnityObjects.Animator.GetBone(config.Root);
				if (bone2 != null)
				{
					effectEntity.playerEffect.Joint = bone2.gameObject;
				}
			}
		}
		GameObject joint2 = effectEntity.playerEffect.Joint;
		if (joint2 != null)
		{
			Vector3 configOffset = effectInfo.GetConfigOffset(player);
			effectObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(configOffset + zero) + joint2.transform.position;
			return;
		}
		Vector3 configOffset2 = effectInfo.GetConfigOffset(player);
		if (effectInfo is CommonPlayerStatusEffectInfo)
		{
			float num = (effectInfo as CommonPlayerStatusEffectInfo).NeedUpCorrect();
			if (num != -1f)
			{
				configOffset2.z -= num * (effectEntity.scale.Scale.x - 1f);
			}
		}
		effectObject.transform.position = VectorCoordConverter.SsjjToUnity(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()) + configOffset2 + zero);
	}

	protected virtual void UpdateRotation(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
		IPlayerEffectInfo effectInfo = effectEntity.playerEffect.EffectInfo;
		if (effectInfo is CommonPlayerStatusEffectInfo && player.hasThirdPersonUnityObjects)
		{
			GameObject joint = effectEntity.playerEffect.Joint;
			if (joint != null)
			{
				effectObject.transform.rotation = Quaternion.LookRotation(joint.transform.TransformDirection(-Vector3.right), joint.transform.forward);
			}
			else if (player.hasThirdPersonUnityObjects)
			{
				Vector3 configRotation = effectInfo.GetConfigRotation(player);
				if (effectEntity.hasParticleLerpRotation && effectEntity.particleLerpRotation != null)
				{
					lerpMirrorRotation(effectEntity);
					configRotation.y += effectEntity.particleLerpRotation.nowRotation * 30f;
				}
				effectObject.transform.eulerAngles = configRotation;
			}
		}
		if (autosize)
		{
			Vector3 rotation = config.Rotation;
			rotation = VectorCoordConverter.SsjjRotationToUnity(rotation);
			effectObject.transform.rotation = effectObject.transform.rotation * Quaternion.Euler(rotation);
		}
	}

	private void lerpMirrorRotation(SceneObjectEntity effectEntity)
	{
		float nowRotation = effectEntity.particleLerpRotation.nowRotation;
		float nextRotation = effectEntity.particleLerpRotation.nextRotation;
		if ((double)Mathf.Abs(nowRotation - nextRotation) < 1E-05)
		{
			return;
		}
		float num = (float)FrameTime / 1000f * 2f;
		if (nextRotation - nowRotation > 0f)
		{
			nowRotation += num;
			if (nowRotation > nextRotation)
			{
				nowRotation = nextRotation;
			}
		}
		else
		{
			nowRotation -= num;
			if (nowRotation < nextRotation)
			{
				nowRotation = nextRotation;
			}
		}
		effectEntity.ReplaceParticleLerpRotation(nowRotation, nextRotation);
	}

	protected void UpdateScale(GameObject effectObject, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room, bool autosize, ref PlayerVolumeConfig.ConfigData config)
	{
		effectEntity.scale.Scale = GetScale(player, effectEntity, room);
		if (effectEntity.playerEffect.EffectInfo.IsSmallMirror())
		{
			PaticlePrefabInstancecs component = effectObject.GetComponent<PaticlePrefabInstancecs>();
			if (component != null)
			{
				component.SetAlpha(effectEntity.scale.Scale.x);
			}
			float nowRotation = effectEntity.particleLerpRotation.nowRotation;
			float num = 1.2f - Mathf.Abs(nowRotation) * 0.2f;
			Vector3 localScale = effectObject.transform.localScale;
			localScale.Set(num, num, num);
			effectObject.transform.localScale = localScale;
		}
		else if (autosize)
		{
			Vector3 scale = config.Scale;
			scale = VectorCoordConverter.SsjjScaleToUnity(Vector3.Scale(effectEntity.scale.Scale, scale));
			effectObject.transform.localScale = scale;
		}
		else
		{
			float scaleX = effectEntity.playerEffect.EffectInfo.GetScaleX();
			float effectScale = effectEntity.playerEffect.EffectInfo.GetEffectScale();
			Vector3 scale2 = effectEntity.scale.Scale;
			if (scaleX == 1f)
			{
				scale2.x *= effectScale;
			}
			else
			{
				scale2.x *= scaleX;
			}
			scale2.y *= effectScale;
			scale2.z *= effectScale;
			effectObject.transform.localScale = VectorCoordConverter.SsjjScaleToUnity(scale2);
		}
	}
}

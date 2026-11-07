using Assets.Sources.Components.Interface.Info.MoveObject;
using Assets.Sources.Info.Res;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

public abstract class AbstractMoveObjectInfo : IMoveObjectInfo
{
	public float YawTrim;

	public float PitchTrim;

	public bool viewAttach;

	public float viewAttachX;

	public float viewAttachY;

	public float viewAttachZ;

	public bool viewFollowYaw;

	public bool viewFollowPitch;

	public bool IsHide;

	private bool _setParticleSimulate;

	public virtual void InitEntity(SceneObjectEntity entity)
	{
		AssetInfo info = default(AssetInfo);
		MoveEntityData current = entity.moveObject.Current;
		_setParticleSimulate = false;
		if (GetAssetInfo(current, ref info))
		{
			entity.AddLoadUnityObjects(new LoadRequests(info), current.Name);
		}
		else
		{
			this.LogErrorFormat("Unknow MoveEntity Name:{0}", current.Name);
		}
		MoveEntityTailConfig moveEntityTailConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetMoveEntityTailConfig(current.Name);
		if (moveEntityTailConfig != null)
		{
			SceneObjectFactory.Instance.CreateTrail(entity, moveEntityTailConfig.RemainTime, moveEntityTailConfig.Width, moveEntityTailConfig.ResIndex, moveEntityTailConfig.Info, moveEntityTailConfig.FadeStart, moveEntityTailConfig.TrailTime);
		}
	}

	private void SetMoveParticleSimulate(GameObject obGameObject)
	{
		if (_setParticleSimulate)
		{
			return;
		}
		_setParticleSimulate = true;
		if (obGameObject == null)
		{
			return;
		}
		ParticleSystem[] componentsInChildren = obGameObject.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			if (!(particleSystem == null))
			{
				bool flag = particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World;
				bool flag2 = particleSystem.GetComponent<ParticleSystemRenderer>().renderMode == ParticleSystemRenderMode.Mesh;
				if (flag && flag2)
				{
					ParticleSystem.MainModule main = particleSystem.main;
					main.simulationSpace = ParticleSystemSimulationSpace.Local;
				}
			}
		}
	}

	public virtual void RenderEntity(SceneObjectEntity entity)
	{
		if (IsHide)
		{
			return;
		}
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		SetMoveParticleSimulate(gameObject);
		if (gameObject.IsActiveSelf() == IsHide)
		{
			gameObject.SetObjectActive(!IsHide);
			SetParticleScale(gameObject);
		}
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
		gameObject.transform.position = dest;
		gameObject.transform.localEulerAngles = localEulerAngles;
		gameObject.transform.localScale = entity.scale.Scale;
		if (viewAttach && entity.moveObject.Current.Cid == Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.CharacterId)
		{
			Transform transform = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform;
			Vector3 eulerAngles = transform.eulerAngles;
			if (!viewFollowYaw)
			{
				eulerAngles.y = 0f;
			}
			if (!viewFollowPitch)
			{
				eulerAngles.x = 0f;
			}
			Vector3 vector = Quaternion.Euler(eulerAngles) * (Vector3.forward * viewAttachX + Vector3.left * viewAttachY + Vector3.up * viewAttachZ);
			gameObject.transform.position = transform.position + vector;
			gameObject.transform.localEulerAngles = eulerAngles;
		}
	}

	protected void SetParticleScale(GameObject effectObject)
	{
		Component[] componentsInChildren = effectObject.GetComponentsInChildren<Component>(includeInactive: true);
		foreach (Component component in componentsInChildren)
		{
			if (!(component == null) && component is ParticleSystem)
			{
				ParticleSystem.MainModule main = (component as ParticleSystem).main;
				main.scalingMode = ParticleSystemScalingMode.Hierarchy;
			}
		}
	}

	public virtual bool GetAssetInfo(MoveEntityData data, ref AssetInfo info)
	{
		MoveEntityEffectData moveEntityEffectData = ParticleManager.Instance().GetMoveEntityEffectData(data.Name);
		if (moveEntityEffectData != null)
		{
			YawTrim = moveEntityEffectData.YawTrim;
			PitchTrim = moveEntityEffectData.PitchTrim;
			viewAttach = moveEntityEffectData.viewAttach;
			viewAttachX = moveEntityEffectData.viewAttachX;
			viewAttachY = moveEntityEffectData.viewAttachY;
			viewAttachZ = moveEntityEffectData.viewAttachZ;
			viewFollowYaw = moveEntityEffectData.viewFollowYaw;
			viewFollowPitch = moveEntityEffectData.viewFollowPitch;
			info.AssetName = moveEntityEffectData.AssetInfo.AssetName;
			info.BundleName = moveEntityEffectData.AssetInfo.BundleName;
			return true;
		}
		MoveEntityConfig moveEntityConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetMoveEntityConfig(data.Name);
		if (moveEntityConfig != null)
		{
			info.AssetName = moveEntityConfig.Info.AssetName;
			info.BundleName = moveEntityConfig.Info.BundleName;
			return true;
		}
		CommonParticleResConfig defaultParticleResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultParticleResConfig(data.Name);
		if (defaultParticleResConfig != null && defaultParticleResConfig.Type.Equals("move"))
		{
			this.Info("Use Default CommonResParticle : " + data.Name);
			YawTrim = defaultParticleResConfig.YawTrim;
			PitchTrim = defaultParticleResConfig.PitchTrim;
			info.AssetName = defaultParticleResConfig.Info.AssetName;
			info.BundleName = defaultParticleResConfig.Info.BundleName;
			return true;
		}
		return false;
	}
}

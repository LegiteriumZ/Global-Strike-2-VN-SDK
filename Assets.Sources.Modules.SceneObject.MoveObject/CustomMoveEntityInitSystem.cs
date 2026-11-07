using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

public class CustomMoveEntityInitSystem : IPlaybackInitSystem
{
	private readonly SceneObjectContext _sceneObjectContext;

	private readonly SnapshotContext _snapshotContext;

	private readonly IGroup<SceneObjectEntity> _moveObjects;

	public float YawTrim;

	public float PitchTrim;

	public CustomMoveEntityInitSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_moveObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.CustomMoveEntity).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, CustomMoveEntityData> item in nowSnapshot.CustomMoveEntityDataDict)
		{
			CustomMoveEntityData value = item.Value;
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(value.Id);
			if (entityWithEntityId == null)
			{
				entityWithEntityId = _sceneObjectContext.CreateEntity();
				entityWithEntityId.AddEntityId(value.Id);
				entityWithEntityId.AddEtype(23);
				entityWithEntityId.AddPosition(Vector3.zero);
				entityWithEntityId.AddRotation(Vector3.zero);
				if (value.Scale > 0f)
				{
					entityWithEntityId.AddScale(new Vector3(value.Scale, value.Scale, value.Scale));
				}
				else
				{
					entityWithEntityId.AddScale(new Vector3(1f, 1f, 1f));
				}
				entityWithEntityId.AddCustomMoveEntity(value, 0f, 0f);
				InitEntity(entityWithEntityId);
			}
		}
		foreach (SceneObjectEntity moveObject in _moveObjects)
		{
			if (!nowSnapshot.CustomMoveEntityDataDict.ContainsKey(moveObject.entityId.Value))
			{
				if (moveObject.hasAddParticleLod && moveObject.hasUnityObjects && moveObject.unityObjects.LoadResults != null && moveObject.unityObjects.LoadResults.ContainsKey(0))
				{
					LodUtility.RemoveInstanceLod(moveObject.unityObjects.LoadResults[0].GameObject);
				}
				moveObject.isDestroy = true;
			}
		}
	}

	private void InitEntity(SceneObjectEntity entity)
	{
		AssetInfo info = default(AssetInfo);
		CustomMoveEntityData data = entity.customMoveEntity.Data;
		if (GetAssetInfo(data, ref info))
		{
			entity.customMoveEntity.PitchTrim = PitchTrim;
			entity.customMoveEntity.YawTrim = YawTrim;
			entity.AddLoadUnityObjects(new LoadRequests(info), data.Name);
		}
		else
		{
			this.LogErrorFormat("Unknow MoveEntity Name:{0}", data.Name);
		}
		MoveEntityTailConfig moveEntityTailConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetMoveEntityTailConfig(data.Name);
		if (moveEntityTailConfig != null)
		{
			SceneObjectFactory.Instance.CreateTrail(entity, moveEntityTailConfig.RemainTime, moveEntityTailConfig.Width, moveEntityTailConfig.ResIndex, moveEntityTailConfig.Info, moveEntityTailConfig.FadeStart, moveEntityTailConfig.TrailTime);
		}
	}

	private bool GetAssetInfo(CustomMoveEntityData data, ref AssetInfo info)
	{
		MoveEntityEffectData moveEntityEffectData = ParticleManager.Instance().GetMoveEntityEffectData(data.Name);
		if (moveEntityEffectData != null)
		{
			YawTrim = moveEntityEffectData.YawTrim;
			PitchTrim = moveEntityEffectData.PitchTrim;
			info.AssetName = moveEntityEffectData.AssetInfo.AssetName;
			info.BundleName = moveEntityEffectData.AssetInfo.BundleName;
			return true;
		}
		MoveEntityConfig moveEntityConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetMoveEntityConfig(data.Name.ToLower());
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

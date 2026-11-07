using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.HitEffect;

public class BeingHitEffectPlaySystem : IPlaybackInitSystem
{
	private SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	private readonly IGroup<SceneObjectEntity> _hitEffectObjects;

	public BeingHitEffectPlaySystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
		_hitEffectObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.HitEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.LifeTime).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null || !_playerContext.isMyPlayer)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		foreach (KeyValuePair<int, BeingHitEventEntityData> item in nowSnapshot.BeingHitEventEntityDataDict)
		{
			BeingHitEventEntityData value = item.Value;
			int parentId = value.ParentId;
			if ((value.ParentId != value.ShootId || myPlayerEntity.entityId.Value != value.ShootId) && myPlayerEntity.entityId.Value != value.ShootId && myPlayerEntity.entityId.Value == parentId && myPlayerEntity.basicInfo.IsDead)
			{
				myPlayerEntity.ReplaceDeadCamera(new Vector3(value.BaseEventEntity.X, value.BaseEventEntity.Y, value.BaseEventEntity.Z));
			}
		}
		foreach (SceneObjectEntity hitEffectObject in _hitEffectObjects)
		{
			if (!hitEffectObject.hasAddParticleLod)
			{
				hitEffectObject.AddAddParticleLod(newIsAdd: true);
			}
			if ((DateTime.Now - hitEffectObject.lifeTime.CreateTime).TotalMilliseconds - (double)hitEffectObject.lifeTime.LifeTime > -200.0 && hitEffectObject.hasAddParticleLod && hitEffectObject.addParticleLod.IsAdd)
			{
				if (hitEffectObject.unityObjects.LoadResults.ContainsKey(0))
				{
					LodUtility.RemoveInstanceLod(hitEffectObject.unityObjects.LoadResults[0].GameObject);
				}
				hitEffectObject.addParticleLod.IsAdd = false;
			}
		}
	}
}

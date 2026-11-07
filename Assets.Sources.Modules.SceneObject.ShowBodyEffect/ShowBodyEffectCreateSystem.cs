using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.String;

namespace Assets.Sources.Modules.SceneObject.ShowBodyEffect;

public class ShowBodyEffectCreateSystem : IPlaybackInitSystem
{
	private SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	private SceneObjectContext _sceneObjectContext;

	private readonly IGroup<SceneObjectEntity> _group;

	private List<int> _removeIds = new List<int>();

	public ShowBodyEffectCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.ShowBodyEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		_removeIds.Clear();
		foreach (KeyValuePair<int, ShowBodyEffectEntityData> item in nowSnapshot.ShowBodyEffectEntityDataDict)
		{
			ShowBodyEffectEntityData value = item.Value;
			_sceneObjectContext.GetEntityWithEntityId(value.BaseEventEntity.Id);
			AttachEventEffectData attachBodyEffectData = ParticleManager.Instance().GetAttachBodyEffectData(StringCache.IntToString(value.BaseEventEntity.EventId));
			if (attachBodyEffectData != null)
			{
				if (attachBodyEffectData.IsOnlyOne)
				{
					foreach (SceneObjectEntity item2 in _group)
					{
						if (item2.showBodyEffect.OwnerId == value.BaseEventEntity.OwnerId && item2.showBodyEffect.EventId == value.BaseEventEntity.EventId)
						{
							item2.isDestroy = true;
							break;
						}
					}
				}
				if (value.Remove)
				{
					_removeIds.Add(value.BaseEventEntity.OwnerId);
					continue;
				}
				PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(value.BaseEventEntity.OwnerId);
				if (entityWithEntityId != null && !entityWithEntityId.isFirstPersonView)
				{
					SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
					if (value.RemainTime != 0)
					{
						sceneObjectEntity.AddLifeTime(DateTime.Now, value.RemainTime);
					}
					else
					{
						sceneObjectEntity.AddLifeTime(DateTime.Now, attachBodyEffectData.RemainTime);
					}
					sceneObjectEntity.AddEntityId(value.BaseEventEntity.Id);
					sceneObjectEntity.AddShowBodyEffect(value.BaseEventEntity.EventId, value.BaseEventEntity.OwnerId, value.BoneName, newIsFresh: true, value.BaseEventEntity.Pitch, value.BaseEventEntity.Yaw);
					sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(attachBodyEffectData.AssetInfo), value.BaseEventEntity.Id);
				}
			}
			else
			{
				this.LogErrorFormat("Can't Find BodyEffectDataEffect, EvendId : {0}", value.BaseEventEntity.EventId);
			}
		}
		foreach (SceneObjectEntity item3 in _group)
		{
			for (int i = 0; i < _removeIds.Count; i++)
			{
				if (_removeIds[i] == item3.showBodyEffect.OwnerId)
				{
					item3.isDestroy = true;
				}
			}
		}
	}
}

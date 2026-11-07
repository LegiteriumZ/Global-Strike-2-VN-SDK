using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.LinkObject;
using Assets.Sources.Framework;
using Assets.Sources.Info.LinkObject;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.ComponentInit;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

public class LinkObjectCreateSystem : IPlaybackInitSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly PlayerContext _playerContext;

	private readonly IGroup<SceneObjectEntity> _linkObjects;

	private readonly List<SceneObjectEntity> _removeList;

	public LinkObjectCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_playerContext = contexts.player;
		_linkObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LinkObject).NoneOf(SceneObjectMatcher.Destroy));
		_removeList = new List<SceneObjectEntity>();
	}

	private bool CheckLinkCanShow(LinkEntityData nowData)
	{
		if (nowData.LinkType2 > 0 && nowData.UsePlayerId > 0)
		{
			string playerEntityWeaponSkinName = PlayerEntityUtility.GetPlayerEntityWeaponSkinName(nowData.UsePlayerId);
			LineLinkEffectData lineLinkEffectData = ParticleManager.Instance().GetLineLinkEffectData(StringCache.IntToString(nowData.LinkType2), !string.IsNullOrEmpty(playerEntityWeaponSkinName));
			if (lineLinkEffectData != null && lineLinkEffectData.onlyView && (_playerContext.myPlayerEntity == null || _playerContext.myPlayerEntity.GetId() != nowData.UsePlayerId))
			{
				return false;
			}
		}
		return true;
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, LinkEntityData> item in nowSnapshot.LinkEntityDataDict)
		{
			LinkEntityData value = item.Value;
			if (CheckLinkCanShow(value))
			{
				nextSnapshot.LinkEntityDataDict.TryGetValue(value.Id, out var value2);
				SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
				if (sceneObjectEntity == null)
				{
					sceneObjectEntity = _sceneObjectContext.CreateEntity();
					ILinkObjectInfo linkObjectInfo = BattleSingletonInstance<LinkObjectInfoFactory>.Instance.GetLinkObjectInfo(value.LinkType, value.LinkType2);
					sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
					sceneObjectEntity.AddScale(default(Vector3));
					sceneObjectEntity.AddEntityId(value.Id);
					sceneObjectEntity.AddLinkObject(value, value2, linkObjectInfo, 0, 0, 100f, Vector3.zero, Vector3.zero);
					linkObjectInfo.InitEntity(sceneObjectEntity);
				}
				int entityName = (int)value.LinkType;
				if (value.LinkType2 > 0)
				{
					entityName = value.LinkType2;
				}
				string playerEntityWeaponSkinName = PlayerEntityUtility.GetPlayerEntityWeaponSkinName(value.UsePlayerId);
				LineLinkStartEffectData lineLinkStartEffectData = ParticleManager.Instance().GetLineLinkStartEffectData(entityName, !string.IsNullOrEmpty(playerEntityWeaponSkinName));
				if (lineLinkStartEffectData != null && !sceneObjectEntity.hasLoadExtend1Resource && !sceneObjectEntity.hasExtend1Resource && ParticleManager.Instance().TryGetParticle<EffectConfig>(lineLinkStartEffectData.EffectName, out var result))
				{
					sceneObjectEntity.AddLoadExtend1Resource(new LoadRequests(result), "start_effect_" + value.Id);
				}
				LineLinkFinishEffectData lineLinkFinishEffectData = ParticleManager.Instance().GetLineLinkFinishEffectData(entityName, !string.IsNullOrEmpty(playerEntityWeaponSkinName));
				if (lineLinkFinishEffectData != null && !sceneObjectEntity.hasLoadExtend2Resource && !sceneObjectEntity.hasExtend2Resource && ParticleManager.Instance().TryGetParticle<EffectConfig>(lineLinkFinishEffectData.EffectName, out var result2))
				{
					sceneObjectEntity.AddLoadExtend2Resource(new LoadRequests(result2), "finish_effect_" + value.Id);
				}
			}
		}
		foreach (SceneObjectEntity linkObject in _linkObjects)
		{
			if (!nowSnapshot.LinkEntityDataDict.ContainsKey(linkObject.entityId.Value))
			{
				_removeList.Add(linkObject);
				continue;
			}
			nowSnapshot.LinkEntityDataDict.TryGetValue(linkObject.entityId.Value, out var value3);
			if (linkObject.linkObject.Now.LinkType != value3.LinkType)
			{
				_removeList.Add(linkObject);
			}
		}
		foreach (SceneObjectEntity remove in _removeList)
		{
			remove.isDestroy = true;
		}
		_removeList.Clear();
	}
}

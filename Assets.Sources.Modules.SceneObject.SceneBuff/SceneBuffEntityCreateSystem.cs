using System.Collections.Generic;
using Assets.Sources.Components.Common;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Assets.SceneBuff;
using Assets.Sources.Info.Effect.SceneBufferEffect;
using Assets.Sources.Info.SceneBuffAttach;
using Assets.Sources.Utils;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneBuff;

public class SceneBuffEntityCreateSystem : IEntityCreateSystem
{
	private SnapshotContext _snapshotContext;

	private SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	private Dictionary<SceneObjectEntity, bool> _entityDestroy = new Dictionary<SceneObjectEntity, bool>();

	public SceneBuffEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneBuff));
	}

	public void OnEntityCreate()
	{
		if (_snapshotContext.snapshots.NowSnapshot == null || !_playerContext.isCameraOwner)
		{
			return;
		}
		_entityDestroy.Clear();
		foreach (SceneObjectEntity item in _group)
		{
			_entityDestroy.Add(item, value: true);
		}
		foreach (KeyValuePair<int, SceneBufEntityData> item2 in _snapshotContext.snapshots.NowSnapshot.SceneBufEntityDataDict)
		{
			SceneObjectEntity entity = _sceneObjectContext.GetEntityWithEntityId(item2.Value.Id);
			if (entity == null)
			{
				if (CreateSmallMapInfo(ref entity, item2.Value))
				{
					CreateBuffEffect(entity);
				}
			}
			else if (item2.Value.BufName == entity.sceneBuff.Data.BufName)
			{
				entity.sceneBuff.Data = EntityDataExtension.CloneSceneBufEntityData(item2.Value, entity.sceneBuff.Data);
				_entityDestroy[entity] = false;
			}
		}
		foreach (KeyValuePair<SceneObjectEntity, bool> item3 in _entityDestroy)
		{
			if (item3.Value)
			{
				if (item3.Key.hasUnityObjects && item3.Key.unityObjects.LoadResults.ContainsKey(0))
				{
					LodUtility.RemoveInstanceLod(item3.Key.unityObjects.LoadResults[0].GameObject);
				}
				item3.Key.isDestroy = true;
			}
		}
	}

	private bool CreateSmallMapInfo(ref SceneObjectEntity entity, SceneBufEntityData buffData)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		entity = _sceneObjectContext.CreateEntity();
		entity.AddEntityId(buffData.Id);
		entity.AddSceneBuff(buffData);
		ISceneBuffAssetInfo sceneBuffAssetInfo = SceneBuffAssetInfoFactory.Instance.Get(buffData.BufName);
		if (sceneBuffAssetInfo == null)
		{
			this.LogErrorFormat("Can not find scenebuff smallmap asset {0}", buffData.BufName);
		}
		else if (!string.IsNullOrEmpty(sceneBuffAssetInfo.GetSmallMapAsset(buffData.Lv).BundleName))
		{
			entity.AddComponent(13, new SmallMapImageComponent());
			entity.smallMapImage.Position = new Vector3(buffData.X, buffData.Y, buffData.Z);
			entity.smallMapImage.ScaleX = 1f;
			entity.smallMapImage.ScaleY = 1f;
			entity.smallMapImage.Alpha = 1f;
			entity.smallMapImage.RadarImage = sceneBuffAssetInfo.GetSmallMapAsset(buffData.Lv);
			entity.smallMapImage.SmallMapImage = entity.smallMapImage.RadarImage;
			entity.smallMapImage.Rotation = cameraOwnerEntity.orientation.Yaw - 90f;
			entity.smallMapImage.AddRotateSelfInRadar = sceneBuffAssetInfo.AddRotateSelf;
			entity.smallMapImage.IsHideNameAndHp = true;
			if (entity.sceneBuff.Data.BufName == "NEXT_SAFE_AREA")
			{
				entity.smallMapImage.Safe = true;
				entity.smallMapImage.Mask = 6;
				entity.smallMapImage.RealWidth = entity.sceneBuff.Data.Scale.X * 100f;
				return false;
			}
			if (entity.sceneBuff.Data.BufName == "SAFE_AREA")
			{
				entity.smallMapImage.Mask = 5;
				entity.smallMapImage.RealWidth = entity.sceneBuff.Data.Scale.X * 100f;
			}
			else if (entity.sceneBuff.Data.BufName == "CYBER_ESCAPE_AREA")
			{
				entity.smallMapImage.Name = sceneBuffAssetInfo.Name;
				entity.smallMapImage.IsShowName = true;
			}
		}
		return true;
	}

	private static string GetEffectEntityId(int playerEntityId, string effectName)
	{
		return $"{playerEntityId}@{effectName}";
	}

	private void CreateBuffEffect(SceneObjectEntity buff)
	{
		foreach (ISceneBufferEffectInfo buffEffectInfo in SceneBuffEffectInfoFactory.Instance.BuffEffectInfoList)
		{
			if (buffEffectInfo.BuffName == buff.sceneBuff.Data.BufName)
			{
				AddEffect(buff, buffEffectInfo);
				return;
			}
			if (buffEffectInfo.BuffName == "SkillBufferAssetInfo" && SceneBufTypeUtility.IsSkillBuffer(buff.sceneBuff.Data.BufName))
			{
				AddEffect(buff, buffEffectInfo);
				return;
			}
			if (buffEffectInfo.BuffName == "SkillBufferEffectInfo" && SceneBufTypeUtility.IsSkillBuffer(buff.sceneBuff.Data.BufName.ToUpper()))
			{
				AddEffect(buff, buffEffectInfo);
				return;
			}
		}
		AddEffect(buff, SceneBuffEffectInfoFactory.Instance.DefaultSceneBuffer);
	}

	private void AddEffect(SceneObjectEntity buff, ISceneBufferEffectInfo effectInfo)
	{
		EntityEffectId entityEffectId = new EntityEffectId(buff.entityId.Value, effectInfo.GetType().ToString());
		AssetInfo effectAssetInfo = effectInfo.GetEffectAssetInfo(buff.SceneBuff.Data.BufName, buff.sceneBuff.Data.AutoLoadRes);
		effectAssetInfo.AssetType = typeof(GameObject);
		if (string.IsNullOrEmpty(effectAssetInfo.AssetName.Info))
		{
			this.LogErrorFormat("Can not find scenebuff  asset {0}", buff.SceneBuff.Data.BufName);
			return;
		}
		buff.AddPosition(new Vector3(buff.sceneBuff.Data.X, buff.sceneBuff.Data.Y, buff.sceneBuff.Data.Z));
		buff.AddScale(new Vector3(buff.sceneBuff.Data.Scale.X, buff.sceneBuff.Data.Scale.Y, buff.sceneBuff.Data.Scale.Z));
		buff.AddSceneBufferEffect(buff, effectInfo);
		buff.AddLoadUnityObjects(new LoadRequests(effectAssetInfo), entityEffectId);
		AttachSceneBuff(buff.sceneBuff.Data.BufName, buff);
	}

	private void AttachSceneBuff(string bufferName, SceneObjectEntity buff)
	{
		ISceneBuffAttach buffAttach = SingletonInstance<SceneBufferAttachFactory>.Instance.GetBuffAttach(bufferName);
		if (buffAttach != null)
		{
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddSceneBuffAttach(buff.entityId.Value, buffAttach, null);
			sceneObjectEntity.AddPosition(new Vector3(buff.sceneBuff.Data.X, buff.sceneBuff.Data.Y, buff.sceneBuff.Data.Z));
			sceneObjectEntity.AddScale(Vector3.one);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(buffAttach.GetEffectAssetInfo()), bufferName);
		}
	}
}

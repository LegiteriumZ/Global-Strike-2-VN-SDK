using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJMath;
using SSJJSceneLoader;
using Sharpen;
using UnityEngine;
using share;

namespace Assets.Sources.Modules.SceneObject;

public class SceneObjectFactory
{
	public const int BOW_RAIL_TYPE = 22;

	private static SceneObjectFactory _instance;

	private readonly Marks _marks;

	private readonly IGroup<SceneObjectEntity> _mapGroup;

	public bool CollectBulletHoleDebugInfo;

	private readonly AssetInfo _attackPlayerAssetInfo = new AssetInfo("sound/kill", "Assets/Res/Assets/sound/kill/attackplayer.mp3");

	private static readonly int[] Excepts = new int[15]
	{
		1, 11, 59, 47, 79, 33, 36, 54, 37, 69,
		106, 67, 90, 1141, 1145
	};

	private ISceneRender _sceneRender;

	private readonly System.Random _random = new System.Random();

	public static SceneObjectFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneObjectFactory();
			}
			return _instance;
		}
	}

	private SceneObjectFactory()
	{
		_marks = new Marks();
		_mapGroup = Contexts.sharedInstance.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MapUnityObjects));
	}

	public void CreateSimpleEngineEntityEffect(SceneObjectEntity entity)
	{
		AssetInfo assetInfo = default(AssetInfo);
		assetInfo.BundleName = "effect/pitmode";
		assetInfo.AssetName = string.Format("Assets/Res/Assets/effect/pitMode/{0}_standplayer/Prefab/{0}_standplayer.prefab", entity.simpleEngineEntity.Name);
		assetInfo.AssetType = typeof(GameObject);
		AssetInfo item = assetInfo;
		List<AssetInfo> info = new List<AssetInfo> { item };
		entity.AddLoadEffectObjects(new LoadRequests(info), entity.entityId.Value);
	}

	public SceneObjectEntity CreateSimpleEngineEntityEntity(string resName, SimpleEngineEntityData data)
	{
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.AddSimpleEngineEntity(data, resName);
		sceneObjectEntity.AddPosition(new Vector3(data.X, data.Y, data.Z));
		sceneObjectEntity.AddRotation(new Vector3(data.RotationX, data.RotationY, data.RotationZ));
		AssetInfo item = new AssetInfo($"sceneobject/{resName}", $"Assets/Res/Assets/sceneObject/{resName}/model.prefab", typeof(GameObject));
		List<AssetInfo> info = new List<AssetInfo> { item };
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(info), data.Id);
		return sceneObjectEntity;
	}

	public SceneObjectEntity CreateBulletHoleEntity(Vector3DData position, Vector3DData normal, int ownerId, int resId, bool isServer = false)
	{
		return CreateBulletHoleEntity(VectorTypeConverter.Net2Unity(position), VectorTypeConverter.Net2Unity(normal), ownerId, resId, isServer);
	}

	public SceneObjectEntity CreateBulletHoleEntity(Vector3 position, Vector3 normal, int ownerId, int resId, bool isServer = false)
	{
		if (GameSetting.Config.OpenBulletHole != 1)
		{
			return null;
		}
		RoomDataComponent roomData = Contexts.sharedInstance.battleRoom.roomData;
		if (100 == roomData.Data.RaceType && roomData.Data.FreeType == "BulletStorm")
		{
			return null;
		}
		if (RuleUtilty.IsUnityScene(roomData.Data.SceneId))
		{
			position += normal * 2f;
		}
		else
		{
			position += normal * 1f;
		}
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.AddBulletHole(resId, ownerId, isServer);
		sceneObjectEntity.AddPosition(position);
		sceneObjectEntity.AddNormal(normal);
		HoleResConfig holeResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetHoleResConfig(resId);
		if (holeResConfig == null)
		{
			return null;
		}
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(holeResConfig.Info), resId);
		sceneObjectEntity.AddLifeTime(DateTime.Now, 10000);
		return sceneObjectEntity;
	}

	public SceneObjectEntity CreateBulletRailEntity(int ownerId, Vector3 start, Vector3 end, int resId, int eventId = 0, bool isForceLeftParticleRail = false)
	{
		if (GameSetting.Config.OpenBulletRail != 1)
		{
			return null;
		}
		if (100 == Contexts.sharedInstance.battleRoom.roomData.Data.RaceType && Contexts.sharedInstance.battleRoom.roomData.Data.FreeType == "BulletStorm")
		{
			return null;
		}
		if (Contexts.sharedInstance.player.cameraOwnerEntity != null && ownerId == Contexts.sharedInstance.player.cameraOwnerEntity.entityId.Value)
		{
			if (Vector3.Distance(start, end) < (float)(200 + UnityEngine.Random.Range(0, 700)))
			{
				return null;
			}
		}
		else if (Vector3.Distance(start, end) < 1000f)
		{
			return null;
		}
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.AddBulletRail(ownerId, start, end, isForceLeftParticleRail, eventId);
		RailResConfig railResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetRailResConfig(resId);
		if (railResConfig == null)
		{
			return null;
		}
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(railResConfig.Info), resId);
		return sceneObjectEntity;
	}

	public SceneObjectEntity CreateBowRailEntity(int ownerId, Vector3 start, Vector3 end, int resId, int eventId, bool isForceLeftParticleRail = false)
	{
		if (GameSetting.Config.OpenBulletRail != 1)
		{
			return null;
		}
		if (100 == Contexts.sharedInstance.battleRoom.roomData.Data.RaceType && Contexts.sharedInstance.battleRoom.roomData.Data.FreeType == "BulletStorm")
		{
			return null;
		}
		if (Vector3.Distance(start, end) < 100f)
		{
			return null;
		}
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.AddBulletRail(ownerId, start, end, isForceLeftParticleRail, eventId);
		RailResConfig railResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetRailResConfig(resId);
		if (railResConfig == null)
		{
			return null;
		}
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(railResConfig.Info), resId);
		return sceneObjectEntity;
	}

	public SceneObjectEntity CreateHitEffectEntity(bool isMyself, Vector3 pos, int resId, bool isKnife)
	{
		HitResConfig hitResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetHitResConfig(resId);
		if (hitResConfig == null)
		{
			this.LogErrorFormat("CreateHitEffect Error, resId :{0} isKnife {1}", resId, isKnife);
			return null;
		}
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.isHitEffect = true;
		sceneObjectEntity.AddPosition(pos);
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(hitResConfig.Info), hitResConfig);
		if (!isKnife)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.HitMaterial, isMyself, _attackPlayerAssetInfo, GameSoundManager.Config.WeaponVolume);
		}
		return sceneObjectEntity;
	}

	public SceneObjectEntity CreateHitEffectEntity(bool isMyself, Vector3 pos, AssetInfo info, bool isKnife)
	{
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.isHitEffect = true;
		sceneObjectEntity.AddPosition(pos);
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(info), null);
		if (!isKnife)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.HitMaterial, isMyself, _attackPlayerAssetInfo, GameSoundManager.Config.WeaponVolume);
		}
		return sceneObjectEntity;
	}

	private void CreateAddExplosionEffect(SceneObjectEntity entity, Vector3 pos, Vector3 normal)
	{
		ExplosionEffectConfig explosionEffectConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetExplosionEffectConfig(entity.grenadeExplosion.Data.BaseEventEntity.EventId);
		if (explosionEffectConfig != null)
		{
			if (explosionEffectConfig.HasBulletHole && entity.grenadeExplosion.Data.HaveBulletHoleSpecified && entity.grenadeExplosion.Data.HaveBulletHole)
			{
				CreateBulletHoleEntity(pos, normal, entity.grenadeExplosion.OwnerId, 1);
			}
			if (explosionEffectConfig.HasSound() && explosionEffectConfig.EventId > 0)
			{
				bool isMyself = Contexts.sharedInstance.player.GetEntityWithEntityId(entity.grenadeExplosion.OwnerId)?.isMyPlayer ?? false;
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Explorde, isMyself, explosionEffectConfig.GetSoundAssetInfo(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType), VectorCoordConverter.SsjjToUnity(pos), GameSoundManager.Config.WeaponVolume, GameSoundManager.RollOffDistance.Distance57);
			}
		}
	}

	public void CreateExplosion(GrenadeExplosionEventEntityData data)
	{
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(data.BaseEventEntity.Id);
		if (sceneObjectEntity == null)
		{
			sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
			sceneObjectEntity.AddEntityId(data.BaseEventEntity.Id);
		}
		sceneObjectEntity.ReplaceGrenadeExplosion(data, data.BaseEventEntity.OwnerId);
		sceneObjectEntity.ReplacePosition(VectorTypeConverter.Net2Unity(new Vector3DData
		{
			X = data.BaseEventEntity.X,
			Y = data.BaseEventEntity.Y,
			Z = data.BaseEventEntity.Z
		}));
		sceneObjectEntity.ReplaceNormal(Vector3.zero);
		sceneObjectEntity.ReplaceScale(VectorTypeConverter.Net2Unity(data.BaseEventEntity.Scale));
		EventEffectData eventEntityData = ParticleManager.Instance().GetEventEntityData(data.BaseEventEntity.EventId);
		if (eventEntityData != null)
		{
			sceneObjectEntity.ReplaceLoadUnityObjects(new LoadRequests(eventEntityData.AssetInfo), data.BaseEventEntity.Id);
		}
		else if (data.BaseEventEntity.EventId == 8)
		{
			Contexts.sharedInstance.gameRule.ReplaceFlashExplosionData(data);
		}
		else
		{
			ExplosionConfig explosionConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetExplosionConfig(data.BaseEventEntity.EventId, data.ResTypeID);
			if (explosionConfig == null)
			{
				if (BattleSingletonInstance<ResConfigFactory>.Instance.GetExplosionEffectConfig(data.BaseEventEntity.EventId) == null && !Excepts.Contains(data.BaseEventEntity.EventId))
				{
					this.LogErrorFormat(" GrenadeExplosionEntityCreate Faild :{0},{1}", data.BaseEventEntity.EventId, data.ResTypeID);
				}
			}
			else
			{
				sceneObjectEntity.ReplaceLoadUnityObjects(new LoadRequests(explosionConfig.Info), data.BaseEventEntity.Id);
			}
		}
		CreateAddExplosionEffect(sceneObjectEntity, VectorTypeConverter.Net2Unity(data.CollisionPoint), VectorTypeConverter.Net2Unity(data.CollisionNormal));
	}

	public void CreateTrail(SceneObjectEntity entity, int remainTime, int width, int resIs, AssetInfo info, float alpha, float time)
	{
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		if (entity.hasMoveObject)
		{
			sceneObjectEntity.AddTail(entity.entityId.Value, remainTime, width, resIs, entity.moveObject.Current.PrePointXSpecified ? new Vector3(entity.moveObject.Current.PrePointX, entity.moveObject.Current.PrePointY, entity.moveObject.Current.PrePointZ) : new Vector3(entity.moveObject.Current.X, entity.moveObject.Current.Y, entity.moveObject.Current.Z), alpha, time, newFirstRender: false);
		}
		else
		{
			sceneObjectEntity.AddTail(entity.entityId.Value, remainTime, width, resIs, entity.position.Origin, alpha, time, newFirstRender: false);
		}
		sceneObjectEntity.ReplacePosition(entity.position.Origin);
		if (entity.hasOrientation)
		{
			sceneObjectEntity.ReplaceRotation(VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.orientation.Roll, 90f - entity.orientation.Pitch, entity.orientation.Yaw)));
		}
		sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(info), entity.entityId.Value);
		sceneObjectEntity.isTailRemain = true;
	}

	private WorldHelp GetWorldHelp()
	{
		if (_sceneRender == null && _mapGroup.GetSingleEntity().mapUnityObjects.MapObject != null)
		{
			_sceneRender = _mapGroup.GetSingleEntity().mapUnityObjects.MapObject.GetComponentInChildren<ISceneRender>();
		}
		if (_sceneRender != null)
		{
			return _sceneRender.GetWorldHelp();
		}
		return null;
	}

	private SceneClipMap GetSceneClipMap()
	{
		if (_sceneRender == null && _mapGroup.GetSingleEntity().mapUnityObjects.MapObject != null)
		{
			_sceneRender = _mapGroup.GetSingleEntity().mapUnityObjects.MapObject.GetComponentInChildren<ISceneRender>();
		}
		if (_sceneRender != null)
		{
			return _sceneRender.GetSceneClipMap();
		}
		return null;
	}

	internal IEnumerator CraeteSpary(SprayEventEntityData eventData)
	{
		SceneObjectContext context = Contexts.sharedInstance.sceneObject;
		Mesh mesh = new Mesh();
		yield return _marks.CraeteMark(mesh, GetSceneClipMap(), GetWorldHelp(), eventData.Yaw, new Vector3D(eventData.X, eventData.Y, eventData.Z), new Vector3D(eventData.NormalX, eventData.NormalY, eventData.NormalZ), 90, "SPRAY_MARKFRAGMENT");
		if (mesh.triangles.Length != 0)
		{
			SceneObjectEntity sceneObjectEntity = context.CreateEntity();
			sceneObjectEntity.AddEntityId(eventData.Id);
			sceneObjectEntity.AddSpary(eventData, mesh);
			sceneObjectEntity.AddLoadSparyResource(new LoadRequests(ResourceUtility.GetSparyRequest(eventData.ResTypeID)), eventData.Id);
		}
	}

	internal IEnumerator CraeteWallBlood(Vector3D normal, Vector3D point)
	{
		SceneObjectContext context = Contexts.sharedInstance.sceneObject;
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		Mesh mesh = new Mesh();
		yield return _marks.CraeteMark(mesh, GetSceneClipMap(), GetWorldHelp(), (float)_random.NextDouble() * 180f, point, normal, 100, "SPRAY_MARKFRAGMENT");
		if (mesh.triangles.Length != 0)
		{
			SceneObjectEntity sceneObjectEntity = context.CreateEntity();
			sceneObjectEntity.AddWallBlood(mesh);
			int num = ((!RuleUtilty.IsBioMode(raceType)) ? (RuleUtilty.IsGeneralPve(raceType) ? 1 : ((!RuleUtilty.IsPveModel(raceType)) ? 3 : 2)) : 0);
			BloodResConfig bloodResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetBloodResConfig(num);
			if (bloodResConfig == null)
			{
				this.LogErrorFormat("CreateWallBlood Error, resId :{0}", num);
			}
			else
			{
				sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(bloodResConfig.Info), 0);
			}
		}
	}

	internal void RemoveSpary(SprayEventEntityData eventData)
	{
		SceneObjectEntity entityWithEntityId = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(eventData.Id);
		if (entityWithEntityId != null)
		{
			entityWithEntityId.isDestroy = true;
		}
	}
}

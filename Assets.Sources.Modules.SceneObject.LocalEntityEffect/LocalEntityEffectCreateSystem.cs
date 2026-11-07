using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using NetData;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.LocalEntityEffect;

public class LocalEntityEffectCreateSystem : IEntityCreateSystem
{
	private SnapshotContext _snapshotContext;

	private SceneObjectContext _sceneObjectContext;

	private WeaponContext _weaponContext;

	public LocalEntityEffectCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_weaponContext = contexts.weapon;
	}

	public void OnEntityCreate()
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, FlashEventEntityData> item in latestSnapshot.FlashEventEntityDataDict)
		{
			FlashEventEntityData value = item.Value;
			CreateEffect(9, value.BaseEventEntity.Id, 46, value, value.BaseEventEntity.X, value.BaseEventEntity.Y, value.BaseEventEntity.Z, 0);
		}
		foreach (KeyValuePair<int, Pve3EventEntityData> item2 in latestSnapshot.Pve3EventEntityDataDict)
		{
			Pve3EventEntityData value2 = item2.Value;
			CreateEffect(9, value2.BaseEventEntity.Id, value2.BaseEventEntity.EventId, value2, value2.BaseEventEntity.X, value2.BaseEventEntity.Y, value2.BaseEventEntity.Z, value2.Time);
		}
		foreach (KeyValuePair<int, TitanEventEntityData> item3 in latestSnapshot.TitanEventEntityDataDict)
		{
			TitanEventEntityData value3 = item3.Value;
			CreateEffect(9, value3.BaseEventEntity.Id, value3.BaseEventEntity.EventId, value3, value3.BaseEventEntity.X, value3.BaseEventEntity.Y, value3.BaseEventEntity.Z, value3.Time);
		}
		foreach (KeyValuePair<int, TowerEventEntityData> item4 in latestSnapshot.TowerEventEntityDataDict)
		{
			TowerEventEntityData value4 = item4.Value;
			CreateEffect(9, value4.BaseEventEntity.Id, value4.BaseEventEntity.EventId, value4, value4.BaseEventEntity.X, value4.BaseEventEntity.Y, value4.BaseEventEntity.Z, value4.Time);
		}
		foreach (KeyValuePair<int, BulletRailEventEntityData> item5 in latestSnapshot.BulletRailEventEntityDataDict)
		{
			BulletRailEventEntityData value5 = item5.Value;
			if (value5.BaseEventEntity.EventId == 50)
			{
				CreateEffect(9, value5.BaseEventEntity.Id, value5.BaseEventEntity.EventId, value5, value5.BaseEventEntity.X, value5.BaseEventEntity.Y, value5.BaseEventEntity.Z, 500);
			}
		}
		foreach (SimpleProto eventData in _sceneObjectContext.localEvent.EventDataList)
		{
			switch (eventData.Key)
			{
			case 101:
				if (eventData.Ins[1] == 0)
				{
					GetPosition(eventData, out var x2, out var y2, out var z2);
					CreateEffect(9, eventData.Ins[0], 73, eventData, x2, y2, z2, 36000000);
				}
				else if (eventData.Ins[1] == 1)
				{
					GetPosition(eventData, out var x3, out var y3, out var z3);
					EntityEffectId id2 = new EntityEffectId(eventData.Ins[0], 73.ToString());
					SceneObjectEntity entityWithPlayerEffectId2 = _sceneObjectContext.GetEntityWithPlayerEffectId(id2);
					if (entityWithPlayerEffectId2 != null)
					{
						entityWithPlayerEffectId2.position.Origin = VectorCoordConverter.SsjjToUnity(new Vector3(x3, y3, z3));
					}
				}
				else
				{
					EntityEffectId id3 = new EntityEffectId(eventData.Ins[0], 73.ToString());
					SceneObjectEntity entityWithPlayerEffectId3 = _sceneObjectContext.GetEntityWithPlayerEffectId(id3);
					if (entityWithPlayerEffectId3 != null)
					{
						entityWithPlayerEffectId3.lifeTime.LifeTime = 0;
					}
				}
				break;
			case 102:
			{
				if (eventData.Ins[1] == 0)
				{
					GetPosition(eventData, out var x, out var y, out var z);
					CreateEffect(9, eventData.Ins[0], 74, eventData, x, y, z, 36000000);
					break;
				}
				EntityEffectId id = new EntityEffectId(eventData.Ins[0], 74.ToString());
				SceneObjectEntity entityWithPlayerEffectId = _sceneObjectContext.GetEntityWithPlayerEffectId(id);
				if (entityWithPlayerEffectId != null)
				{
					entityWithPlayerEffectId.lifeTime.LifeTime = 0;
				}
				break;
			}
			}
		}
		_sceneObjectContext.localEvent.EventDataList.Clear();
	}

	private void GetPosition(SimpleProto eventData, out float x, out float y, out float z)
	{
		x = 0f;
		y = 0f;
		z = 0f;
		if (eventData.Fs.Count > 0)
		{
			x = eventData.Fs[0];
			y = eventData.Fs[1];
			z = eventData.Fs[2];
		}
		else if (eventData.Ds.Count > 0)
		{
			x = (float)eventData.Ds[0];
			y = (float)eventData.Ds[1];
			z = (float)eventData.Ds[2];
		}
	}

	private void CreateEffect(int etype, int entityId, int eventId, object eventData, float x, float y, float z, int lifeTime, float rotation = 0f)
	{
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(entityId);
		if (entityWithEntityId != null || eventId == 6)
		{
			return;
		}
		List<LocalEntityEffectTable.Row> list = LocalEntityEffectLoader.Instance.Table.FindAll_EventId(eventId);
		if (list == null || list.Count <= 0)
		{
			return;
		}
		LocalEntityEffectTable.Row row = list[0];
		EntityEffectId entityEffectId = new EntityEffectId(entityId, eventId.ToString());
		entityWithEntityId = _sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId);
		if (entityWithEntityId != null)
		{
			return;
		}
		entityWithEntityId = _sceneObjectContext.CreateEntity();
		entityWithEntityId.AddEtype(etype);
		entityWithEntityId.AddEntityId(entityId);
		entityWithEntityId.AddPlayerEffectId(entityEffectId);
		entityWithEntityId.AddPosition(VectorCoordConverter.SsjjToUnity(new Vector3(x, y, z)));
		entityWithEntityId.AddRotation(new Vector3(0f, rotation, 0f));
		entityWithEntityId.AddScale(Vector3.one);
		entityWithEntityId.AddLocalEntityEffect(eventData, string.IsNullOrEmpty(row.Render) ? null : Type.GetType("Assets.Sources.Info.Effect.LocalEntityEffect.Render." + row.Render));
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(row.Weapon))
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Weapon == text)
				{
					row = list[i];
					break;
				}
			}
			entityWithEntityId.AddLoadUnityObjects(new LoadRequests("weapon/" + row.Weapon, $"Assets/Res/Assets/weapon/{row.Weapon}/effect/particle/event_{row.EventId}.prefab"), entityEffectId);
		}
		else
		{
			entityWithEntityId.AddLoadUnityObjects(new LoadRequests(new AssetInfo("localentityeffectprefab/" + row.Prefab, row.Prefab, typeof(GameObject))), entityEffectId);
		}
		if (row.EventId == 41 || row.EventId == 39 || row.EventId == 78)
		{
			entityWithEntityId.AddLifeTime(DateTime.Now, row.LifeTime + lifeTime);
		}
		else
		{
			entityWithEntityId.AddLifeTime(DateTime.Now, (lifeTime > 0) ? lifeTime : ((row.LifeTime == -1) ? int.MaxValue : row.LifeTime));
		}
	}

	private static string GetEffectEntityId(int entityId, int effectName)
	{
		return $"{entityId}@{effectName}";
	}
}

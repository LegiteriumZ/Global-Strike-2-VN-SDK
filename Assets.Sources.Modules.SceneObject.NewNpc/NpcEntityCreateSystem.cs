using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcEntityCreateSystem : IEntityCreateSystem
{
	private SceneObjectContext _sceneObjectContext;

	private SnapshotContext _snapshotContext;

	public NpcEntityCreateSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_snapshotContext = contexts.snapshot;
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, NpcEntityData> item in nowSnapshot.NpcEntityDataDict)
		{
			NpcEntityData value = item.Value;
			nextSnapshot.NpcEntityDataDict.TryGetValue(value.Id, out var value2);
			if (value2 == null)
			{
				value2 = value;
			}
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
			if (sceneObjectEntity == null)
			{
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddNpcBasicInfo(value, value2);
				sceneObjectEntity.AddEtype(8);
				sceneObjectEntity.AddEntityId(value.Id);
				sceneObjectEntity.AddPosition(Vector3.zero);
				sceneObjectEntity.AddRotation(Vector3.zero);
				sceneObjectEntity.AddScale(Vector3.one);
				sceneObjectEntity.AddVisiable(newIsVisiable: true, newIsNear: true, newIsWeaponParticleUnSee: false);
				sceneObjectEntity.AddNpcAnim(null, 0);
			}
			sceneObjectEntity.npcBasicInfo.Current = value;
			sceneObjectEntity.npcBasicInfo.Next = value2;
		}
	}
}

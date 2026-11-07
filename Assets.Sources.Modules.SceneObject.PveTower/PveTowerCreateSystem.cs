using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJPhysics;
using UnityEngine;
using data;
using physics.data;

namespace Assets.Sources.Modules.SceneObject.PveTower;

public class PveTowerCreateSystem : IPlaybackInitSystem
{
	private SnapshotContext _snapshotContext;

	private SceneObjectContext _sceneObjectContext;

	private BattleRoomContext _battleRoomContext;

	private IGroup<SceneObjectEntity> _group;

	public PveTowerCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.PveTower);
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		foreach (KeyValuePair<int, PveTowerEntityData> item2 in nowSnapshot.PveTowerEntityDataDict)
		{
			PveTowerEntityData value = item2.Value;
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
			if (sceneObjectEntity != null && sceneObjectEntity.pveTower.Data.FileName != value.FileName)
			{
				sceneObjectEntity.Destroy();
				sceneObjectEntity = null;
			}
			if (sceneObjectEntity != null)
			{
				continue;
			}
			sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddEntityId(value.Id);
			sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
			sceneObjectEntity.AddRotation(new Vector3(value.RotationX, 0f, value.RotationZ));
			sceneObjectEntity.AddPveTower(new PveTowerComponent.PveTowerData());
			sceneObjectEntity.pveTower.Data.FileName = value.FileName;
			if (_battleRoomContext.sceneItemInfo.ScneItemInfoDict.TryGetValue(value.FileName, out var value2))
			{
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				if (value2.ContainsKey(0))
				{
					PeekabooItemTmpData peekabooItemTmpData = value2[0];
					if (string.IsNullOrEmpty(peekabooItemTmpData.Name))
					{
						zero = new Vector3(peekabooItemTmpData.MinX + peekabooItemTmpData.PosX, peekabooItemTmpData.MinY + peekabooItemTmpData.PosY, peekabooItemTmpData.MinZ + peekabooItemTmpData.PosZ);
						zero2 = new Vector3(peekabooItemTmpData.MaxX + peekabooItemTmpData.PosX, peekabooItemTmpData.MaxY + peekabooItemTmpData.PosY, peekabooItemTmpData.MaxZ + peekabooItemTmpData.PosZ);
					}
					else
					{
						zero = new Vector3(peekabooItemTmpData.MinX, peekabooItemTmpData.MinY, peekabooItemTmpData.MinZ);
						zero2 = new Vector3(peekabooItemTmpData.MaxX, peekabooItemTmpData.MaxY, peekabooItemTmpData.MaxZ);
					}
					List<CBrush> newBrushs = new List<CBrush>
					{
						new SceneItemBrush()
					};
					sceneObjectEntity.AddSceneObjectPyhsics(new PySceneItweenEntityAdapter(sceneObjectEntity, zero, zero2), newBrushs);
				}
				else
				{
					this.LogError("Error, PeekabooItemTmpData");
				}
			}
			AssetInfo item = new AssetInfo($"sceneobject/{value.FileName}", $"Assets/Res/Assets/sceneObject/{value.FileName}/model.prefab", typeof(GameObject));
			LoadRequests newLoadRequests = new LoadRequests(new List<AssetInfo> { item });
			sceneObjectEntity.AddLoadUnityObjects(newLoadRequests, value.Id);
			sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddHangEffectRes(new List<string>(), new List<AssetInfo>());
			sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
			sceneObjectEntity.hangEffectRes.NeedSceneObjectList.Add(value.FileName);
		}
		foreach (SceneObjectEntity item3 in _group)
		{
			if (!nowSnapshot.PveTowerEntityDataDict.ContainsKey(item3.entityId.Value))
			{
				item3.isDestroy = true;
			}
		}
	}
}

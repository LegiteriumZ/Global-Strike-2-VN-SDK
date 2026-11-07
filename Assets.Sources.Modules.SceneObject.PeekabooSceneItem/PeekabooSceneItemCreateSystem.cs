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

namespace Assets.Sources.Modules.SceneObject.PeekabooSceneItem;

public class PeekabooSceneItemCreateSystem : IPlaybackInitSystem
{
	private SnapshotContext _snapContext;

	private SceneObjectContext _sceneObjectContext;

	private BattleRoomContext _battleRoomContext;

	private MessageContext _msgContext;

	private IGroup<SceneObjectEntity> _group;

	public PeekabooSceneItemCreateSystem(Contexts contexts)
	{
		_snapContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_msgContext = contexts.message;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.PeekabooSceneItem);
	}

	public void OnPlaybackInit()
	{
		if (_msgContext.peekabooMessageData != null)
		{
			createSceneItemByDic(_msgContext.peekabooMessageData.sceneItems, checkCanSee: true, _msgContext.peekabooMessageData.notCanSeeList);
		}
		ISnapshot nowSnapshot = _snapContext.snapshots.NowSnapshot;
		createSceneItemByDic(nowSnapshot.SceneItemEntityDataDict, checkCanSee: false, null);
		foreach (SceneObjectEntity item in _group)
		{
			bool num = _msgContext.peekabooMessageData.sceneItems.ContainsKey(item.entityId.Value);
			bool flag = nowSnapshot.SceneItemEntityDataDict.ContainsKey(item.entityId.Value);
			if (!num && !flag)
			{
				item.isDestroy = true;
			}
		}
	}

	private void createSceneItemByDic(Dictionary<int, SceneItemEntityData> dic, bool checkCanSee, List<int> notCanSeeList)
	{
		if (dic == null)
		{
			return;
		}
		foreach (KeyValuePair<int, SceneItemEntityData> item2 in dic)
		{
			SceneItemEntityData value = item2.Value;
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
			if (sceneObjectEntity != null && sceneObjectEntity.peekabooSceneItem.Data.FileName != value.Name)
			{
				sceneObjectEntity.Destroy();
				sceneObjectEntity = null;
			}
			if (checkCanSee && notCanSeeList.Contains(value.Id))
			{
				if (sceneObjectEntity != null)
				{
					sceneObjectEntity.isDestroy = true;
				}
			}
			else
			{
				if (sceneObjectEntity != null)
				{
					continue;
				}
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddEntityId(value.Id);
				sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
				sceneObjectEntity.AddRotation(new Vector3(value.RotationX, 0f, value.RotationZ));
				sceneObjectEntity.AddPeekabooSceneItem(new PeekabooSceneItemComponent.PeekabooSceneItemData());
				sceneObjectEntity.peekabooSceneItem.Data.FileName = value.Name;
				if (_battleRoomContext.sceneItemInfo.ScneItemInfoDict.TryGetValue(value.Name, out var value2))
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
				AssetInfo item = new AssetInfo($"sceneobject/{value.Name}", $"Assets/Res/Assets/sceneObject/{value.Name}/model.prefab", typeof(GameObject));
				LoadRequests newLoadRequests = new LoadRequests(new List<AssetInfo> { item });
				sceneObjectEntity.AddLoadUnityObjects(newLoadRequests, value.Id);
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddHangEffectRes(new List<string>(), new List<AssetInfo>());
				sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
				sceneObjectEntity.hangEffectRes.NeedSceneObjectList.Add(value.Name);
			}
		}
	}
}

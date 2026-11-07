using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Snapshots;
using NetData;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJMath;
using SSJJPhysicsExtensions;
using UnityEngine;
using physics.data;
using share;
using wooduanITween;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class iTweenMoveEntityCreateSystem : IEntityCreateSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleRoomContext _battleRoomContext;

	public iTweenMoveEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnEntityCreate()
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, SceneItweenEntityData> item in latestSnapshot.SceneItweenEntityDataDict)
		{
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(item.Key);
			SceneItweenEntityData value = item.Value;
			SceneItweenEntityData sceneItweenEntityData = null;
			if (sceneObjectEntity == null)
			{
				Vector3 vector = new Vector3(value.BaseMoveEntity.X, value.BaseMoveEntity.Y, value.BaseMoveEntity.Z);
				Vector3 vector2 = new Vector3(value.BaseMoveEntity.Roll, value.BaseMoveEntity.Pitch, value.BaseMoveEntity.Yaw);
				string name = value.BaseMoveEntity.Name;
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddEtype(14);
				sceneObjectEntity.AddEntityId(item.Key);
				sceneObjectEntity.AddiTweenMove(value, null, null, null);
				sceneObjectEntity.AddPosition(vector);
				sceneObjectEntity.AddRotation(vector2);
				sceneObjectEntity.AddTweenMoveHistory(vector, vector2);
				sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(new AssetInfo($"sceneobject/{name}", $"Assets/Res/Assets/sceneObject/{name}/model.prefab", typeof(GameObject))), sceneObjectEntity.entityId.Value);
				if (name.Equals("helicopter_01"))
				{
					sceneObjectEntity.loadUnityObjects.LoadRequests.Add(1, new LoadRequest(new AssetInfo($"sceneobject/{name}", $"Assets/Res/Assets/sceneObject/{name}/model.anm.bytes", typeof(SJAnimationAsset))));
				}
				if (_battleRoomContext.sceneItemInfo.ScneItemInfoDict.TryGetValue(value.BaseMoveEntity.Name, out var value2))
				{
					sceneObjectEntity.AddSceneObjectPyhsics(new ComplexPySceneItweenEntityAdapter(sceneObjectEntity, value2), new List<CBrush>());
				}
			}
			else
			{
				sceneItweenEntityData = sceneObjectEntity.iTweenMove.Data;
				sceneObjectEntity.iTweenMove.Data = value;
			}
			if (value != sceneItweenEntityData)
			{
				if (!Snapshot.ItweenRecords.TryGetValue(value, out var value3))
				{
					value3 = latestSnapshot.ServerTime;
				}
				CheckTweenStateChange(sceneObjectEntity, value, sceneItweenEntityData, value3);
			}
		}
	}

	private static ItweenMoveInfo GetItweenMoveInfoFromNetData(ItweenMoveInfoData data)
	{
		Vector3D source = VectorTypeConverter.Net2Ssjj(data.Source);
		Vector3D destination = VectorTypeConverter.Net2Ssjj(data.Destination);
		return new ItweenMoveInfo(source, destination, (LoopType)data.LoopType, (EaseType)data.EaseType, data.Time, data.Delay, data.StartDelayTime);
	}

	private static ItweenMoveInfo GetItweenPathMoveInfoFromNetData(ItweenMoveInfoData data)
	{
		Vector3D[] array = new Vector3D[data.NodeList.Count];
		for (int i = 0; i < data.NodeList.Count; i++)
		{
			array[i] = VectorTypeConverter.Net2Ssjj(data.NodeList[i]);
		}
		return new ItweenMoveInfo(array, (LoopType)data.LoopType, data.Time, data.Delay, data.StartDelayTime, data.PathLookTarget, data.IsUniform);
	}

	private static void CheckTweenStateChange(SceneObjectEntity entity, SceneItweenEntityData data, SceneItweenEntityData lastData, int serverTime)
	{
		if (data.MoveItweenInfo != null)
		{
			bool flag = false;
			if (lastData == null || data.MoveItweenInfo.ItweenMoveInfo != null)
			{
				flag = true;
				entity.iTweenMove.MoveToTweenEntity = new ITweenEntity();
				entity.iTweenMove.MoveToTweenEntity.SetIsClient(value: true);
				entity.iTweenMove.MoveToTweenEntity.AddMoveToItween(GetItweenMoveInfoFromNetData(data.MoveItweenInfo.ItweenMoveInfo));
			}
			if (flag || data.MoveItweenInfo.StartRunningTime != lastData.MoveItweenInfo.StartRunningTime)
			{
				entity.iTweenMove.MoveToTweenEntity.SetStartRunningTime(data.MoveItweenInfo.StartRunningTime);
			}
			if (flag || data.MoveItweenInfo.IsRunning != lastData.MoveItweenInfo.IsRunning)
			{
				entity.iTweenMove.MoveToTweenEntity.SetIsRunning(data.MoveItweenInfo.IsRunning);
			}
			if (flag || data.MoveItweenInfo.PauseTime != lastData.MoveItweenInfo.PauseTime)
			{
				entity.iTweenMove.MoveToTweenEntity.SetPauseTime(data.MoveItweenInfo.PauseTime);
			}
			if (flag || data.MoveItweenInfo.GoBackTime != lastData.MoveItweenInfo.GoBackTime)
			{
				entity.iTweenMove.MoveToTweenEntity.SetGoBackTime(data.MoveItweenInfo.GoBackTime);
			}
			if (flag || data.MoveItweenInfo.SpeedUpTime != lastData.MoveItweenInfo.SpeedUpTime)
			{
				entity.iTweenMove.MoveToTweenEntity.SetSpeedUpTime(data.MoveItweenInfo.SpeedUpTime);
			}
			if (flag || data.MoveItweenInfo.LastFrameServerTime != lastData.MoveItweenInfo.LastFrameServerTime)
			{
				entity.iTweenMove.MoveToTweenEntity.SetLastFrameServerTime(data.MoveItweenInfo.LastFrameServerTime);
			}
			if (flag || data.MoveItweenInfo.SpeedRate != lastData.MoveItweenInfo.SpeedRate)
			{
				entity.iTweenMove.MoveToTweenEntity.SetSpeedRate(data.MoveItweenInfo.SpeedRate);
			}
			if (flag && !data.MoveItweenInfo.IsRunning)
			{
				ITweenEntity moveToTweenEntity = entity.iTweenMove.MoveToTweenEntity;
				moveToTweenEntity.CalRunnintTime(serverTime);
				moveToTweenEntity.SetIsRunning(b: false);
			}
		}
		if (data.RotateItweenInfo != null)
		{
			bool flag2 = false;
			if (lastData == null || data.RotateItweenInfo.ItweenMoveInfo != null)
			{
				flag2 = true;
				entity.iTweenMove.RotateToTweenEntity = new ITweenEntity();
				entity.iTweenMove.RotateToTweenEntity.SetIsClient(value: true);
				entity.iTweenMove.RotateToTweenEntity.AddRotateToItween(GetItweenMoveInfoFromNetData(data.RotateItweenInfo.ItweenMoveInfo));
			}
			if (flag2 || data.RotateItweenInfo.StartRunningTime != lastData.RotateItweenInfo.StartRunningTime)
			{
				entity.iTweenMove.RotateToTweenEntity.SetStartRunningTime(data.RotateItweenInfo.StartRunningTime);
			}
			if (flag2 || data.RotateItweenInfo.IsRunning != lastData.RotateItweenInfo.IsRunning)
			{
				entity.iTweenMove.RotateToTweenEntity.SetIsRunning(data.RotateItweenInfo.IsRunning);
			}
			if (flag2 || data.RotateItweenInfo.PauseTime != lastData.RotateItweenInfo.PauseTime)
			{
				entity.iTweenMove.RotateToTweenEntity.SetPauseTime(data.RotateItweenInfo.PauseTime);
			}
			if (flag2 && !data.RotateItweenInfo.IsRunning)
			{
				entity.iTweenMove.RotateToTweenEntity.CalRunnintTime(serverTime);
				entity.iTweenMove.RotateToTweenEntity.SetIsRunning(b: false);
			}
		}
		if (data.PathItweenInfo != null)
		{
			bool flag3 = false;
			if (lastData == null || data.PathItweenInfo.ItweenMoveInfo != null)
			{
				flag3 = true;
				entity.iTweenMove.PathTweenEntity = new ITweenEntity();
				entity.iTweenMove.PathTweenEntity.SetIsClient(value: true);
				entity.iTweenMove.PathTweenEntity.AddPathToItween(GetItweenPathMoveInfoFromNetData(data.PathItweenInfo.ItweenMoveInfo));
			}
			if (flag3 || data.PathItweenInfo.StartRunningTime != lastData.PathItweenInfo.StartRunningTime)
			{
				entity.iTweenMove.PathTweenEntity.SetStartRunningTime(data.PathItweenInfo.StartRunningTime);
			}
			if (flag3 || data.PathItweenInfo.IsRunning != lastData.PathItweenInfo.IsRunning)
			{
				entity.iTweenMove.PathTweenEntity.SetIsRunning(data.PathItweenInfo.IsRunning);
			}
			if (flag3 || data.PathItweenInfo.PauseTime != lastData.PathItweenInfo.PauseTime)
			{
				entity.iTweenMove.PathTweenEntity.SetPauseTime(data.PathItweenInfo.PauseTime);
			}
			if (flag3 || data.PathItweenInfo.GoBack != lastData.PathItweenInfo.GoBack)
			{
				entity.iTweenMove.PathTweenEntity.SetGoBack(data.PathItweenInfo.GoBack);
			}
			if (flag3 || data.PathItweenInfo.GoBackTime != lastData.PathItweenInfo.GoBackTime)
			{
				entity.iTweenMove.PathTweenEntity.SetGoBackTime(data.PathItweenInfo.GoBackTime);
			}
			if (flag3 || data.PathItweenInfo.SpeedUpTime != lastData.PathItweenInfo.SpeedUpTime)
			{
				entity.iTweenMove.PathTweenEntity.SetSpeedUpTime(data.PathItweenInfo.SpeedUpTime);
			}
			if (flag3 || data.PathItweenInfo.SpeedRate != lastData.PathItweenInfo.SpeedRate)
			{
				entity.iTweenMove.PathTweenEntity.SetSpeedRate(data.PathItweenInfo.SpeedRate);
			}
			if (flag3 || data.PathItweenInfo.LastFrameServerTime != lastData.PathItweenInfo.LastFrameServerTime)
			{
				entity.iTweenMove.PathTweenEntity.SetLastFrameServerTime(data.PathItweenInfo.LastFrameServerTime);
			}
			if (flag3 && !data.PathItweenInfo.IsRunning)
			{
				entity.iTweenMove.PathTweenEntity.CalRunnintTime(entity.iTweenMove.PathTweenEntity.GetLastFrameServerTime());
				entity.iTweenMove.PathTweenEntity.SetIsRunning(b: false);
			}
		}
	}
}

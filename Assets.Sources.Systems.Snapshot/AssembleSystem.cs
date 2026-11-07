using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.Snapshot;

public class AssembleSystem : IExecuteSystem, ISystem
{
	public static IRecord Record;

	public const int MaxSnapshotSize = 32;

	public const int MaxBaseSnapshotSize = 200;

	private readonly SnapshotContext _context;

	public AssembleSystem(Contexts contexts)
	{
		_context = contexts.snapshot;
	}

	public void Execute()
	{
		SnapshotsComponent snapshots = _context.snapshots;
		foreach (ISnapshot partialSnapshot in snapshots.PartialSnapshots)
		{
			Assemble(snapshots, partialSnapshot);
		}
		snapshots.PartialSnapshots.Clear();
	}

	private void Assemble(SnapshotsComponent comp, ISnapshot snapshot)
	{
		Assets.Sources.Snapshots.Snapshot snapshot2 = GetBaseSnapshot(comp, snapshot.Base);
		if (Record != null)
		{
			snapshot2 = (Assets.Sources.Snapshots.Snapshot)Record.FixSnapshot(snapshot2, snapshot, comp);
		}
		if (snapshot.Base != -1 && snapshot2 == null)
		{
			this.LogError("lost base snapshot " + snapshot.Base + " when fill " + snapshot.SeqId);
			return;
		}
		Assets.Sources.Snapshots.Snapshot.CloneEntities(snapshot as Assets.Sources.Snapshots.Snapshot, snapshot2);
		Assets.Sources.Snapshots.Snapshot.CloneBag(snapshot as Assets.Sources.Snapshots.Snapshot, snapshot2);
		Assets.Sources.Snapshots.Snapshot.DeleteEntities(snapshot as Assets.Sources.Snapshots.Snapshot, snapshot.DeletedEntityIdList);
		if (!snapshot.IsTiny)
		{
			Assets.Sources.Snapshots.Snapshot.SetFristPlayerEntity(snapshot as Assets.Sources.Snapshots.Snapshot, comp.FristPlayerEntityDict, comp.AccessoryPlayerEntityDict);
			AddBaseSnapshot(comp, snapshot);
			AddSnapshot(comp, snapshot);
			SetLatestSnapshot(comp, snapshot, updateNetState: true);
		}
		else
		{
			SetLatestSnapshot(comp, snapshot, updateNetState: false);
		}
	}

	public static Assets.Sources.Snapshots.Snapshot GetBaseSnapshot(SnapshotsComponent comp, int id)
	{
		for (int i = 0; i < comp.BaseSnapshotList.Count; i++)
		{
			ISnapshot snapshot = comp.BaseSnapshotList[i];
			if (snapshot.SeqId == id)
			{
				return snapshot as Assets.Sources.Snapshots.Snapshot;
			}
		}
		return null;
	}

	private void AddBaseSnapshot(SnapshotsComponent comp, ISnapshot snapshot)
	{
		comp.BaseSnapshotList.Add(snapshot);
		if (comp.BaseSnapshotList.Count > 200)
		{
			ISnapshot snapshot2 = comp.BaseSnapshotList[0];
			comp.BaseSnapshotList.RemoveAt(0);
			SnapshotFactory.Instance.Add(snapshot2 as Assets.Sources.Snapshots.Snapshot);
		}
	}

	private static void AddSnapshot(SnapshotsComponent comp, ISnapshot snapshot)
	{
		List<ISnapshot> snapshotList = comp.SnapshotList;
		int index = snapshotList.Count;
		for (int i = 0; i < snapshotList.Count; i++)
		{
			if (snapshotList[i].SeqId > snapshot.SeqId)
			{
				index = i;
				break;
			}
		}
		snapshotList.Insert(index, snapshot);
		if (snapshotList.Count > 32)
		{
			snapshotList.RemoveAt(0);
		}
	}

	private static void SetLatestSnapshot(SnapshotsComponent comp, ISnapshot snapshot, bool updateNetState)
	{
		ISnapshot latestSnapshot = comp.LatestSnapshot;
		if (latestSnapshot != null && latestSnapshot.SeqId >= snapshot.SeqId)
		{
			return;
		}
		if (snapshot.PlayerEntityDataDict.ContainsKey(snapshot.Self))
		{
			int clientTime = snapshot.PlayerEntityDataDict[snapshot.Self].ClientTime;
			if (latestSnapshot != null)
			{
				snapshot.SelfClientTimeLastDiff = clientTime - latestSnapshot.SelfClientTime;
			}
			snapshot.SelfClientTime = clientTime;
		}
		if (updateNetState)
		{
			comp.LatestSnapshot = snapshot;
			comp.ReceiveSnapshotTime = DateTime.Now;
			comp.LatestSnapshotSeqId = snapshot.SeqId;
			comp.AnySnapshotReceived = true;
			comp.FixDeltaTime = true;
		}
	}
}

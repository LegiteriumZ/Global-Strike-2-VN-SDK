using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.Time;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Systems.Snapshot;

public class SelectSystem : IExecuteSystem, ISystem
{
	private readonly SnapshotContext _context;

	private readonly BattleRoomContext _battleGameContext;

	private readonly TimeContext _timeContext;

	public SelectSystem(Contexts contexts)
	{
		_context = contexts.snapshot;
		_battleGameContext = contexts.battleRoom;
		_timeContext = contexts.time;
	}

	public void Execute()
	{
		if (_battleGameContext.gameState.State == BattleGameState.Gaming)
		{
			SelectSnapshot(_context.snapshots, _timeContext.time);
		}
	}

	private void SelectSnapshot(SnapshotsComponent comp, TimeComponent timeComp)
	{
		if (comp.NowSnapshot == null)
		{
			comp.NowSnapshot = PopSnapshot(comp, -1);
			if (comp.NowSnapshot == null)
			{
				return;
			}
			TimeUtility.SetServerTime(timeComp, comp.LatestSnapshot.ServerTime);
		}
		while (true)
		{
			if (comp.NextSnapshot == null)
			{
				comp.NextSnapshot = PopSnapshot(comp, comp.NowSnapshot.SeqId);
				if (comp.NextSnapshot == null)
				{
					break;
				}
			}
			if ((timeComp.RenderTime < comp.NowSnapshot.ServerTime || timeComp.RenderTime >= comp.NextSnapshot.ServerTime) && comp.NowSnapshot.IsDispose && timeComp.RenderTime >= comp.NextSnapshot.ServerTime)
			{
				comp.NowSnapshot = comp.NextSnapshot;
				comp.NextSnapshot = null;
				continue;
			}
			break;
		}
	}

	public Assets.Sources.Snapshots.Snapshot PopSnapshot(SnapshotsComponent comp, int previousSeqId)
	{
		while (comp.SnapshotList.Count > 0)
		{
			ISnapshot snapshot = comp.SnapshotList[0];
			comp.SnapshotList.RemoveAt(0);
			if (snapshot.SeqId > previousSeqId)
			{
				return snapshot as Assets.Sources.Snapshots.Snapshot;
			}
		}
		return null;
	}
}

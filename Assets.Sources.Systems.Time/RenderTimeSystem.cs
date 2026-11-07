using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Entitas;

namespace Assets.Sources.Systems.Time;

public class RenderTimeSystem : IExecuteSystem, ISystem
{
	private readonly TimeContext _timeContext;

	private readonly SnapshotContext _snapshotContext;

	public RenderTimeSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_snapshotContext = contexts.snapshot;
	}

	public void Execute()
	{
		UpdateRenderTime(_timeContext.time);
	}

	private void UpdateRenderTime(TimeComponent timeComp)
	{
		int num = timeComp.ClientRealTime + timeComp.ServerTimeDelta - 100 - 30;
		timeComp.RenderTime = ((num < timeComp.RenderTime) ? timeComp.RenderTime : num);
		if (!_snapshotContext.hasSnapshots)
		{
			return;
		}
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot != null && timeComp.RenderTime >= latestSnapshot.ServerTime - 30)
		{
			timeComp.ExtrapolatedSnapshot = true;
		}
		if (_snapshotContext.snapshots.FixDeltaTime)
		{
			_snapshotContext.snapshots.FixDeltaTime = false;
			int num2 = latestSnapshot.ServerTime - timeComp.ClientRealTime;
			int num3 = Math.Abs(num2 - timeComp.ServerTimeDelta);
			if (num3 > 500)
			{
				timeComp.ServerTimeDelta = num2;
				timeComp.RenderTime = latestSnapshot.ServerTime;
			}
			else if (num3 > 100)
			{
				timeComp.ServerTimeDelta = timeComp.ServerTimeDelta + num2 >> 1;
			}
			else if (timeComp.ExtrapolatedSnapshot)
			{
				timeComp.ExtrapolatedSnapshot = false;
				timeComp.ServerTimeDelta -= 2;
			}
			else
			{
				timeComp.ServerTimeDelta++;
			}
		}
	}
}

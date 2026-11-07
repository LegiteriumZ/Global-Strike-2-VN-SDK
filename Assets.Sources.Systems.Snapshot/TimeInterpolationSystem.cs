using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.Time;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Systems.Snapshot;

public class TimeInterpolationSystem : IExecuteSystem, ISystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly TimeContext _timeContext;

	public TimeInterpolationSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_timeContext = contexts.time;
	}

	public void Execute()
	{
		SnapshotsComponent snapshots = _snapshotContext.snapshots;
		TimeComponent time = _timeContext.time;
		if (snapshots.NextSnapshot != null)
		{
			float num = snapshots.NextSnapshot.ServerTime - snapshots.NowSnapshot.ServerTime;
			if (Mathf.Approximately(num, 0f))
			{
				time.FrameInterpolation = 0f;
				return;
			}
			int num2 = time.RenderTime - snapshots.NowSnapshot.ServerTime;
			time.FrameInterpolation = Mathf.Clamp((float)num2 / num, 0f, 1f);
		}
		else
		{
			time.FrameInterpolation = 0f;
		}
	}
}

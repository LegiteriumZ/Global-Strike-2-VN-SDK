using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class PlaybackInitSystem : FrameworkSystemBase<IPlaybackInitSystem>
{
	private readonly SnapshotContext _snapshotContext;

	public int LastSnapshotSeqId;

	private List<IPlaybackInitSystem> _systems;

	public override List<IPlaybackInitSystem> Systems => _systems;

	public PlaybackInitSystem(Contexts contexts, IGameModule module)
	{
		_snapshotContext = contexts.snapshot;
		_systems = module.PlaybackInitSystems;
		Init();
	}

	public override void SingleExecute(IPlaybackInitSystem system)
	{
		system.OnPlaybackInit();
	}

	public override void Execute()
	{
		if (OfflineGameController.setting != null && OfflineGameController.setting.TurnOn)
		{
			ExecuteSystems();
		}
		if (_snapshotContext.snapshots.NowSnapshot != null && _snapshotContext.snapshots.NowSnapshot.SeqId != LastSnapshotSeqId)
		{
			LastSnapshotSeqId = _snapshotContext.snapshots.NowSnapshot.SeqId;
			ExecuteSystems();
		}
	}
}

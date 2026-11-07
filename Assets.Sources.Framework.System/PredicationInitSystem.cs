using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using NetData;
using SSJJUserCmd;

namespace Assets.Sources.Framework.System;

public class PredicationInitSystem : FrameworkSystemBase<IPredicationInitSystem>
{
	private readonly SnapshotContext _snapshotContext;

	private readonly PlayerContext _playerContext;

	public int LastSnapshotSeqId;

	private List<IPredicationInitSystem> _systems;

	public override List<IPredicationInitSystem> Systems => _systems;

	public PredicationInitSystem(Contexts contexts, IGameModule module)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
		_systems = module.PredicationInitSystems;
		Init();
	}

	public override void SingleExecute(IPredicationInitSystem system)
	{
		system.OnPredicatoinInit();
	}

	public override void Execute()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null || myPlayerEntity == null || LastSnapshotSeqId == latestSnapshot.SeqId)
		{
			return;
		}
		LastSnapshotSeqId = latestSnapshot.SeqId;
		PlayerEntityData playerEntityData = latestSnapshot.PlayerEntityDataDict[myPlayerEntity.entityId.Value];
		LinkedListNode<UserCmd> last = Contexts.sharedInstance.userCommand.commands.CommandList.Last;
		if (last != null)
		{
			myPlayerEntity.predicateComfirm.BeingHitTime = playerEntityData.BeingHitTime;
			myPlayerEntity.predicateComfirm.Seq = last.Value.Seq + 1;
		}
		bool flag = false;
		int lastCmd = latestSnapshot.LastCmd;
		foreach (IPredicationInitSystem system in _systems)
		{
			if (system.HasPredicatonError(lastCmd))
			{
				system.OnPredicatoinError(lastCmd);
				flag = system.ShouldResetAll();
				if (flag)
				{
					break;
				}
				SingleExecute(system);
			}
			else
			{
				system.OnPredicatoinSucc(lastCmd);
			}
		}
		if (flag)
		{
			_snapshotContext.snapshots.LastProcessedCmd = lastCmd;
			ExecuteSystems();
		}
	}
}

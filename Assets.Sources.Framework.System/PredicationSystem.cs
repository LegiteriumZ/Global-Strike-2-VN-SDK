using System.Collections.Generic;
using SSJJUserCmd;

namespace Assets.Sources.Framework.System;

public class PredicationSystem : FrameworkSystemBase<IPredicateSystem>
{
	private readonly UserCommandContext _commandContext;

	private readonly SnapshotContext _snapshotContext;

	private readonly PlayerContext _playerContext;

	private List<IPredicateSystem> _systems;

	private List<IPredicationInitSystem> _initSystems;

	private UserCmd _currentCmd;

	public override List<IPredicateSystem> Systems => _systems;

	public PredicationSystem(Contexts contexts, IGameModule module)
	{
		_commandContext = contexts.userCommand;
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
		_systems = module.PredicationSystems;
		_initSystems = module.PredicationInitSystems;
		Init();
	}

	public override void SingleExecute(IPredicateSystem system)
	{
		system.OnPredicate(_playerContext.myPlayerEntity, _currentCmd);
	}

	private void ClientComfirmFieldProcess(UserCmd cmd, PlayerEntity state)
	{
		if (cmd.Seq == state.predicateComfirm.Seq)
		{
			state.move.BeingHitTime = state.predicateComfirm.BeingHitTime;
		}
	}

	public override void Execute()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		LinkedList<UserCmd> commandList = _commandContext.commands.CommandList;
		if (_snapshotContext.snapshots.LatestSnapshot == null || _playerContext.myPlayerEntity == null)
		{
			return;
		}
		foreach (UserCmd item in commandList)
		{
			UserCmd userCmd = (_currentCmd = item);
			if (userCmd.Seq <= _snapshotContext.snapshots.LastProcessedCmd)
			{
				continue;
			}
			ClientComfirmFieldProcess(_currentCmd, myPlayerEntity);
			ExecuteSystems();
			userCmd.PredicatedOnce = true;
			_snapshotContext.snapshots.LastProcessedCmd = userCmd.Seq;
			foreach (IPredicationInitSystem initSystem in _initSystems)
			{
				initSystem.SavePredicationState(userCmd.Seq);
			}
		}
	}
}

using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class AfterPredicationSystem : FrameworkSystemBase<IAfterPredicationSystem>
{
	private List<IAfterPredicationSystem> _systems;

	public override List<IAfterPredicationSystem> Systems => _systems;

	public AfterPredicationSystem(IGameModule module)
	{
		_systems = module.AfterPredicationSystems;
		Init();
	}

	public override void SingleExecute(IAfterPredicationSystem system)
	{
		system.OnAfterPredication();
	}
}

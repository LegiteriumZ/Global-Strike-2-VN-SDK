using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class ResourceInitSystem : FrameworkSystemBase<IResourceInitSystem>
{
	private List<IResourceInitSystem> _systems;

	public override List<IResourceInitSystem> Systems => _systems;

	public ResourceInitSystem(IGameModule module)
	{
		_systems = module.ResourceInitSystems;
		Init();
	}

	public override void SingleExecute(IResourceInitSystem system)
	{
		system.OnInitResources();
	}
}

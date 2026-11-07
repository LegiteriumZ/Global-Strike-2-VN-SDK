using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class PlaybackResourceInitSystem : FrameworkSystemBase<IResourceInitSystem>
{
	private List<IResourceInitSystem> _systems;

	public override List<IResourceInitSystem> Systems => _systems;

	public PlaybackResourceInitSystem(IGameModule module)
	{
		_systems = module.PlaybackResourceInitSystems;
		Init();
	}

	public override void SingleExecute(IResourceInitSystem system)
	{
		system.OnInitResources();
	}
}

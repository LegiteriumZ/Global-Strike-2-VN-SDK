using System.Collections.Generic;
using SSJJBase.Thread;

namespace Assets.Sources.Framework.System;

public class PlaybackResourceLoadSystem : FrameworkSystemBase<IResourceLoadSystem>
{
	private List<IResourceLoadSystem> _systems;

	public override List<IResourceLoadSystem> Systems => _systems;

	public PlaybackResourceLoadSystem(IGameModule module)
	{
		_systems = module.PlaybackResourceLoadSystems;
		Init();
	}

	public override void SingleExecute(IResourceLoadSystem system)
	{
		system.OnLoadResources(BaseAsyncManager.Instance);
	}
}

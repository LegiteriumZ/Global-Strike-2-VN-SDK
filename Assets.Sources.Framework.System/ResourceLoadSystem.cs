using System.Collections.Generic;
using SSJJBase.Thread;

namespace Assets.Sources.Framework.System;

public class ResourceLoadSystem : FrameworkSystemBase<IResourceLoadSystem>
{
	private List<IResourceLoadSystem> _systems;

	public override List<IResourceLoadSystem> Systems => _systems;

	public ResourceLoadSystem(IGameModule module)
	{
		_systems = module.ResourceLoadSystems;
		Init();
	}

	public override void SingleExecute(IResourceLoadSystem system)
	{
		system.OnLoadResources(BaseAsyncManager.Instance);
	}
}

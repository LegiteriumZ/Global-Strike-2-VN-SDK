using System.Collections.Generic;
using SSJJBase.Thread;

namespace Assets.Sources.Framework.System;

public class CommonResourceLoadSystem : FrameworkSystemBase<IResourceLoadSystem>
{
	private List<IResourceLoadSystem> _systems;

	public override List<IResourceLoadSystem> Systems => _systems;

	public CommonResourceLoadSystem(IGameModule module)
	{
		_systems = module.CommonResourceLoadSystems;
		Init();
	}

	public override void SingleExecute(IResourceLoadSystem system)
	{
		system.OnLoadResources(BaseAsyncManager.Instance);
	}
}

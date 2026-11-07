using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class PreRenderSystem : FrameworkSystemBase<IPreRenderSystem>
{
	private List<IPreRenderSystem> _systems;

	public override List<IPreRenderSystem> Systems => _systems;

	public PreRenderSystem(IGameModule module)
	{
		_systems = module.PreRenderSystems;
		Init();
	}

	public override void SingleExecute(IPreRenderSystem system)
	{
		system.OnPreRender();
	}
}

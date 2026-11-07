using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class RenderSystem : FrameworkSystemBase<IRenderSystem>
{
	private List<IRenderSystem> _systems;

	public override List<IRenderSystem> Systems => _systems;

	public RenderSystem(IGameModule module)
	{
		_systems = module.RenderSystems;
		Init();
	}

	public override void SingleExecute(IRenderSystem system)
	{
		system.OnRender();
	}
}

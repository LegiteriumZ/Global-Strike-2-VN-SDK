using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class EntityCreateSystem : FrameworkSystemBase<IEntityCreateSystem>
{
	private List<IEntityCreateSystem> _systems;

	public override List<IEntityCreateSystem> Systems => _systems;

	public EntityCreateSystem(IGameModule module)
	{
		_systems = module.EntityCreateSystems;
		Init();
	}

	public override void SingleExecute(IEntityCreateSystem system)
	{
		system.OnEntityCreate();
	}
}

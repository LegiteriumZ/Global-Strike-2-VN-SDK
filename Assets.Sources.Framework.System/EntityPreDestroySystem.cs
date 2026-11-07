using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class EntityPreDestroySystem : FrameworkSystemBase<IEntityPreDestroySystem>
{
	private List<IEntityPreDestroySystem> _systems;

	public override List<IEntityPreDestroySystem> Systems => _systems;

	public EntityPreDestroySystem(IGameModule module)
	{
		_systems = module.EntityPreDestroySystems;
		Init();
	}

	public override void SingleExecute(IEntityPreDestroySystem system)
	{
		system.OnEntityPreDestroy();
	}
}

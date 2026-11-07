using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public sealed class EntityDestroySystem : FrameworkSystemBase<IEntityDestroySystem>
{
	private List<IEntityDestroySystem> _systems;

	public override List<IEntityDestroySystem> Systems => _systems;

	public EntityDestroySystem(IGameModule module)
	{
		_systems = module.EntityDestroySystems;
		Init();
	}

	public override void SingleExecute(IEntityDestroySystem system)
	{
		system.OnEntityDestroy();
	}
}

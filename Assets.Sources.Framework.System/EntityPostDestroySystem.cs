using System.Collections.Generic;

namespace Assets.Sources.Framework.System;

public class EntityPostDestroySystem : FrameworkSystemBase<IEntityPostDestroySystem>
{
	private List<IEntityPostDestroySystem> _systems;

	public override List<IEntityPostDestroySystem> Systems => _systems;

	public EntityPostDestroySystem(IGameModule module)
	{
		_systems = module.EntityPostDestroySystems;
		Init();
	}

	public override void SingleExecute(IEntityPostDestroySystem system)
	{
		system.OnEntityPostDestroy();
	}
}

using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.EntityDestroy;

public class PlayerEntityDestroyModule : GameModule
{
	public PlayerEntityDestroyModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(new PlayerEntityDestroySystem(contexts));
	}
}

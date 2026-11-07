using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.PyEntity;

public class PlayerPyEntityModule : GameModule
{
	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(new RemovePhysicsEntitySystem(contexts));
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new AddPhysicsEntitySystem(contexts));
	}

	public PlayerPyEntityModule(Contexts contexts)
		: base(contexts)
	{
	}
}

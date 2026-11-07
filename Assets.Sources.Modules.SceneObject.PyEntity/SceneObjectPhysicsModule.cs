using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PyEntity;

public class SceneObjectPhysicsModule : GameModule
{
	public SceneObjectPhysicsModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new SceneObjectPhysicsAddSystem(contexts));
	}

	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
		systems.Add(new SceneObjectPhysicsUpdateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new CBrushDrawSystem(contexts));
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(new SceneObjectPhysicsRemoveSystem(contexts));
	}
}

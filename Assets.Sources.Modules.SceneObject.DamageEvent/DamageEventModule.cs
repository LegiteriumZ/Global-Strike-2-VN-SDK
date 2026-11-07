using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.DamageEvent;

public class DamageEventModule : GameModule
{
	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new DamageEventResourceInitSystem(contexts));
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new DamageEventEntityCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new DamageEventRenderSystem(contexts));
	}

	public DamageEventModule(Contexts contexts)
		: base(contexts)
	{
	}
}

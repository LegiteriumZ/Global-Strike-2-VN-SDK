using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.Accessory;

public class AccessoryModule : GameModule
{
	public AccessoryModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
	}
}

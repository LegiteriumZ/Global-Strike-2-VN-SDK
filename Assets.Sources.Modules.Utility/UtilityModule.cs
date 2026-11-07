using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Utility;

internal class UtilityModule : GameModule
{
	public UtilityModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new UtilityGamobjectActiveSystem(contexts));
	}
}

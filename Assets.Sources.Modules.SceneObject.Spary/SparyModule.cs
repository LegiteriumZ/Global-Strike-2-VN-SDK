using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.Spary;

internal class SparyModule : GameModule
{
	public SparyModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new SparyResourceInitSystem(contexts));
		systems.Add(new WallBloodResourceInitSystem(contexts));
	}
}

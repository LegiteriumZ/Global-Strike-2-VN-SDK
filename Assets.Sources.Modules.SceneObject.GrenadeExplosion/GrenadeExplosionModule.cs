using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.GrenadeExplosion;

public class GrenadeExplosionModule : GameModule
{
	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new GrenadeExplosionEntityCreateSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new GrenadeExplosionResourceInitSystem(contexts));
	}

	public GrenadeExplosionModule(Contexts contexts)
		: base(contexts)
	{
	}
}

using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.HitEffect;

public class HitEffectModule : GameModule
{
	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new HitEffectResourceInitSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new BeingHitEffectPlaySystem(contexts));
	}

	public HitEffectModule(Contexts contexts)
		: base(contexts)
	{
	}
}

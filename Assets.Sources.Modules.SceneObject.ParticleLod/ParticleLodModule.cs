using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.ParticleLod;

public class ParticleLodModule : GameModule
{
	public ParticleLodModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ParticleLodPlaybackSystem(contexts));
	}
}

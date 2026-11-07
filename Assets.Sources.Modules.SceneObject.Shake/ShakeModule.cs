using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.Shake;

public class ShakeModule : GameModule
{
	public ShakeModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new ShakeCreateSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ShakePlaybackSystem(contexts));
	}
}

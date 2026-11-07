using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.HeadScale;

public class HeadScaleModule : GameModule
{
	public HeadScaleModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new HeadScalePlaybackSystem(contexts));
		systems.Add(new PlayerHeadEnlargePlaybackSystem(contexts));
	}
}

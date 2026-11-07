using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.SmallMap;

public class PlayerSmallMapModule : GameModule
{
	public PlayerSmallMapModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerDrawMapImageSystem(contexts));
	}
}

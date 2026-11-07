using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Vip;

public class VipModule : GameModule
{
	public VipModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new VipLevelInitSystem(contexts));
	}
}

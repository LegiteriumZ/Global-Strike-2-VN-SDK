using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Beinghit;

public class BeinghitModule : GameModule
{
	public BeinghitModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new FallingDamageUpdateSystem(contexts));
		systems.Add(new BeinghitUpdateSystem(contexts));
		systems.Add(new BeAttackSystem(contexts));
	}
}

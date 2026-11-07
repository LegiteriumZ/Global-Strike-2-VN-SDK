using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.KillInfo;

public class KillInfoModule : GameModule
{
	public KillInfoModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new CurrKillUpdateSystem(contexts));
		systems.Add(new OneKillInfoUpdateSystem(contexts));
		systems.Add(new ShowKillerUpdateSystem(contexts));
		systems.Add(new JumpTimeSystem(contexts));
		systems.Add(new TeamNameSystem(contexts));
	}
}

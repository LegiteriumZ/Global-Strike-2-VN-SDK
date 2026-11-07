using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.ObserverInfo;

public class ObserverModule : GameModule
{
	public ObserverModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ObserverInfoUpdateSystem(contexts));
		systems.Add(new PeekabooLikesSystem(contexts));
	}
}

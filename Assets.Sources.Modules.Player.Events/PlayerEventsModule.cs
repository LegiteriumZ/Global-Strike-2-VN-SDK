using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Events;

public class PlayerEventsModule : GameModule
{
	public PlayerEventsModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new EventsPlaybackSystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(new EventsPlaySystem(contexts));
		systems.Add(new EventsMessageSystem(contexts));
	}
}

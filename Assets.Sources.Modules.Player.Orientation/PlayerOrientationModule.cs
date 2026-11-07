using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerOrientationModule : GameModule
{
	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerPunchOrientationInitSystem(contexts));
		systems.Add(new PlayerOrientationInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerOrientationPlabackSystem(contexts));
		systems.Add(new OrientationAnimSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerOrientationInitSystem(contexts));
		systems.Add(new PlayerPunchOrientationInitSystem(contexts));
	}

	public PlayerOrientationModule(Contexts contexts)
		: base(contexts)
	{
	}
}

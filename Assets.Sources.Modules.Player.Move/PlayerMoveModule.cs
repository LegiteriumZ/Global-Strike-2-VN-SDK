using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Move;

public class PlayerMoveModule : GameModule
{
	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerMoveInitSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerMoveInitSystem(contexts));
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new CareerChangeSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerViewHeightPlaybackSystem(contexts));
	}

	protected override void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
		systems.Add(new PlayerViewHeightSmoothSystem(contexts));
	}

	public PlayerMoveModule(Contexts contexts)
		: base(contexts)
	{
	}
}

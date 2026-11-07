using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.BulletRail;

public class BulletRailModule : GameModule
{
	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new BulletRailEntityCreateSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new BulletRailResourceInitSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new BulletRailRenderSystem(contexts));
	}

	public BulletRailModule(Contexts contexts)
		: base(contexts)
	{
	}
}

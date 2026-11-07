using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class FirstPersonModule : GameModule
{
	private LoadFirstHandSystem _loadFirstHandSystem;

	private FirstPersonCleanupSystem _cleanFirstHandSystem;

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerViewAnimInitSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerViewAnimInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerViewAnimPlaybackSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new ViewAnimSystem(contexts));
		systems.Add(_loadFirstHandSystem);
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_cleanFirstHandSystem);
		systems.Add(_loadFirstHandSystem);
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(_cleanFirstHandSystem);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_loadFirstHandSystem);
	}

	public FirstPersonModule(Contexts contexts)
		: base(contexts)
	{
		_loadFirstHandSystem = new LoadFirstHandSystem(contexts);
		_cleanFirstHandSystem = new FirstPersonCleanupSystem(contexts);
	}
}

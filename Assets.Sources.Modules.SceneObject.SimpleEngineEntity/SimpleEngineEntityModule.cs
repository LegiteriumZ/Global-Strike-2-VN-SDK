using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.SimpleEngineEntity;

internal class SimpleEngineEntityModule : GameModule
{
	public SimpleEngineEntityModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new SimpleEngineEntityCreateSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new SimpleEngineEntityUpdateSystem(contexts));
		systems.Add(new SimpleEngineEntityUpdateColorSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new SimpleEngineEntityRenderSystem(contexts));
		systems.Add(new SimpleEngineEntityEffectRenderSystem(contexts));
		systems.Add(new SimpleEngineEntityUpdateColorSystem(contexts));
	}
}

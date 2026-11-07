using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.LocalEntityEffect;

public class LocalEntityModule : GameModule
{
	public LocalEntityModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new LocalEntityEffectCreateSystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new LocalEntityEffectRenderSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new LocalEntityEffectAddRenderSystem(contexts));
	}
}

using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

public class LinkObjectModule : GameModule
{
	public LinkObjectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new LinkObjectCreateSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new LinkObjectAddEffectSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new LinkObjectUpdateSystem(contexts));
		systems.Add(new LinkObjectRenderSystem(contexts));
		systems.Add(new LinkObjectStartFinishEffectRenderSystem(contexts));
	}
}

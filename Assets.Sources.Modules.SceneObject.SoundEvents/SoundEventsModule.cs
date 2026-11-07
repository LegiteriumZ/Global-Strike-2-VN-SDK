using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.SoundEvents;

public class SoundEventsModule : GameModule
{
	public SoundEventsModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new SoundEventsPlaySystem(contexts));
	}
}

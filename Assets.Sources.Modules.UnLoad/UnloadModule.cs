using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.UnLoad;

public class UnloadModule : GameModule
{
	public UnloadModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityPostDestroySystems(Contexts contexts, List<IEntityPostDestroySystem> systems)
	{
		systems.Add(new UnloadDestorySystem(contexts));
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(new UnloadThirdPersonResSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new UnloadGamePoolSystem(contexts));
		systems.Add(new UnloadGameSystem(contexts));
	}
}

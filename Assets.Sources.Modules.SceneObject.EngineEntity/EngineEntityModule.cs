using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.EngineEntity;

public class EngineEntityModule : GameModule
{
	public EngineEntityModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new EngineEntityHpBarCreateSystem(contexts));
		systems.Add(new EngineEntityHpBarLoadedSystem(contexts));
		systems.Add(new EngineEntityHpBarUpdateSystem(contexts));
		systems.Add(new EngineEntityHpBarDestroySystem(contexts));
	}
}

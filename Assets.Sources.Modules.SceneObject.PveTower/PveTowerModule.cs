using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PveTower;

public class PveTowerModule : GameModule
{
	public PveTowerModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PveTowerCreateSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PveTowerUpdateSystem(contexts));
		systems.Add(new PveTowerUpdateMsgSystem(contexts));
		systems.Add(new PveTitanUpdateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PveTowerRenderSystem(contexts));
	}
}

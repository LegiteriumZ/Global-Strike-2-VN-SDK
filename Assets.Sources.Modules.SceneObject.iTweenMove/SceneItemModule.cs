using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class SceneItemModule : GameModule
{
	public SceneItemModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new iTweenMoveEntityCreateSystem(contexts));
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new iTweenPredicateInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ITweenMoveEntityDestorySystem(contexts));
	}

	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
		systems.Add(new iTweenPredicateSystem(contexts));
		systems.Add(new PlayerFollowSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new EffectConfigLoadedSystem(contexts));
		systems.Add(new SceneItemLoadSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new SceneItemRenderSystem(contexts));
	}
}

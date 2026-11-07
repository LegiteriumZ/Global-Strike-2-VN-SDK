using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

internal class MoveObjectModule : GameModule
{
	public MoveObjectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new MoveObjectPlaybackSystem(contexts));
		systems.Add(new GravityTailHideSystem(contexts));
		systems.Add(new MoveObjectDrawMapImageSystem(contexts));
		systems.Add(new BlackCrowLookatMessageSystem(contexts));
		systems.Add(new SceneObjectLoadOutlineSystem(contexts));
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new MoveObjectInitSystem(contexts));
		systems.Add(new CustomMoveEntityInitSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new MoveObjectRenderSystem(contexts));
		systems.Add(new CustomMoveEntityRenderSystem(contexts));
		systems.Add(new PredictionEffectRenderSystem(contexts));
	}
}

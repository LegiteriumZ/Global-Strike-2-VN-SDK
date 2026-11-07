using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.WorldCamera;

public class WorldCameraModule : GameModule
{
	protected override void OnAddInitializeSystems(Contexts contexts, List<IModuleInitSystem> systems)
	{
		systems.Add(new WorldCameraInitSystem(contexts));
	}

	protected override void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
		systems.Add(new CameraPathBezierAnimatorSystem(contexts));
		systems.Add(new CameraLogicUpdateSystem(contexts));
		systems.Add(new CameraLogicToTransformSystem(contexts));
		systems.Add(new SwitchPersonViewSystem(contexts));
		systems.Add(new WorldCameraRenderSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new CameraPostProcessSystem(contexts));
	}

	public WorldCameraModule(Contexts contexts)
		: base(contexts)
	{
	}
}

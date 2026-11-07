using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntityModule : GameModule
{
	private CameraEntitySystem _cameraEntitySystem;

	public CameraEntityModule(Contexts contexts)
		: base(contexts)
	{
		_cameraEntitySystem = new CameraEntitySystem(contexts);
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(_cameraEntitySystem);
		systems.Add(new CameraEntityEffectCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new CameraEntityEffectRenderSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(_cameraEntitySystem);
		systems.Add(new CameraEntityEffectDestroySystem(contexts));
		systems.Add(new CameraEntityEffectAddRenderSystem(contexts));
	}
}

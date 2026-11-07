using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

public class SceneWeaponModule : GameModule
{
	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new SceneWeaponPlaybackSystem(contexts));
		systems.Add(new SceneWeaponSmallMapImageSystem(contexts));
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new SceneWeaponEntityInitSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new SceneWeaponRenderSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new SceneWeaponResourceInitSystem(contexts));
	}

	public SceneWeaponModule(Contexts contexts)
		: base(contexts)
	{
	}
}

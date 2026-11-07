using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.BulletHole;

public class BulletHoleModule : GameModule
{
	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new BulletHoleEntityCreateSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(new BulletHoleResourceInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new BulletHolePlayBackSystem(contexts));
	}

	public BulletHoleModule(Contexts contexts)
		: base(contexts)
	{
	}
}

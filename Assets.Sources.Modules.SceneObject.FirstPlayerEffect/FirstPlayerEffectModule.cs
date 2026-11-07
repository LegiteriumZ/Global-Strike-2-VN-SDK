using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.FirstPlayerEffect;

public class FirstPlayerEffectModule : GameModule
{
	public FirstPlayerEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new FirstPlayerEffectCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new FirstPlayerEffectRenderSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new FirstPlayerEffectAddRenderSystem(contexts));
		systems.Add(new FirstPlayerEffectExpireDestroySystem(contexts));
	}
}

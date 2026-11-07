using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;

public class PlayerBaseShowEffectModule : GameModule
{
	public PlayerBaseShowEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerBaseShowEffectCreateSystem(contexts));
		systems.Add(new PlayerViewBaseShowEffectCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PlayerBaseShowEffectRenderSystem(contexts));
		systems.Add(new PlayerViewBaseShowEffectRenderSystem(contexts));
	}
}

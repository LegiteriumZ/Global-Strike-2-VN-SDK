using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerTitleEffectModule : GameModule
{
	public PlayerTitleEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new PlayerTitleEffectCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PlayerTitleEffectRenderSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerTitleEffectExpireDestroySystem(contexts));
	}
}

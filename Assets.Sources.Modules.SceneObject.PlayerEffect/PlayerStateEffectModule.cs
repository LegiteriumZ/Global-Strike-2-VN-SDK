using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerStateEffectModule : GameModule
{
	public PlayerStateEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new PlayerStateEffectCreateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PlayerStateEffectRenderSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerStateEffectAddRenderSystem(contexts));
		systems.Add(new PlayerEffectExpireDestroySystem(contexts));
		systems.Add(new TacticsSoundPlaybackSystem(contexts));
	}
}

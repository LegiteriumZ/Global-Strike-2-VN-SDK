using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.HitBox;

public class PlayerHitBoxModule : GameModule
{
	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
	}

	public PlayerHitBoxModule(Contexts contexts)
		: base(contexts)
	{
	}
}

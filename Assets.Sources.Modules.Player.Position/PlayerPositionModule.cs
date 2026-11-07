using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Shadow;

namespace Assets.Sources.Modules.Player.Position;

public class PlayerPositionModule : GameModule
{
	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerPositionPredicationInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerPositionPlaybackSystem(contexts));
		systems.Add(new UpdatePositionSystem(contexts));
		systems.Add(new PlayerPostionErrorOffsetPreRenderSystem(contexts));
		systems.Add(new PlayerVisiablePlaybackSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new SingleUpdateSelfPositionSystem(contexts));
		systems.Add(new PlayerTpsShadowSystem(contexts));
	}

	protected override void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
	{
	}

	public PlayerPositionModule(Contexts contexts)
		: base(contexts)
	{
	}
}

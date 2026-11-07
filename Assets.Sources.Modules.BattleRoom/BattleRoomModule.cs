using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.BattleRoom;

public class BattleRoomModule : GameModule
{
	protected override void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
	{
		systems.Add(new BattleBeginSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new LoadOutlineOnCameraSystem(contexts));
		systems.Add(new DrawOutLineSystem(contexts));
		systems.Add(new MiniMapDataSystem(contexts));
	}

	public BattleRoomModule(Contexts contexts)
		: base(contexts)
	{
	}
}

using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.NormalBrush;

public class NormalBrushModule : GameModule
{
	public NormalBrushModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new UpdateNormalBrushSystem(contexts));
		systems.Add(new PlayerSimpleTraceSystem(contexts));
	}
}

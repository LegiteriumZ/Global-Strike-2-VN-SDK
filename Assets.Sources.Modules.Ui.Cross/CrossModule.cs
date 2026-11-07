using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Cross;

internal class CrossModule : GameModule
{
	public CrossModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new CrossSpreadUpdateSystem(contexts));
		systems.Add(new AwpCrossUpdateSystem(contexts));
		systems.Add(new AddHpCrossUpdateSystem(contexts));
		systems.Add(new HideCrossUpdateSystem(contexts));
		systems.Add(new HitCrossUpdateSystem(contexts));
	}
}

using System.Collections.Generic;
using Assets.Scripts.SSJJProfiler;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Utils;

public class UiUtilsModule : GameModule
{
	public UiUtilsModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new NotifySystem(contexts));
		systems.Add(new DeviceProfilerSystem());
	}
}

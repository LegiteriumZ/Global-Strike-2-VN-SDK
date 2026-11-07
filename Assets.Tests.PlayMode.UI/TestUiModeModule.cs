using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Modules.Ui.Utils;

namespace Assets.Tests.PlayMode.UI;

public class TestUiModeModule<T> : GameModule where T : AbstractMode
{
	private readonly TestUiModeDelegate<T> _delegate;

	public TestUiModeModule(Contexts contexts)
		: base(contexts)
	{
		_delegate = new TestUiModeDelegate<T>(contexts);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_delegate);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(_delegate);
		systems.Add(new NotifySystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_delegate);
	}
}

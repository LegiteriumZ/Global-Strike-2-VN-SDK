using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Mode;

namespace Assets.Tests.PlayMode.Cross;

public class TestCrossUiModeModule<T> : GameModule where T : AbstractMode
{
	private readonly TestCrossUiModeDelegate<T> _delegate;

	public TestCrossUiModeModule(Contexts contexts)
		: base(contexts)
	{
		_delegate = new TestCrossUiModeDelegate<T>(contexts);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_delegate);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(_delegate);
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_delegate);
	}
}

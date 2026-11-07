using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Tests.PlayMode.Cross;

public class TestSniperCrossMode : AbstractMode
{
	public TestSniperCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
	}
}

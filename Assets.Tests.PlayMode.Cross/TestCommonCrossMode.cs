using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Tests.PlayMode.Cross;

public class TestCommonCrossMode : AbstractMode
{
	public TestCommonCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
	}
}

using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Tests.PlayMode.Cross;

public class TestHitCrossMode : AbstractMode
{
	public TestHitCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
		AddPlaybackSystem(new HitCrossModel());
	}
}

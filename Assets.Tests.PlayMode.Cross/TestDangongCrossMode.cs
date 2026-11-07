using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Weapon;

namespace Assets.Tests.PlayMode.Cross;

public class TestDangongCrossMode : AbstractMode
{
	public TestDangongCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
		AddPlaybackSystem(new DangongCrossModel());
	}
}

using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Weapon;

namespace Assets.Tests.PlayMode.Cross;

public class TestUsp45DevilCrossMode : AbstractMode
{
	public TestUsp45DevilCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
		AddPlaybackSystem(new RedpointModel());
	}
}

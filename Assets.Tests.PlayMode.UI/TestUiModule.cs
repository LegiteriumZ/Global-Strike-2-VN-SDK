using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.Player;

namespace Assets.Tests.PlayMode.UI;

public class TestUiModule : CompositeGameModule
{
	public TestUiModule(Contexts contexts)
	{
		PlayerContextResourceInfo playerContextResourceInfo = new PlayerContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, playerContextResourceInfo, playerContextResourceInfo, null));
	}
}

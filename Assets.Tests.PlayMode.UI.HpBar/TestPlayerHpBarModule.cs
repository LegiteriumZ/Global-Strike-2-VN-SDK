using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.SceneObject.PlayerHpBar;

namespace Assets.Tests.PlayMode.UI.HpBar;

public class TestPlayerHpBarModule : CompositeGameModule
{
	public TestPlayerHpBarModule(Contexts contexts)
	{
		SceneObjectContextResourceInfo sceneObjectContextResourceInfo = new SceneObjectContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo, null));
		AddModule(new PlayerHpBarModule(contexts));
	}
}

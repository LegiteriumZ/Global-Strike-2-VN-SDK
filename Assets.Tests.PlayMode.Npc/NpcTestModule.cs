using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.SceneObject.NewNpc;

namespace Assets.Tests.PlayMode.Npc;

public class NpcTestModule : CompositeGameModule
{
	public NpcTestModule(Contexts contexts)
	{
		SceneObjectContextResourceInfo sceneObjectContextResourceInfo = new SceneObjectContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo, null));
		AddModule(new NewNpcModule(contexts));
	}
}

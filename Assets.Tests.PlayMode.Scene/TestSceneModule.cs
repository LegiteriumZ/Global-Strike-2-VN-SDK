using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.Player;
using Assets.Sources.Modules.Player.Anim;
using Assets.Sources.Modules.Player.Move;
using Assets.Sources.Modules.Player.Orientation;
using Assets.Sources.Modules.Player.Position;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.SceneObject.SceneMap;
using Assets.Sources.Modules.WorldCamera;

namespace Assets.Tests.PlayMode.Scene;

public class TestSceneModule : CompositeGameModule
{
	public TestSceneModule(Contexts contexts)
	{
		PlayerContextResourceInfo playerContextResourceInfo = new PlayerContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, playerContextResourceInfo, playerContextResourceInfo, null));
		AddModule(new PlayerOrientationModule(contexts));
		AddModule(new PlayerPositionModule(contexts));
		AddModule(new PlayerMoveModule(contexts));
		AddModule(new PlayerAnimModule(contexts));
		SceneObjectContextResourceInfo sceneObjectContextResourceInfo = new SceneObjectContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo));
		AddModule(new SceneMapModule(contexts));
		AddModule(new WorldCameraModule(contexts));
	}
}

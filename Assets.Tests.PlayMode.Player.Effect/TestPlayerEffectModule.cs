using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.Player;
using Assets.Sources.Modules.Player.Accessory;
using Assets.Sources.Modules.Player.Anim;
using Assets.Sources.Modules.Player.Effect;
using Assets.Sources.Modules.Player.EntityDestroy;
using Assets.Sources.Modules.Player.Position;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.SceneObject.PlayerEffect;
using Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;
using Assets.Sources.Modules.SceneObject.SceneMap;
using Assets.Sources.Modules.WorldCamera;

namespace Assets.Tests.PlayMode.Player.Effect;

public class TestPlayerEffectModule : CompositeGameModule
{
	public TestPlayerEffectModule(Contexts contexts)
	{
		PlayerContextResourceInfo playerContextResourceInfo = new PlayerContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, playerContextResourceInfo, playerContextResourceInfo, null));
		AddModule(new PlayerPositionModule(contexts));
		AddModule(new PlayerAnimModule(contexts));
		AddModule(new PlayerEffectModule(contexts));
		AddModule(new PlayerEntityDestroyModule(contexts));
		AddModule(new PlayerAccessoryModule(contexts));
		SceneObjectContextResourceInfo sceneObjectContextResourceInfo = new SceneObjectContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo));
		AddModule(new PlayerStateEffectModule(contexts));
		AddModule(new PlayerBaseShowEffectModule(contexts));
		AddModule(new SceneMapModule(contexts));
		AddModule(new WorldCameraModule(contexts));
	}
}

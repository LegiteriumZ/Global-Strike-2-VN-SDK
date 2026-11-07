using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.Player;
using Assets.Sources.Modules.Player.Accessory;
using Assets.Sources.Modules.Player.Anim;
using Assets.Sources.Modules.Player.EntityDestroy;
using Assets.Sources.Modules.Player.Position;

namespace Assets.Tests.PlayMode.Weapon;

public class TestWeaponModule : CompositeGameModule
{
	public TestWeaponModule(Contexts contexts)
	{
		PlayerContextResourceInfo playerContextResourceInfo = new PlayerContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, playerContextResourceInfo, playerContextResourceInfo, null));
		AddModule(new PlayerPositionModule(contexts));
		AddModule(new PlayerAnimModule(contexts));
		AddModule(new PlayerAccessoryModule(contexts));
		AddModule(new PlayerEntityDestroyModule(contexts));
		AddModule(new PlayerPredicationModule(contexts));
	}
}

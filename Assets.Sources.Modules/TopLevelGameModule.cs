using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Modules.Player;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.SceneObject.PyEntity;
using Assets.Sources.Modules.SceneObject.SceneWeapon;
using Assets.Sources.Modules.SceneObject.ShowBodyEffect;
using Assets.Sources.Modules.SceneObject.Tail;
using Assets.Sources.Modules.SceneObject.iTweenMove;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.UnLoad;
using Assets.Sources.Modules.Utility;
using Assets.Sources.Modules.WorldCamera;

namespace Assets.Sources.Modules;

public sealed class TopLevelGameModule : CompositeGameModule
{
	public TopLevelGameModule(Contexts contexts)
	{
		AddModule(new BattleRoomModule(contexts));
		AddModule(new SceneObjectModule(contexts));
		AddModule(new PlayerModule(contexts));
		AddModule(new ShowBodyEffectModule(contexts));
		AddModule(new SceneItemModule(contexts));
		AddModule(new SceneObjectPhysicsModule(contexts));
		AddModule(new SceneWeaponModule(contexts));
		AddModule(new WorldCameraModule(contexts));
		AddModule(new UiModule(contexts));
		AddModule(new TailModule(contexts));
		AddModule(new UtilityModule(contexts));
		AddModule(new UnloadModule(contexts));
	}
}

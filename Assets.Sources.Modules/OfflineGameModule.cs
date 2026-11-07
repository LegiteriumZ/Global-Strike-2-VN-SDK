using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Modules.Player;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Modules.WorldCamera;

namespace Assets.Sources.Modules;

public sealed class OfflineGameModule : CompositeGameModule
{
	public OfflineGameModule(Contexts contexts)
	{
		AddModule(new BattleRoomModule(contexts));
		AddModule(new WorldCameraModule(contexts));
		AddModule(new SceneObjectModule(contexts));
		AddModule(new PlayerModule(contexts));
	}
}

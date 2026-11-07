using Assets.Sources.Systems.PacketHandle.Handlers;

namespace Assets.Sources.Systems.PacketHandle;

public sealed class PacketHandleFeature : Feature
{
	public PacketHandleFeature(Contexts contexts)
	{
		Add(new BattleServerErrorHandleSystem(contexts));
		Add(new BattleServerUpdateSystem(contexts.battleServer));
		Add(new SendP2PPackageSystem(contexts));
		Add(new BattleServerReConnectSystem(contexts));
		Add(new PacketHandlerInitSystem(contexts));
		Add(new DummyHandlerSystem(contexts));
		Add(new BattleServerCleanupSystem(contexts));
	}
}

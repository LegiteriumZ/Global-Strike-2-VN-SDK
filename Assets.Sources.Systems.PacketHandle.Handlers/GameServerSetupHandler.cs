using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GameServerSetupHandler : ApcPacketHandler<GameServerSetupData>
{
	public GameServerSetupHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 44;
	}

	public override void Handle(GameServerSetupData data)
	{
	}
}

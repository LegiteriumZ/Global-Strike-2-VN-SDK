using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PlayerLoginOnInitDataHandler : ApcPacketHandler<OnGameinitData>
{
	public PlayerLoginOnInitDataHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 232;
	}

	public override void Handle(OnGameinitData data)
	{
	}
}

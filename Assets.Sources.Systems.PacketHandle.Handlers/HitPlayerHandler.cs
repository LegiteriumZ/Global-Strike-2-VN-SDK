using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HitPlayerHandler : ApcPacketHandler<GameServerSetupData>
{
	private CrossContext _crossContext;

	public HitPlayerHandler(Contexts contexts)
	{
		_crossContext = contexts.cross;
	}

	public override int MethodId()
	{
		return 131;
	}

	public override void Handle(GameServerSetupData data)
	{
		_crossContext.hitCross.ChangRedTime = 200;
	}
}

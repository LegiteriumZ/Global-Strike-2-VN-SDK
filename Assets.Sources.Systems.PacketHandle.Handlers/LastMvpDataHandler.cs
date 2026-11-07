using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class LastMvpDataHandler : ApcPacketHandler<LastMvpData>
{
	private BattleRoomContext _battleRoomContext;

	public LastMvpDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 17;
	}

	public override void Handle(LastMvpData data)
	{
		_battleRoomContext.bestKill.LastMvpData = data;
	}
}

using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BeKillHandler : ApcPacketHandler<IntData>
{
	private BattleRoomContext _battleRoomContext;

	public BeKillHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 7;
	}

	public override void Handle(IntData data)
	{
		_battleRoomContext.roomData.ReLiveTime = data.Data;
	}
}

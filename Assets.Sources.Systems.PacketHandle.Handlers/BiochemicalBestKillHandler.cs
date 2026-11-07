using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BiochemicalBestKillHandler : ApcPacketHandler<BiochemicalBestData>
{
	private BattleRoomContext _battleRoomContext;

	public BiochemicalBestKillHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 60;
	}

	public override void Handle(BiochemicalBestData data)
	{
		_battleRoomContext.bestKill.BiochemicalBestData = data;
	}
}

using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GroupBestKillHandler : ApcPacketHandler<GroupBestKillData>
{
	private BattleRoomContext _battleRoomContext;

	public GroupBestKillHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 29;
	}

	public override void Handle(GroupBestKillData data)
	{
		_battleRoomContext.bestKill.GroupBestData = data;
	}
}

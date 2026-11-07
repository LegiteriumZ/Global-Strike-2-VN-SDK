using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PlayerSkillAdditionalHandler : ApcPacketHandler<PlayerSkillAdditionalData>
{
	private BattleRoomContext _battleRoomContext;

	public PlayerSkillAdditionalHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 51;
	}

	public override void Handle(PlayerSkillAdditionalData data)
	{
		_battleRoomContext.playerInfo.MyPlayerSkillAdditionalData = EntityDataExtension.ClonePlayerSkillAdditionalData(data, _battleRoomContext.playerInfo.MyPlayerSkillAdditionalData);
	}
}

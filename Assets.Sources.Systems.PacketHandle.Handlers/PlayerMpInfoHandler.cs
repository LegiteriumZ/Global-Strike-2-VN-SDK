using Assets.Sources.Components.BattleRoom;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlayerMpInfoHandler : ApcPacketHandler<MpInfoData>
{
	private PlayerInfoComponent _playerInfo;

	public PlayerMpInfoHandler(Contexts contexts)
	{
		_playerInfo = contexts.battleRoom.playerInfo;
	}

	public override int MethodId()
	{
		return 238;
	}

	public override void Handle(MpInfoData data)
	{
		_playerInfo.PlayerMpDic[data.Cid] = data.Mp;
	}
}

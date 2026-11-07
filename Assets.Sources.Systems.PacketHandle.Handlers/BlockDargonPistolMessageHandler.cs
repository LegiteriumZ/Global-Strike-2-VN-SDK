using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Utils.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BlockDargonPistolMessageHandler : ApcPacketHandler<FloatArrayData>
{
	private BattleRoomContext _battleRoomContext;

	public BlockDargonPistolMessageHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 501;
	}

	public override void Handle(FloatArrayData data)
	{
		LobbyInfoComponent lobbyInfo = _battleRoomContext.lobbyInfo;
		PlayerEntity playerEntity = null;
		if (lobbyInfo.Id2CidDic.TryGetValue((int)data.Data[2], out var value))
		{
			playerEntity = PlayerUtility.GetPlayerByCid(value);
		}
		if (playerEntity != null && playerEntity.hasDunHpShow)
		{
			playerEntity.dunHpShow.showMinNum = data.Data[0];
			playerEntity.dunHpShow.showMaxNum = data.Data[1];
		}
	}
}

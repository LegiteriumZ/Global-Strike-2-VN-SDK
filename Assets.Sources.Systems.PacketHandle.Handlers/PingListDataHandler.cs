using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PingListDataHandler : ApcPacketHandler<PingListData>
{
	private BattleRoomContext _battleRoomContext;

	private Dictionary<int, OneKillInfoData> _cache = new Dictionary<int, OneKillInfoData>();

	public PingListDataHandler(Contexts context)
	{
		_battleRoomContext = context.battleRoom;
	}

	public override int MethodId()
	{
		return 24;
	}

	public override void Handle(PingListData data)
	{
		foreach (OneKillInfoData item in _battleRoomContext.playerInfo.All)
		{
			_cache[item.Id] = item;
		}
		for (int i = 0; i < data.List.Count; i++)
		{
			PlayerPingData playerPingData = data.List[i];
			if (playerPingData != null)
			{
				if (_cache.ContainsKey(playerPingData.Id))
				{
					_cache[playerPingData.Id].Ping = playerPingData.Ping;
				}
				_battleRoomContext.playerInfo.PingMap[playerPingData.Id] = playerPingData.Ping;
			}
		}
		_cache.Clear();
	}
}

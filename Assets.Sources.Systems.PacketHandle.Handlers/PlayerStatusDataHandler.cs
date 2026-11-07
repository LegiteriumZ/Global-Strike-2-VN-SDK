using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Core.Utils.System46;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PlayerStatusDataHandler : ApcPacketHandler<PlayerTcpStautsData>
{
	private BattleRoomContext _battleRoomContext;

	public PlayerStatusDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 116;
	}

	public override void Handle(PlayerTcpStautsData data)
	{
		PlayerInfoComponent playerInfo = _battleRoomContext.playerInfo;
		long cid = data.Cid;
		if (!playerInfo.StatusDatas.ContainsKey(cid))
		{
			playerInfo.StatusDatas.Add(cid, new MyDictionary<int, PlayerInfoComponent.StatusDes>());
		}
		IMyDictionary<int, PlayerInfoComponent.StatusDes> myDictionary = playerInfo.StatusDatas[cid];
		if (data.Value)
		{
			PlayerInfoComponent.StatusDes statusDes = new PlayerInfoComponent.StatusDes();
			statusDes.Number = data.Num;
			statusDes.Scale = data.Scale;
			myDictionary[data.Key] = statusDes;
		}
		else
		{
			myDictionary.Remove(data.Key);
		}
	}
}

using Assets.Sources.Free.Data;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class AllObserverNameHandler : ApcPacketHandler<ObserverNameData>
{
	private BattleRoomContext _battleRoomContext;

	public AllObserverNameHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 42;
	}

	public override void Handle(ObserverNameData data)
	{
		UIDataManager.Instance.AllObserverNameData.ObserverNameChanged(data);
		_battleRoomContext.playerInfo.ObserverList = data.PlayerName;
	}
}

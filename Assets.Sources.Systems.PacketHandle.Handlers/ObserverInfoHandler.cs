using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ObserverInfoHandler : ApcPacketHandler<ObserverInfoData>
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public ObserverInfoHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 30;
	}

	public override void Handle(ObserverInfoData data)
	{
		_battleRoomContext.playerInfo.ObserverInfoDatas[data.Id] = data;
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(data.Id);
		if (entityWithEntityId != null)
		{
			if (entityWithEntityId.hasObserverInfo)
			{
				entityWithEntityId.observerInfo.Data = data;
			}
			entityWithEntityId.isShowObserver = true;
		}
	}
}

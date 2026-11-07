using System.Collections.Generic;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.ObserverInfo;

public class ObserverInfoUpdateSystem : IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public ObserverInfoUpdateSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		foreach (KeyValuePair<int, ObserverInfoData> observerInfoData in _battleRoomContext.playerInfo.ObserverInfoDatas)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(observerInfoData.Key);
			if (entityWithEntityId != null)
			{
				if (!entityWithEntityId.hasObserverInfo)
				{
					entityWithEntityId.AddObserverInfo(null);
				}
				entityWithEntityId.observerInfo.Data = observerInfoData.Value;
			}
		}
	}
}

using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.KillInfo;

public class OneKillInfoUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	public OneKillInfoUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		foreach (OneKillInfoData item in _battleRoomContext.playerInfo.All)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.Id);
			if (entityWithEntityId != null)
			{
				entityWithEntityId.oneKillInfo.Data = item;
			}
		}
	}
}

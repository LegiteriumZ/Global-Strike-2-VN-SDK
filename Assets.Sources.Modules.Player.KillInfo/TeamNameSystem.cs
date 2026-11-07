using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.KillInfo;

public class TeamNameSystem : IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public TeamNameSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		foreach (OneKillInfoData item in _battleRoomContext.playerInfo.All)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item.Id);
			if (entityWithEntityId != null && !entityWithEntityId.hasTeamName)
			{
				entityWithEntityId.AddTeamName(item.TeamName);
			}
		}
	}
}

using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.KillInfo;

public class CurrKillUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	public CurrKillUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (item.hasBasicInfo && _battleRoomContext.playerInfo.CurrKillNums.TryGetValue(item.GetId(), out var value))
			{
				item.currKill.Count = value;
			}
		}
	}
}

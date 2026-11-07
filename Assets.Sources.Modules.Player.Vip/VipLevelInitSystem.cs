using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Vip;

public class VipLevelInitSystem : IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	public VipLevelInitSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (item.hasBasicInfo && !item.hasVip)
			{
				int value = 0;
				if (_battleRoomContext.playerInfo.VipLevels.TryGetValue(item.basicInfo.PlayerName, out value))
				{
					item.AddVip(value);
				}
			}
		}
	}
}

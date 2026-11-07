using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Player;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerMpPlayBackSystem : IPlaybackSystem
{
	private readonly BattleRoomContext _battleRoomContext;

	public PlayerMpPlayBackSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		foreach (KeyValuePair<long, int> item in _battleRoomContext.playerInfo.PlayerMpDic)
		{
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(item.Key);
			if (playerByCid != null)
			{
				if (playerByCid.hasMp)
				{
					playerByCid.mp.Mp = item.Value;
				}
				else
				{
					playerByCid.AddMp(item.Value);
				}
			}
		}
	}
}

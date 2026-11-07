using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.GameRule.GoldExplode;

public class GoldExplodeInBuyAreaSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	public GoldExplodeInBuyAreaSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
	}

	public void OnPlayback()
	{
		if (_gameRuleContext.goldExplodeBuyAreaData.BuyArea == null)
		{
			return;
		}
		Vector3 uiMyPlayer_Position = UiIEventCondition.Get_uiMyPlayer_Position();
		Vector3 vector = new Vector3(uiMyPlayer_Position.x, uiMyPlayer_Position.y, uiMyPlayer_Position.z);
		BuyAreaListData buyArea = _gameRuleContext.goldExplodeBuyAreaData.BuyArea;
		int uiMyPlayer_Team = UiIEventCondition.Get_uiMyPlayer_Team();
		for (int i = 0; i < buyArea.Area.Count; i++)
		{
			if (buyArea.Area[i].BuyTeam == uiMyPlayer_Team && !(vector.x < (float)buyArea.Area[i].Min[0]) && !(vector.x > (float)buyArea.Area[i].Max[0]) && !(vector.y < (float)buyArea.Area[i].Min[1]) && !(vector.y > (float)buyArea.Area[i].Max[1]) && !(vector.z < (float)buyArea.Area[i].Min[2]) && !(vector.z > (float)buyArea.Area[i].Max[2]))
			{
				_gameRuleContext.goldExplodeBuyAreaData.InBuyArea = true;
				return;
			}
		}
		_gameRuleContext.goldExplodeBuyAreaData.InBuyArea = false;
	}

	public bool NeedStart(Contexts contexts)
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (raceType != 61)
		{
			return raceType == 27;
		}
		return true;
	}
}

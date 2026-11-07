using System.Collections.Generic;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.GameRule.Pve;

public class PveScoreRankUpdateSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	public PveScoreRankUpdateSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
	}

	public void OnPlayback()
	{
		long num = 0L;
		long num2 = 0L;
		List<OneKillInfoData> team = _battleRoomContext.playerInfo.Team2;
		int count = _battleRoomContext.playerInfo.Team2.Count;
		for (int i = 0; i < count; i++)
		{
			num += team[i].Score;
			num2 = ((num2 < team[i].Score) ? team[i].Score : num2);
		}
		_gameRuleContext.pveScoreRank.FirstScore = num2;
		_gameRuleContext.pveScoreRank.TotalScore = num;
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsPve();
	}
}

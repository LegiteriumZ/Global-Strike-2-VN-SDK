using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.Dead;

public class PveScoreRankSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private TimeComponent _time;

	public PveScoreRankSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_gameRuleContext.currentRule.Rule.IsPve())
		{
			return;
		}
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasPveScoreRank)
			{
				item.AddPveScoreRank(0f);
			}
			if (item.basicInfo.IsDead)
			{
				PlayerInfoData playerInfo = item.GetPlayerInfo();
				item.pveScoreRank.RelivePercent += (float)_time.FrameInterval / (float)playerInfo.MaxReliveTime;
			}
			else
			{
				item.pveScoreRank.RelivePercent = 0f;
			}
		}
	}
}

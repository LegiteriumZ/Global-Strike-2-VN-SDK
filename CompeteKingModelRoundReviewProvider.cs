using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using NetData;

public class CompeteKingModelRoundReviewProvider : ICompeteKingModelRoundReviewProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected TimeContext _timeContext;

	private ISSJJTimer _timer;

	public CompeteKingModelRoundReviewProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTSHOWREVIEW", out _timer);
	}

	public bool IsShow()
	{
		return _timer != null;
	}

	public string SetMessage()
	{
		if (!_gameRuleContext.hasGunFightData || _playerContext.cameraOwnerEntity == null)
		{
			return "";
		}
		return _gameRuleContext.gunFightData.ReviewType switch
		{
			GunFightMessageType.RoundEnd => $"/ui/GameGUIRes/CompeteKingModel/RoundReview/Round{SetMessageHelper(_gameRuleContext.gunFightData.RoundWinner)}", 
			GunFightMessageType.GameEnd => $"/ui/GameGUIRes/CompeteKingModel/RoundReview/Game{SetMessageHelper(_gameRuleContext.gunFightData.GameWinner)}", 
			GunFightMessageType.HotScore => $"/ui/GameGUIRes/CompeteKingModel/RoundReview/MatchPoint", 
			_ => "", 
		};
	}

	protected string SetMessageHelper(int winner)
	{
		if (_playerContext.cameraOwnerEntity.basicInfo.Current.Team != winner)
		{
			if (winner != 0)
			{
				return "Defeat";
			}
			return "Draw";
		}
		return "Victory";
	}

	public string SetFlag(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null)
		{
			return "";
		}
		if (index >= _gameRuleContext.gunFightData.TeamRank.Count)
		{
			return "";
		}
		if (index == 0)
		{
			return $"/ui/GameGUIRes/CompeteKingModel/RoundReview/Team{_gameRuleContext.gunFightData.TeamRank[index] + 1}FlagL";
		}
		return $"/ui/GameGUIRes/CompeteKingModel/RoundReview/Team{_gameRuleContext.gunFightData.TeamRank[index] + 1}FlagS";
	}

	public float SetScore(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null)
		{
			return 0f;
		}
		if (index >= _gameRuleContext.gunFightData.TeamScores.Count)
		{
			return 0f;
		}
		return _gameRuleContext.gunFightData.TeamScores[_gameRuleContext.gunFightData.TeamRank[index]];
	}
}

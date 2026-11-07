using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using NetData;

public class goldRankModelRoundReviewProvider : IgoldRankModelRoundReviewProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	protected TimeContext _timeContext;

	private ISSJJTimer _timer;

	public goldRankModelRoundReviewProvider(Contexts contexts)
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
			GunFightMessageType.RoundEnd => $"/ui/GameGUIRes/gunFightModel/review/{SetTeamName()}round{SetMessageHelper(_gameRuleContext.gunFightData.RoundWinner)}", 
			GunFightMessageType.GameEnd => $"/ui/GameGUIRes/gunFightModel/review/{SetTeamName()}{SetMessageHelper(_gameRuleContext.gunFightData.GameWinner)}", 
			GunFightMessageType.HotScore => $"/ui/GameGUIRes/gunFightModel/review/matchpoint", 
			_ => "", 
		};
	}

	protected string SetTeamName()
	{
		if (_playerContext.cameraOwnerEntity.basicInfo.Current.Team != 1)
		{
			return "blue";
		}
		return "red";
	}

	protected string SetMessageHelper(int winner)
	{
		if (_playerContext.cameraOwnerEntity.basicInfo.Current.Team != winner)
		{
			if (winner != 0)
			{
				return "defeat";
			}
			return "draw";
		}
		return "victory";
	}

	public float SetScore(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null || _gameRuleContext.gunFightData.TeamScores.Count == 0)
		{
			return 0f;
		}
		return _gameRuleContext.gunFightData.TeamScores[index];
	}
}

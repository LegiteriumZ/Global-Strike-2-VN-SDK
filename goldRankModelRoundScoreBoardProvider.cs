using Assets.Sources.Components.Time;

public class goldRankModelRoundScoreBoardProvider : IgoldRankModelRoundScoreBoardProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public goldRankModelRoundScoreBoardProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool SetRedScore(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null || _gameRuleContext.gunFightData.TeamScores.Count == 0)
		{
			return false;
		}
		int num = _gameRuleContext.gunFightData.TeamScores[0];
		if (index >= num)
		{
			return false;
		}
		return true;
	}

	public bool SetBlueScoreShow(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null || _gameRuleContext.gunFightData.TeamScores.Count == 0)
		{
			return false;
		}
		int num = _gameRuleContext.gunFightData.TeamScores[1];
		if (index >= num)
		{
			return false;
		}
		return true;
	}

	public float SetRoundScore(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null || _gameRuleContext.gunFightData.TeamScores.Count == 0)
		{
			return 0f;
		}
		return _gameRuleContext.gunFightData.TeamScores[index];
	}
}

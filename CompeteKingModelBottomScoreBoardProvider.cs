using Assets.Sources.Components.Time;

public class CompeteKingModelBottomScoreBoardProvider : ICompeteKingModelBottomScoreBoardProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public CompeteKingModelBottomScoreBoardProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool SetScore(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.TeamScores == null || _gameRuleContext.gunFightData.TeamScores.Count == 0)
		{
			return false;
		}
		int num = index / 5;
		if (num >= _gameRuleContext.gunFightData.TeamScores.Count)
		{
			return false;
		}
		int num2 = _gameRuleContext.gunFightData.TeamScores[num];
		if (index % 5 >= num2)
		{
			return false;
		}
		return true;
	}
}

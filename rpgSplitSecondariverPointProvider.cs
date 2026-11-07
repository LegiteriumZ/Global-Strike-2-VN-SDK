using Assets.Sources.Components.Time;

public class rpgSplitSecondariverPointProvider : IrpgSplitSecondariverPointProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgSplitSecondariverPointProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float GetFirstPoint()
	{
		return _gameRuleContext.splitSecond.AriveFirstPoint;
	}

	public float GetAllPoint()
	{
		return _gameRuleContext.splitSecond.AriveAllPoint;
	}

	public float GetRank()
	{
		return _gameRuleContext.splitSecond.Rank;
	}
}

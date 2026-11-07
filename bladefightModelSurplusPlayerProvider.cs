using Assets.Sources.Components.Time;

public class bladefightModelSurplusPlayerProvider : IbladefightModelSurplusPlayerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelSurplusPlayerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getSurplusCount()
	{
		return _gameRuleContext.bladeFightSurplusPlayerData.surplusPlayerCount - 1;
	}

	public bool isGameStart()
	{
		return _gameRuleContext.bladeFightSurplusPlayerData.isGameStart;
	}
}

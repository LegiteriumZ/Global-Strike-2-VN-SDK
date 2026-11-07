using Assets.Sources.Components.Time;

public class bladefightModelReliveProvider : IbladefightModelReliveProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelReliveProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShowReliveCount1()
	{
		return _gameRuleContext.bladeFightReliveData.reliveCount > 0;
	}

	public float getReliveCount()
	{
		return _gameRuleContext.bladeFightReliveData.reliveCount;
	}

	public bool isGameStart()
	{
		return _gameRuleContext.bladeFightReliveData.isGameStart;
	}
}

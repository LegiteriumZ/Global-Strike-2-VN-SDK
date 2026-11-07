using Assets.Sources.Components.Time;

public class bladefightModelWaitPlayerProvider : IbladefightModelWaitPlayerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelWaitPlayerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameRuleContext.bladeFightWaitStartData.currentTime += time.FrameInterval;
	}

	public float getCurrentPlayerCount()
	{
		return _gameRuleContext.bladeFightWaitStartData.currentPlayerCount;
	}

	public bool isShowTime()
	{
		return _gameRuleContext.bladeFightWaitStartData.waitTimeState != 3;
	}

	public float getCurrentTime()
	{
		return (float)_gameRuleContext.bladeFightWaitStartData.currentTime / 1000f;
	}

	public float getMaxPlayerCount()
	{
		return _gameRuleContext.bladeFightWaitStartData.maxPlayerCount;
	}

	public float getMaxTime()
	{
		return (float)_gameRuleContext.bladeFightWaitStartData.maxTime / 1000f;
	}

	public bool isWaitGameStart()
	{
		return _gameRuleContext.bladeFightWaitStartData.isWaitPlayer;
	}
}

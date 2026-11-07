using Assets.Sources.Components.Time;

public class bladefightModelfogAreaTimeProvider : IbladefightModelfogAreaTimeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelfogAreaTimeProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameRuleContext.bladeFightFogAreaTimeData.time -= time.FrameInterval;
		if (_gameRuleContext.bladeFightFogAreaTimeData.time < 0)
		{
			_gameRuleContext.bladeFightFogAreaTimeData.time = 0;
		}
	}

	public float getMinute()
	{
		int num = _gameRuleContext.bladeFightFogAreaTimeData.time / 1000;
		return (num - num % 60) / 60;
	}

	public float getSecond()
	{
		return _gameRuleContext.bladeFightFogAreaTimeData.time / 1000 % 60;
	}

	public bool isGameStart()
	{
		return _gameRuleContext.bladeFightFogAreaTimeData.isGameStart;
	}
}

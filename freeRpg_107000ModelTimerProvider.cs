using Assets.Sources.Components.Time;

public class freeRpg_107000ModelTimerProvider : IfreeRpg_107000ModelTimerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelTimerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.LeftTime > 0)
		{
			_gameRuleContext.mystery.LeftTime -= time.FrameInterval;
		}
	}

	public float RefreshMinute()
	{
		return _gameRuleContext.mystery.LeftTime / 1000 / 60;
	}

	public float SetPlayerNumber()
	{
		return _gameRuleContext.mystery.PlayerNumber;
	}

	public float RefreshSecond()
	{
		return _gameRuleContext.mystery.LeftTime / 1000 % 60;
	}
}

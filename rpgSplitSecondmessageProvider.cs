using Assets.Sources.Components.Time;

public class rpgSplitSecondmessageProvider : IrpgSplitSecondmessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgSplitSecondmessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.splitSecond.CancelCollsionAllTime > 0)
		{
			_gameRuleContext.splitSecond.CancelCollsionAllTime -= time.FrameInterval;
		}
		if (_gameRuleContext.splitSecond.GetSpeedAllTime > 0)
		{
			_gameRuleContext.splitSecond.GetSpeedAllTime -= time.FrameInterval;
		}
	}

	public bool IsShowCancelCollsion()
	{
		return _gameRuleContext.splitSecond.CancelCollsionAllTime > 0;
	}

	public bool IsShowGetSpeed()
	{
		return _gameRuleContext.splitSecond.GetSpeedAllTime > 0;
	}
}

using Assets.Sources.Components.Time;

public class bioUnionBaseWaitPlayerUIProvider : IbioUnionBaseWaitPlayerUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bioUnionBaseWaitPlayerUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.bioUnionBaseData.balancePlayerTimeCountDown > 0)
		{
			_gameRuleContext.bioUnionBaseData.balancePlayerTimeCountDown -= time.FrameInterval;
			if (_gameRuleContext.bioUnionBaseData.balancePlayerTimeCountDown <= 0)
			{
				_gameRuleContext.bioUnionBaseData.balancePlayerShow = false;
			}
		}
	}

	public bool checkRootShow()
	{
		return _gameRuleContext.bioUnionBaseData.balancePlayerShow;
	}

	public float updateWaitPlayerCount()
	{
		return _gameRuleContext.bioUnionBaseData.balancePlayerCount;
	}
}

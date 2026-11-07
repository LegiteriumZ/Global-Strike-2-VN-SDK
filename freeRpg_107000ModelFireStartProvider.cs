using Assets.Sources.Components.Time;

public class freeRpg_107000ModelFireStartProvider : IfreeRpg_107000ModelFireStartProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelFireStartProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.FireStartTime > 0)
		{
			_gameRuleContext.mystery.FireStartTime -= time.FrameInterval;
			if (_gameRuleContext.mystery.FireStartTime <= 0)
			{
				_gameRuleContext.mystery.IsFireStart = false;
			}
		}
	}

	public bool IsShowFireStart()
	{
		return _gameRuleContext.mystery.IsFireStart;
	}

	public string SetPlayerName()
	{
		return _gameRuleContext.mystery.FireStartPlayerName;
	}
}

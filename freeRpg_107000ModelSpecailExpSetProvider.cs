using Assets.Sources.Components.Time;

public class freeRpg_107000ModelSpecailExpSetProvider : IfreeRpg_107000ModelSpecailExpSetProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelSpecailExpSetProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.SpecialExpTime > 0)
		{
			_gameRuleContext.mystery.SpecialExpTime -= time.FrameInterval;
			if (_gameRuleContext.mystery.SpecialExpTime <= 0)
			{
				_gameRuleContext.mystery.IsSpecailExpSet = false;
			}
		}
	}

	public bool IsShowExpSet()
	{
		return _gameRuleContext.mystery.IsSpecailExpSet;
	}
}

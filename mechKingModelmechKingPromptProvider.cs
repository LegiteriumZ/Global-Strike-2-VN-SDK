using Assets.Sources.Components.Time;

public class mechKingModelmechKingPromptProvider : ImechKingModelmechKingPromptProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int SHOW_TIME;

	private int SHOW_START_TIME;

	public mechKingModelmechKingPromptProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		SHOW_TIME -= time.FrameInterval;
		SHOW_START_TIME -= time.FrameInterval;
	}

	public bool showWeapon()
	{
		return _gameRuleContext.mechKingData._showweapon;
	}

	public bool showNumber()
	{
		if (_gameRuleContext.mechKingData._showTime > 0)
		{
			SHOW_TIME = _gameRuleContext.mechKingData._showTime;
			_gameRuleContext.mechKingData._showTime = 0;
		}
		return SHOW_TIME > 0;
	}

	public float setNumber()
	{
		if (SHOW_TIME > 0)
		{
			return SHOW_TIME / 1000;
		}
		return 0f;
	}

	public float setStartNumber()
	{
		if (SHOW_START_TIME > 0)
		{
			return SHOW_START_TIME / 1000;
		}
		return 0f;
	}

	public bool showStart()
	{
		if (_gameRuleContext.mechKingData._startTime > 0)
		{
			SHOW_START_TIME = _gameRuleContext.mechKingData._startTime;
			_gameRuleContext.mechKingData._startTime = 0;
		}
		return SHOW_START_TIME > 0;
	}
}

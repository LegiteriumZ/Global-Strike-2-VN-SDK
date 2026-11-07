using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;

public class knifeFightModelStartTimerProvider : IknifeFightModelStartTimerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	protected ISSJJTimer _timer;

	protected int _second;

	protected int _start;

	public knifeFightModelStartTimerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.hasGunFightData)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTSTART", out _timer))
			{
				_second = _timer.LeftTime;
			}
			else
			{
				_second = 0;
			}
		}
	}

	public bool IsShow()
	{
		return _second > 0;
	}

	public float SetStartTimer()
	{
		return _second / 1000;
	}

	public bool IsMessageShow()
	{
		return _second / 1000 == 0;
	}

	public bool IsTimerShow()
	{
		return _second / 1000 > 0;
	}
}

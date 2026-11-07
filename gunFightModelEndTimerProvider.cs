using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;

public class gunFightModelEndTimerProvider : IgunFightModelEndTimerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	protected ISSJJTimer _timer;

	protected int _second;

	protected float _progress;

	protected int _start;

	public gunFightModelEndTimerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.hasGunFightData)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTEND", out _timer))
			{
				_second = _timer.LeftTime;
				_progress = (float)_timer.LeftTime / (float)_timer.Length;
			}
			else
			{
				_second = 0;
				_progress = 0f;
			}
		}
	}

	public bool IsShow()
	{
		return _second > 0;
	}

	public float SetProgress()
	{
		return _progress;
	}

	public float SetTime()
	{
		return _second / 1000;
	}
}

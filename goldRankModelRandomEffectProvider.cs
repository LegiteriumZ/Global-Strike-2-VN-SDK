using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;

public class goldRankModelRandomEffectProvider : IgoldRankModelRandomEffectProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	private ISSJJTimer _timer;

	private int _lastFrameTime;

	private int _index;

	private bool _canSet;

	public goldRankModelRandomEffectProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		if (time.ServerTime - _lastFrameTime > 75)
		{
			_lastFrameTime = time.ServerTime;
			_index = ++_index % 9;
			_canSet = true;
		}
	}

	public bool CanSet(int index)
	{
		if (_canSet)
		{
			_canSet = false;
			return true;
		}
		return false;
	}

	public string SetImage(int index)
	{
		return $"/ui/GameGUIRes/gunFightModel/effect/0{_index + 1}";
	}

	public bool IsShow()
	{
		if (_timeContext.commonTimer.CommonTimer.TryGetValue("GUNFIGHTSHOWBAG", out _timer))
		{
			return _timer.LeftTime > 5000;
		}
		return false;
	}
}

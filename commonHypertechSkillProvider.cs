using Assets.Sources.Components.Time;

public class commonHypertechSkillProvider : IcommonHypertechSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int _showTime;

	private bool _showVisible;

	public commonHypertechSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		updateTime(time);
	}

	private void updateTime(TimeComponent time)
	{
		if (_gameRuleContext.hypertechData._canUseSkill)
		{
			if (!_showVisible)
			{
				_showVisible = true;
				_showTime = _gameRuleContext.hypertechData._durationTime;
			}
		}
		else
		{
			_showVisible = false;
			_showTime = 0;
		}
		_showTime -= time.FrameInterval;
		if (_showVisible && _showTime <= 0)
		{
			_gameRuleContext.hypertechData._canUseSkill = false;
		}
	}

	public bool isShow()
	{
		return _gameRuleContext.hypertechData._canUseSkill;
	}

	public float setProgress()
	{
		if (_gameRuleContext.hypertechData._durationTime > 0 && _showTime > 0)
		{
			return (float)_showTime / (float)_gameRuleContext.hypertechData._durationTime;
		}
		return 0f;
	}
}

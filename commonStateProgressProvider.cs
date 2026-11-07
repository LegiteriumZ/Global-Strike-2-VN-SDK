using Assets.Sources.Components.Time;

public class commonStateProgressProvider : IcommonStateProgressProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonStateProgressProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.stateProgress.IsEffect)
		{
			_gameRuleContext.stateProgress.CurrentTime += time.FrameInterval;
			if (_gameRuleContext.stateProgress.CurrentTime > _gameRuleContext.stateProgress.AllTime)
			{
				_gameRuleContext.stateProgress.IsEffect = false;
			}
		}
	}

	public bool IsProgressShow()
	{
		return _gameRuleContext.stateProgress.IsEffect;
	}

	public float GetProgresPercent()
	{
		return (float)_gameRuleContext.stateProgress.CurrentTime * 1f / (float)_gameRuleContext.stateProgress.AllTime;
	}

	public string SetPlayerName()
	{
		return _gameRuleContext.stateProgress.PlayerName;
	}

	public string SetDes()
	{
		return _gameRuleContext.stateProgress.Detail;
	}

	public float GetShinePos()
	{
		float progresPercent = GetProgresPercent();
		return -162f + progresPercent * 290f;
	}
}

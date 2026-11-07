using Assets.Sources.Components.Time;

public class BroadSwordModelmessageProvider : IBroadSwordModelmessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public BroadSwordModelmessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.broadSword.LevelUpAllTime > 0)
		{
			_gameRuleContext.broadSword.LevelUpCurrentTime += time.FrameInterval;
			if (_gameRuleContext.broadSword.LevelUpCurrentTime > _gameRuleContext.broadSword.LevelUpAllTime)
			{
				_gameRuleContext.broadSword.LevelUpAllTime = (_gameRuleContext.broadSword.LevelUpCurrentTime = 0);
			}
		}
		if (_gameRuleContext.broadSword.State2AllTime > 0)
		{
			_gameRuleContext.broadSword.State2CurrentTime += time.FrameInterval;
			if (_gameRuleContext.broadSword.State2CurrentTime > _gameRuleContext.broadSword.State2AllTime)
			{
				_gameRuleContext.broadSword.State2AllTime = (_gameRuleContext.broadSword.State2CurrentTime = 0);
			}
		}
		if (_gameRuleContext.broadSword.FinalStateAllTime > 0)
		{
			_gameRuleContext.broadSword.FinalStateCurrentTime += time.FrameInterval;
			if (_gameRuleContext.broadSword.FinalStateCurrentTime > _gameRuleContext.broadSword.FinalStateAllTime)
			{
				_gameRuleContext.broadSword.FinalStateAllTime = (_gameRuleContext.broadSword.FinalStateCurrentTime = 0);
			}
		}
		if (_gameRuleContext.broadSword.FinalComingNowTime > 0)
		{
			_gameRuleContext.broadSword.FinalComingNowTime -= time.FrameInterval;
			if (_gameRuleContext.broadSword.FinalComingNowTime <= 0)
			{
				_gameRuleContext.broadSword.IsShowFinalComingCal = false;
			}
		}
	}

	public bool IsFinalComingShow()
	{
		if (_gameRuleContext.broadSword.FinalStateAllTime == 0)
		{
			return false;
		}
		return _gameRuleContext.broadSword.FinalStateCurrentTime < _gameRuleContext.broadSword.FinalStateAllTime;
	}

	public bool IsLevelUpShow()
	{
		if (_gameRuleContext.broadSword.LevelUpAllTime == 0)
		{
			return false;
		}
		return _gameRuleContext.broadSword.LevelUpCurrentTime < _gameRuleContext.broadSword.LevelUpAllTime;
	}

	public bool IsStrengthenShow()
	{
		if (_gameRuleContext.broadSword.State2AllTime == 0)
		{
			return false;
		}
		return _gameRuleContext.broadSword.State2CurrentTime < _gameRuleContext.broadSword.State2AllTime;
	}

	public bool IsFinalComingCalShow()
	{
		return _gameRuleContext.broadSword.IsShowFinalComingCal;
	}

	public bool IsWaitPlayerShow()
	{
		return _gameRuleContext.broadSword.IsShowWaitingPlayer;
	}

	public float GetFinalComingTime()
	{
		return _gameRuleContext.broadSword.FinalComingNowTime / 1000 + 1;
	}

	public float GetWaitPlayerCount()
	{
		return _gameRuleContext.broadSword.ShowWaitingPlayerCount;
	}

	public bool IsEShow()
	{
		return _gameRuleContext.broadSword.IsEShow;
	}
}

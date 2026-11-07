using Assets.Sources.Components.Time;
using NetData;

public class bladeStrongholdNewModelstateProvider : IbladeStrongholdNewModelstateProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladeStrongholdNewModelstateProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool showTime(int index)
	{
		return true;
	}

	public float showclock(int index)
	{
		int minutes = Contexts.sharedInstance.battleRoom.sectionTime.Minutes;
		int seconds = Contexts.sharedInstance.battleRoom.sectionTime.Seconds;
		return index switch
		{
			0 => minutes / 10, 
			1 => minutes % 10, 
			2 => seconds / 10, 
			3 => seconds % 10, 
			_ => 0f, 
		};
	}

	public float updateTeamNum1()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return _gameRuleContext.bladeStrongholdNewData.data.Team2Num;
		}
		return 0f;
	}

	public float updateTeamNum2()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return _gameRuleContext.bladeStrongholdNewData.data.Team1Num;
		}
		return 0f;
	}

	public float updateCtScore()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.Team2Score;
	}

	public float updateTeamProgress1()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return _gameRuleContext.bladeStrongholdNewData.data.Progress2;
		}
		return 0f;
	}

	public float updateTeamProgress2()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return _gameRuleContext.bladeStrongholdNewData.data.Progress1;
		}
		return 0f;
	}

	public float updateTScore()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.Team1Score;
	}

	public float updateWinScore()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.WinScore;
	}

	public bool showlan()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.OCCUPIED || _gameRuleContext.bladeStrongholdNewData.data.State > StrongholdState.CHANGEOCCUPY) && _gameRuleContext.bladeStrongholdNewData.data.Occupy == 2)
		{
			return true;
		}
		return false;
	}

	public bool showhong()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null && (_gameRuleContext.bladeStrongholdNewData.data.State == StrongholdState.OCCUPIED || _gameRuleContext.bladeStrongholdNewData.data.State > StrongholdState.CHANGEOCCUPY) && _gameRuleContext.bladeStrongholdNewData.data.Occupy == 1)
		{
			return true;
		}
		return false;
	}

	public float getProgress1()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return (float)_gameRuleContext.bladeStrongholdNewData.data.Progress2 / 100f;
		}
		return 0f;
	}

	public float getProgress2()
	{
		if (_gameRuleContext.bladeStrongholdNewData.data != null)
		{
			return (float)_gameRuleContext.bladeStrongholdNewData.data.Progress1 / 100f;
		}
		return 0f;
	}
}

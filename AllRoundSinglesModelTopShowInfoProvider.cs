using Assets.Sources.Components.Time;

public class AllRoundSinglesModelTopShowInfoProvider : IAllRoundSinglesModelTopShowInfoProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private int _curMp;

	private int _needMp;

	public AllRoundSinglesModelTopShowInfoProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetCampCTKillCount()
	{
		return _gameRuleContext.broadcastScore.Team2Kill;
	}

	public float SetCampCTWinCount()
	{
		return _gameRuleContext.broadcastScore.Team2Score;
	}

	public float SetCampTKillCount()
	{
		return _gameRuleContext.broadcastScore.Team1Kill;
	}

	public float SetCampTWinCount()
	{
		return _gameRuleContext.broadcastScore.Team1Score;
	}

	public float SetCountDownMinuteTime()
	{
		return _battleRoomContext.sectionTime.Minutes;
	}

	public float SetCountDownSecondTimeGe()
	{
		return _battleRoomContext.sectionTime.Seconds % 10;
	}

	public float SetCountDownSecondTimeShi()
	{
		return _battleRoomContext.sectionTime.Seconds / 10;
	}

	public string GetModeUrl()
	{
		int curMode = _gameRuleContext.allRoundSinglesData.CurMode;
		return GetStrByIndex(curMode);
	}

	private string GetStrByIndex(int index)
	{
		return index switch
		{
			5 => "", 
			0 => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/jindian", 
			1 => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/daozhan", 
			2 => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/juzhan", 
			3 => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/shouqiang", 
			4 => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/gangqiang", 
			_ => "/ui/GameGUIRes/AllRoundSinglesModel/TopShowInfo/jindian", 
		};
	}
}

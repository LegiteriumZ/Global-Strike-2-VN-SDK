using Assets.Sources.Components.Time;

public class AllRoundSinglesModelCurRoundResoultProvider : IAllRoundSinglesModelCurRoundResoultProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private int _curMp;

	private int _needMp;

	private int RemainTime = 3000;

	private int GameOverUiShowTime;

	private bool isGameOver;

	public AllRoundSinglesModelCurRoundResoultProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public string GetWinScoreUrl()
	{
		return _battleRoomContext.roomData.Data.WinScore switch
		{
			3 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/3and2", 
			5 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/5and3", 
			7 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/7and4", 
			9 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/9and5", 
			11 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/11and6", 
			13 => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/13and7", 
			_ => "/ui/GameGUIRes/AllRoundSinglesModel/CurRoundResoult/3and2", 
		};
	}

	public bool IsShow()
	{
		return GameOverUiShowTime > 0;
	}

	public bool IsWin()
	{
		return _battleRoomContext.gameOver.IsWin;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_battleRoomContext.gameOver.IsGameOver)
		{
			if (!isGameOver)
			{
				isGameOver = true;
				GameOverUiShowTime = RemainTime;
			}
		}
		else
		{
			isGameOver = false;
		}
		if (GameOverUiShowTime >= 0)
		{
			GameOverUiShowTime -= time.FrameInterval;
		}
	}

	public float SetCampCTWinCount()
	{
		return _gameRuleContext.broadcastScore.Team2Score;
	}

	public float SetCampTWinCount()
	{
		return _gameRuleContext.broadcastScore.Team1Score;
	}
}

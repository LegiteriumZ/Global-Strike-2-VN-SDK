using Assets.Sources.Components.Time;

public class AllRoundSinglesModelbattletipProvider : IAllRoundSinglesModelbattletipProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private int _curMp;

	private int _needMp;

	public AllRoundSinglesModelbattletipProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public bool IsShowCountDown()
	{
		if (IsShowWait())
		{
			return false;
		}
		return _gameRuleContext.allRoundSinglesData.IsShowCountDown;
	}

	public bool IsShowLoseHp()
	{
		if (IsShowWait())
		{
			return false;
		}
		if (IsShowCountDown())
		{
			return false;
		}
		return _gameRuleContext.allRoundSinglesData.IsShowLoseHp;
	}

	public bool IsShowWait()
	{
		return _gameRuleContext.allRoundSinglesData.IsShowWaitTip;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetCountDown()
	{
		return _gameRuleContext.allRoundSinglesData.SurplusTime;
	}
}

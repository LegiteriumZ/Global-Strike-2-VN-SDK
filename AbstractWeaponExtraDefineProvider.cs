using Assets.Sources.Components.Time;

public abstract class AbstractWeaponExtraDefineProvider : IWeaponExtraDefineProvider, IDataProvider
{
	protected string _keyInfo;

	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	protected PlayerContext _playerContext;

	protected WeaponContext _weaponContext;

	public string KeyInfo
	{
		get
		{
			return _keyInfo;
		}
		set
		{
			_keyInfo = value;
		}
	}

	public virtual void OnFrame(TimeComponent time)
	{
	}

	public virtual void Init(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
		_weaponContext = contexts.weapon;
	}
}

using System.Collections.Generic;
using Assets.Sources.Components.Time;

public abstract class AbstractModeExtraDataProvider : IModeExtraDataProvider, IDataProvider
{
	public List<IModuleProvider> Providers = new List<IModuleProvider>();

	protected string _keyInfo;

	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	protected PlayerContext _playerContext;

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

	public void OnFrame(TimeComponent time)
	{
		foreach (IModuleProvider provider in Providers)
		{
			provider.OnFrame(time);
		}
	}

	public virtual void Init(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
	}
}

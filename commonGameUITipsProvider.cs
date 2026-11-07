using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Components.Time;
using NetData;

public class commonGameUITipsProvider : IcommonGameUITipsProvider, IModuleProvider
{
	private class GameTips
	{
		public string _backStr;

		public string _progressStr;

		public GameTips(string backStr, string progressStr)
		{
			_backStr = backStr;
			_progressStr = progressStr;
		}
	}

	protected GameRuleContext _gameRuleContext;

	private Dictionary<int, GameTips> _config;

	private bool _isShow;

	private GameTips _msg;

	private int _remainTime;

	private int _remainTime1;

	private float _timeNumber;

	public IGameRule _gameRule;

	protected MessageContext _messageContext;

	public commonGameUITipsProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_config = new Dictionary<int, GameTips>();
		_config[-134100] = new GameTips("skillProgress/bioKissBack", "skillProgress/bioKissProgress");
		_gameRule = contexts.gameRule.currentRule.Rule;
		_messageContext = contexts.message;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_isShow && _msg != null)
		{
			if (_remainTime <= 0 || _remainTime1 <= 0)
			{
				_isShow = false;
				_msg = null;
				_timeNumber = 0f;
				_messageContext.gameTipsShow.TipsEvent.Clear();
			}
			else
			{
				_timeNumber = (float)_remainTime / (float)_remainTime1;
			}
		}
	}

	public string ShowBackUI()
	{
		if (_msg == null)
		{
			return "";
		}
		return "/ui/GameGUIRes/halfLoadedRes/" + _msg._backStr;
	}

	public string ShowProgressUI()
	{
		if (_msg == null)
		{
			return "";
		}
		return "/ui/GameGUIRes/halfLoadedRes/" + _msg._progressStr;
	}

	public float ShowProgress()
	{
		if (_msg == null)
		{
			return 0f;
		}
		return _timeNumber;
	}

	public bool IsShow()
	{
		if (_gameRule.IsBio())
		{
			foreach (RpgTipsEventData item in _messageContext.gameTipsShow.TipsEvent)
			{
				if (_config.ContainsKey(item.TypeId) && _config[item.TypeId] != null)
				{
					_msg = _config[item.TypeId];
					_remainTime = item.Time1;
					_remainTime1 = item.Time2;
				}
			}
			if (_msg != null && _remainTime > 0 && _remainTime1 > 0)
			{
				_messageContext.gameTipsShow.TipsEvent.Clear();
				_isShow = true;
			}
		}
		return _isShow;
	}
}

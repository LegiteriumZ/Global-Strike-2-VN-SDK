using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using NotifyEvent;

public class commonbioGameUITipsProvider : IcommonbioGameUITipsProvider, IModuleProvider
{
	private class GameTips
	{
		public string _backStr;

		public int _width;

		public int _height;

		public bool Show;

		public GameTips(string backStr, int width, int height)
		{
			_backStr = backStr;
			_width = width;
			_height = height;
		}
	}

	protected PlayerContext _playerContext;

	private Dictionary<int, GameTips> _config;

	private bool _isShow;

	private GameTips _msg;

	private int _showTime;

	public commonbioGameUITipsProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
		_config = new Dictionary<int, GameTips>();
		_config[-2000001] = new GameTips("weapon-bioserumreload", 128, 23);
		NotifyManager.MakeNotifyClass(153, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			RpgTipsEventData rpgTipsEventData = tipsEvent[i];
			int typeId = rpgTipsEventData.TypeId;
			if (_config.ContainsKey(typeId) && _config[typeId] != null)
			{
				if (_msg == null)
				{
					_msg = _config[rpgTipsEventData.TypeId];
					_showTime = rpgTipsEventData.Time1;
					_isShow = true;
				}
				break;
			}
		}
		tipsEvent.Clear();
	}

	public void OnFrame(TimeComponent time)
	{
		if (_isShow && _msg != null)
		{
			_showTime -= time.FrameInterval;
			if (_showTime <= 0)
			{
				_isShow = false;
				_msg = null;
			}
		}
	}

	public bool IsShow()
	{
		return _isShow;
	}

	public int SetWidth()
	{
		if (_msg == null)
		{
			return 0;
		}
		return _msg._width;
	}

	public int SetHeight()
	{
		if (_msg == null)
		{
			return 0;
		}
		return _msg._height;
	}

	public string ChangeImage()
	{
		if (_msg == null)
		{
			return "";
		}
		return "/ui/GameGUIRes/halfLoadedRes/" + _msg._backStr;
	}
}

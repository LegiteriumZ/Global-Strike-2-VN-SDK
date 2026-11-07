using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using NotifyEvent;

public class rpgModelGameUITipsTimeProvider : IrpgModelGameUITipsTimeProvider, IModuleProvider
{
	private class GameTips
	{
		public string _backStr;

		public bool Show;

		public GameTips(string backStr)
		{
			_backStr = backStr;
		}
	}

	private Dictionary<int, GameTips> _config;

	private bool _isShow;

	private GameTips _msg;

	private int _showTime;

	public rpgModelGameUITipsTimeProvider(Contexts contexts)
	{
		_config = new Dictionary<int, GameTips>();
		_config[-13357] = new GameTips("skillProgress/timeBack");
		_config[-13358] = new GameTips("skillProgress/timeBack");
		NotifyManager.MakeNotifyClass(151, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
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
					getMsg(rpgTipsEventData);
				}
				else if (_msg != _config[typeId] || _msg.Show != rpgTipsEventData.Show)
				{
					getMsg(rpgTipsEventData);
				}
				break;
			}
		}
		tipsEvent.Clear();
	}

	private void getMsg(RpgTipsEventData data)
	{
		_msg = _config[data.TypeId];
		_msg.Show = data.Show;
		if (!_msg.Show)
		{
			_showTime = 0;
			return;
		}
		_showTime = data.Time1;
		_isShow = true;
	}

	public bool IsShow()
	{
		return _isShow;
	}

	public string ShowBackUI()
	{
		if (_msg != null)
		{
			return "/ui/GameGUIRes/halfLoadedRes/" + _msg._backStr;
		}
		return "";
	}

	public float showNum()
	{
		if (_msg != null)
		{
			return (int)((double)_showTime * 0.001);
		}
		return 0f;
	}
}

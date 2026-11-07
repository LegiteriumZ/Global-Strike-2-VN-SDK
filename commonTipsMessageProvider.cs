using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils.Timer;
using NetData;

public class commonTipsMessageProvider : IcommonTipsMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _messageContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private List<GameMessagePvpTable.Row> _messageList;

	private Dictionary<int, GameMessagePvpTable.Row> _messageDic;

	private GameMessagePvpTable _config;

	private GameMessagePvpTable.Row _row;

	private ISSJJTimer _timer;

	private bool _show;

	private int _timeNumber;

	public commonTipsMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_messageContext = contexts.message;
		_battleRoomContext = contexts.battleRoom;
		_timeContext = contexts.time;
		_config = GameMessagePvpLoader.Instance.Table;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_messageContext.hasCommonMessageShow && _messageContext.commonMessageShow.TipsEvent.Count > 0)
		{
			if (_messageList == null)
			{
				_messageList = _config.FindAll_ModeId(_battleRoomContext.roomData.Data.RaceType);
				_messageDic = new Dictionary<int, GameMessagePvpTable.Row>();
			}
			foreach (RpgTipsEventData data in _messageContext.commonMessageShow.TipsEvent)
			{
				if (!_messageDic.TryGetValue(data.TypeId, out var value))
				{
					value = _messageList.Find((GameMessagePvpTable.Row x) => data.TypeId == x.Type);
					if (value == null)
					{
						continue;
					}
					_messageDic[data.TypeId] = value;
				}
				if (_row == null || _row.Priority >= value.Priority)
				{
					_row = value;
					_show = data.Show;
					SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, _row.Mode + _row.Image, new SSJJTimer((data.Time1 > 0) ? data.Time1 : _row.Time));
				}
			}
			_messageContext.commonMessageShow.TipsEvent.Clear();
		}
		if (_show)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue(_row.Mode + _row.Image, out _timer))
			{
				_timeNumber = _timer.LeftTime;
				_timeNumber = _timer.LeftTime / 1000;
			}
			else
			{
				_show = false;
				_row = null;
			}
		}
	}

	public bool IsShow()
	{
		return _show;
	}

	public string SetImage()
	{
		if (_row == null)
		{
			return "/ui/GameGUIRes/common/default";
		}
		return $"/ui/GameGUIRes/{_row.Mode}/{_row.Image}";
	}

	public float SetMessagePosY()
	{
		if (_row == null)
		{
			return 0f;
		}
		return -_row.MsgPosY;
	}

	public float SetYPos()
	{
		if (_row == null)
		{
			return 0f;
		}
		return -_row.PosY;
	}

	public float SetXPos()
	{
		if (_row == null)
		{
			return 0f;
		}
		return _row.PosX;
	}

	public float SetNumber()
	{
		return _timeNumber;
	}

	public bool IsShowNumber()
	{
		if (_row == null)
		{
			return false;
		}
		return _row.NumType > 0;
	}
}

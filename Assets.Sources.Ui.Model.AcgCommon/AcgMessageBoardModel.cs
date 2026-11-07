using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Message.Common;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgMessageBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgMessageBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private MessageContext _messageContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

	private Queue<GameMessageDataComponent.AcgMessageData> _tempQueue = new Queue<GameMessageDataComponent.AcgMessageData>(4);

	private const int MAX_MESSAGE = 4;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgMessageBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		if (_messageContext == null)
		{
			return;
		}
		_tempQueue.Clear();
		int i = 0;
		bool flag = false;
		foreach (GameMessageDataComponent.AcgMessageData item in _messageContext.gameMessageData.AcgMessageQueue)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue(item.timerId, out _timer))
			{
				_tempQueue.Enqueue(item);
				if (flag)
				{
					SetText(item.id, i++, item.stringPara);
				}
				else
				{
					i++;
				}
			}
			else
			{
				flag = true;
			}
		}
		Queue<GameMessageDataComponent.AcgMessageData> acgMessageQueue = _messageContext.gameMessageData.AcgMessageQueue;
		_messageContext.gameMessageData.AcgMessageQueue = _tempQueue;
		_tempQueue = acgMessageQueue;
		for (; i < 4; i++)
		{
			_viewModel.SetMessageBackShow(i, value: false);
		}
	}

	protected override void DoSubscribe()
	{
		_timeContext = Contexts.sharedInstance.time;
		_messageContext = Contexts.sharedInstance.message;
		NotifyManager.MakeNotifyClass(111, UiIEventCondition.Get_AcgMessageQueue, SetMessage);
	}

	private void SetMessage(Queue<GameMessageDataComponent.AcgMessageData> oldQueue, Queue<GameMessageDataComponent.AcgMessageData> newQueue)
	{
		int num = 0;
		foreach (GameMessageDataComponent.AcgMessageData item in newQueue)
		{
			SetText(item.id, num++, item.stringPara);
		}
	}

	private void SetText(int id, int index, string stringPara)
	{
		switch (id)
		{
		case 50005:
			_viewModel.SetMessageString(index, ScriptLocalization.Get("EV_RECOVERY_MESSAGE"));
			break;
		case 50006:
			_viewModel.SetMessageString(index, string.Format(ScriptLocalization.Get("EV_INJURY_MESSAGE"), stringPara));
			break;
		case 50007:
			_viewModel.SetMessageString(index, ScriptLocalization.Get("EV_OUT_OF_BULLETS_MESSAGE"));
			break;
		}
		_viewModel.SetMessageBackShow(index, value: true);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

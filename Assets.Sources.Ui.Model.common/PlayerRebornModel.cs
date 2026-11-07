using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerRebornModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext, ISetMessageContext
{
	private PlayerrebornViewModel _viewModel;

	private const int RebornTimeScale = 1000;

	private int _lerpVal;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private bool _isRpgTime;

	private ActiveChip _reliveMessageActiveChip = new ActiveChip();

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PlayerrebornViewModel();
	}

	protected override void DoSubscribe()
	{
		_viewModel.ProgressShow = false;
		if (!_battleRoomContext.roomData.IsObserver)
		{
			_isRpgTime = _gameRuleContext.currentRule.Rule.IsRpgRelive();
			_viewModel.ReportRShow = RuleUtilty.hasReportHandle();
			NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		}
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_lerpVal = 0;
		_viewModel.ProgressShow = arg2;
	}

	private bool GetVisible()
	{
		if (!UiIEventCondition.Get_uiMyPlayer_IsDead())
		{
			return false;
		}
		if (!_isRpgTime && UiIEventCondition.Get_uiRoomData_ReLiveTime() <= 0)
		{
			return false;
		}
		if (_messageContext.gameMessageData.MessageData != null && _messageContext.gameMessageData.MessageData.Type == GameMessageType.SHOWNEXTBATTLE)
		{
			return false;
		}
		if (BroadSwordFinalTime())
		{
			return false;
		}
		return _gameRuleContext.currentRule.Rule.CanRelive();
	}

	private bool BroadSwordFinalTime()
	{
		if (_gameRuleContext.broadSword.FinalStateAllTime == 0)
		{
			return false;
		}
		return _gameRuleContext.broadSword.FinalStateCurrentTime < _gameRuleContext.broadSword.FinalStateAllTime;
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.ProgressShow)
		{
			return;
		}
		int num = 1;
		int num2 = 0;
		if (_isRpgTime)
		{
			num = UiIEventCondition.Get_uiMyPlayer_MaxReliveTime();
			num2 = UiIEventCondition.Get_uiMyPlayer_DeadTimer();
			_viewModel.CountDownSliderSlidervalue = (float)num2 / (float)num;
		}
		else
		{
			num = UiIEventCondition.Get_uiRoomData_ReLiveTime();
			if (num <= 0)
			{
				_viewModel.ProgressShow = false;
				return;
			}
			num2 = UiIEventCondition.Get_uiMyPlayer_DeadTimer();
			_lerpVal += _timeComponent.FrameInterval;
			if (_lerpVal < num2)
			{
				_lerpVal = num2;
			}
			_viewModel.CountDownSliderSlidervalue = 1f - (float)(num - _lerpVal) / (float)num;
		}
		if (Mathf.Approximately(_viewModel.CountDownSliderSlidervalue, 1f) && _isRpgTime)
		{
			_reliveMessageActiveChip.Time = 3000;
		}
		int num3 = (num - num2) / 1000 + 1;
		if (num3 >= 0)
		{
			_viewModel.CountDownNumString = num3.ToString();
		}
		else
		{
			_viewModel.ProgressShow = false;
		}
	}

	private void InitChips()
	{
		_reliveMessageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ReliveMessageShow = _reliveMessageActiveChip.Update(_timeComponent);
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}

using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class CrazyBigheadmessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private CrazyBigheadmessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private readonly Dictionary<int, Action> _messageActions = new Dictionary<int, Action>();

	private ActiveChip _tActiveChip;

	private ActiveChip _ctActiveChip;

	private ActiveChip _inCrazyChip;

	private ActiveChip _outCrazyChip;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_messageActions.Add(1, SetTChange);
		_messageActions.Add(2, SetCtChange);
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrazyBigheadmessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.InCrazyTimeMessageShow = false;
		NotifyManager.MakeNotify(82, UiIEventCondition.Get_CrazyBigHeadMessage, UpdateMessage, initinvoke: true);
	}

	private void UpdateMessage(bool arg1, bool arg2)
	{
		foreach (KeyValuePair<int, Action> messageAction in _messageActions)
		{
			_gameRuleContext.crazyBigHead.CrazyTeamDic.TryGetValue(messageAction.Key, out var value);
			if (value == null || !value.CrazyTypeChange)
			{
				continue;
			}
			value.CrazyTypeChange = false;
			if (value.CrazyType == CrazyBigHeadMessageType.CRAZYTIME)
			{
				messageAction.Value();
				if (Contexts.sharedInstance.player.cameraOwnerEntity.basicInfo.Current.Team != messageAction.Key)
				{
					break;
				}
				ShowInCrazyMessage();
			}
			else if (value.CrazyType == CrazyBigHeadMessageType.TEAMCRAZYEND)
			{
				ShowOutCrazyMessage();
			}
		}
	}

	private void ShowOutCrazyMessage()
	{
		if (_inCrazyChip.Time > 0)
		{
			_inCrazyChip.Time = 0;
		}
		_outCrazyChip.Time = 3000;
	}

	private void ShowInCrazyMessage()
	{
		_inCrazyChip.Time = 3000;
	}

	private void SetCtChange()
	{
		if (_tActiveChip.Time > 0)
		{
			_tActiveChip.Time = 0;
		}
		_ctActiveChip.Time = 5000;
	}

	private void SetTChange()
	{
		if (_ctActiveChip.Time > 0)
		{
			_ctActiveChip.Time = 0;
		}
		_tActiveChip.Time = 5000;
	}

	private void InitChips()
	{
		_tActiveChip = new ActiveChip();
		_ctActiveChip = new ActiveChip();
		_inCrazyChip = new ActiveChip();
		_outCrazyChip = new ActiveChip();
		_tActiveChip.Time = 0;
		_ctActiveChip.Time = 0;
		_inCrazyChip.Time = 0;
		_outCrazyChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.CtChangeHeadShow = _ctActiveChip.Update(_timeComponent);
		_viewModel.TChangeHeadShow = _tActiveChip.Update(_timeComponent);
		_viewModel.InCrazyTimeMessageShow = _inCrazyChip.Update(_timeComponent);
		_viewModel.OutCrazyTimeMessageShow = _outCrazyChip.Update(_timeComponent);
	}
}

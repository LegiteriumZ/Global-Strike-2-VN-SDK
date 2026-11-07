using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class KickOutUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetPlayerContext, ICursorControl, ISetMessageContext
{
	private KickOutUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	private SimpleNotifyGroup _group = new SimpleNotifyGroup();

	private List<KickOutCellModel> _tcells = new List<KickOutCellModel>();

	private List<KickOutCellModel> _ctcells = new List<KickOutCellModel>();

	private StartVoteRequest data = new StartVoteRequest();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

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

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new KickOutUIViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.btnCloseClicked.AddListener(CancelClicked);
		_viewModel.kickmsgString = ScriptLocalization.Get("KickOutTips").Replace("\\n", "\n");
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetVisibleConfirm, SetVisibleConfirm);
		_group.Add(SimpleNotify.Add(GetTPlayerCount, SetTPlayerCount));
		_group.Add(SimpleNotify.Add(GetCTPlayerCount, SetCTPlayerCount));
		for (int i = 1; i < _viewModel.GetmsgCount() + 1; i++)
		{
			Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
			int index = i;
			buttonClickedEvent.AddListener(delegate
			{
				MsgCancelClicked(index);
			});
			_viewModel.SetmsgClicked(i, buttonClickedEvent);
		}
		_viewModel.ConfirmClicked.AddListener(delegate
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(40, data);
			_gameRuleContext.kickOut.Visible = false;
			data.KickPlayerId = 0;
			data.Reaon = 0;
			for (int j = 1; j < _viewModel.GetmCount() + 1; j++)
			{
				_viewModel.SetmShow(j, value: false);
			}
		});
	}

	private void SetVisibleConfirm(bool arg1, int index)
	{
		_viewModel.ConfirmButtonable = arg1;
	}

	private bool GetVisibleConfirm(int index)
	{
		if (data.KickPlayerId > 0)
		{
			return data.Reaon > 0;
		}
		return false;
	}

	private void SetVisible(bool arg1, int index)
	{
		_viewModel.ShowShow = arg1;
		_group.SetSuspend(!arg1);
	}

	private bool GetVisible(int index)
	{
		if (_gameRuleContext == null || _gameRuleContext.kickOut == null)
		{
			return false;
		}
		return _gameRuleContext.kickOut.Visible;
	}

	private void MsgCancelClicked(int i)
	{
		for (int j = 1; j < _viewModel.GetmCount() + 1; j++)
		{
			_viewModel.SetmShow(j, value: false);
		}
		_viewModel.SetmShow(i, value: true);
		data.Reaon = i;
	}

	public void SetPlayer(OneKillInfoData player)
	{
		if (player.Id != _playerContext.myPlayerEntity.basicInfo.Current.Id && player.Team == _playerContext.myPlayerEntity.basicInfo.Current.Team)
		{
			data.KickPlayerId = player.Id;
			return;
		}
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("KickOutError"), 1000);
		NotifyManager.ForceInvoke(38);
	}

	public int GetPlayerID()
	{
		return data.KickPlayerId;
	}

	private void CancelClicked()
	{
		_gameRuleContext.kickOut.Visible = false;
	}

	private int GetTPlayerCount(int arg1)
	{
		if (_gameRuleContext == null || _gameRuleContext.kickOut == null)
		{
			return 0;
		}
		if (_gameRuleContext.kickOut.tPlayerList != UiIEventCondition.Get_allKillInfo_Team1())
		{
			_gameRuleContext.kickOut.tPlayerList = UiIEventCondition.Get_allKillInfo_Team1();
		}
		return UiIEventCondition.Get_allKillInfo_Team1().Count;
	}

	private int GetCTPlayerCount(int arg1)
	{
		if (_gameRuleContext == null || _gameRuleContext.kickOut == null)
		{
			return 0;
		}
		if (_gameRuleContext.kickOut.ctPlayerList != UiIEventCondition.Get_allKillInfo_Team2())
		{
			_gameRuleContext.kickOut.ctPlayerList = UiIEventCondition.Get_allKillInfo_Team2();
		}
		return UiIEventCondition.Get_allKillInfo_Team2().Count;
	}

	private void SetTPlayerCount(int arg1, int arg2)
	{
		SetPlayerCount(arg1, 2);
	}

	private void SetCTPlayerCount(int arg1, int arg2)
	{
		SetPlayerCount(arg1, 1);
	}

	private void SetPlayerCount(int arg1, int team)
	{
		GameObject container = ((team == 2) ? _viewModel.tContentPlayerObj : _viewModel.ctContentPlayerObj);
		List<KickOutCellModel> list = ((team == 2) ? _tcells : _ctcells);
		for (int i = list.Count; i < arg1; i++)
		{
			KickOutCellModel kickOutCellModel = new KickOutCellModel
			{
				Index = i,
				Container = container,
				Group = _group,
				Team = team
			};
			kickOutCellModel.SetGameRuleContext(_gameRuleContext);
			kickOutCellModel.SetKicOutUIModel(this);
			kickOutCellModel.Initialize();
			list.Add(kickOutCellModel);
		}
	}

	public int GetCursorState()
	{
		if (!_gameRuleContext.kickOut.Visible && CloseDelay <= 0)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

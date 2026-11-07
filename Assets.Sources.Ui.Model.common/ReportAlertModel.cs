using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ReportAlertModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleServerContext, ICursorControl, IKeyboardResponder
{
	private ReportAlertViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SimpleNotifyGroup _group = new SimpleNotifyGroup();

	private BattleServerContext _battleServerContext;

	private int _closeDelay;

	private ReportVisibleComponent.ReportPlayer tmpPlayer;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay
	{
		get
		{
			return _closeDelay;
		}
		set
		{
			_closeDelay = value;
		}
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
	}

	public override void CreateViewModel()
	{
		_viewModel = new ReportAlertViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private void InitUI()
	{
		_gameRuleContext.reportVisible.reasonIndex = 0;
		for (int i = 0; i < 6; i++)
		{
			ReportAlertCellModel reportAlertCellModel = new ReportAlertCellModel();
			reportAlertCellModel.Index = i;
			reportAlertCellModel.Message = ScriptLocalization.Get("REPORT_REASON_" + i);
			reportAlertCellModel.Container = _viewModel.oContentObj;
			reportAlertCellModel.Group = _group;
			reportAlertCellModel.SetGameRuleContext(_gameRuleContext);
			reportAlertCellModel.Initialize();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ReportBtnClicked.AddListener(ReportClicked);
		_viewModel.CancelBtnClicked.AddListener(CancelClicked);
		SimpleNotify.Add(GetVisible, SetVisible);
		_group.Add(SimpleNotify.Add(GetReportPlayerName, SetReportPlayerName));
		InitUI();
	}

	private void SetReportPlayerName(string arg1, int index)
	{
		_viewModel.ReportPlayerName = arg1;
	}

	private string GetReportPlayerName(int index)
	{
		if (_gameRuleContext.reportVisible.selectPlayer != null)
		{
			return _gameRuleContext.reportVisible.selectPlayer.Name;
		}
		return "";
	}

	private void SetVisible(bool arg1, int index)
	{
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = arg1;
		_group.SetSuspend(!arg1);
	}

	private bool GetVisible(int index)
	{
		return _gameRuleContext.reportVisible.alertVisible;
	}

	private void CancelClicked()
	{
		_gameRuleContext.reportVisible.alertVisible = false;
		if (_gameRuleContext.reportVisible.alertFrom == 1)
		{
			_gameRuleContext.reportVisible.Visible = true;
		}
	}

	private void ReportClicked()
	{
		if (_gameRuleContext.reportVisible.selectPlayer != null)
		{
			_ = _gameRuleContext.reportVisible;
			ReportRequest reportRequest = new ReportRequest();
			reportRequest.CidList.Add(_gameRuleContext.reportVisible.selectPlayer.Cid);
			reportRequest.Reason = _gameRuleContext.reportVisible.reasonIndex;
			_ = reportRequest.Reason;
			_battleServerContext.battleServer.Server.SendTcpMessage(20, reportRequest);
			Contexts.sharedInstance.chat.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"\" type=\"{0}\" ><body>{1}</body></message>", "system", ScriptLocalization.Get("ReportSuccess")));
			_gameRuleContext.reportVisible.alertVisible = false;
			if (_gameRuleContext.reportVisible.alertFrom == 1)
			{
				_gameRuleContext.reportVisible.Visible = true;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowRootshow)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			_gameRuleContext.reportVisible.alertVisible = false;
		}
		if (key == KeyCode.R && !_gameRuleContext.reportVisible.alertVisible && !_gameRuleContext.reportVisible.Visible && KeyboardOpen())
		{
			_gameRuleContext.reportVisible.alertVisible = true;
			_gameRuleContext.reportVisible.alertFrom = 0;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public bool KeyboardOpen()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity.IsDead())
		{
			ReportVisibleComponent.ReportPlayer killerInfo = getKillerInfo(myPlayerEntity.GetId());
			if (killerInfo != null)
			{
				_gameRuleContext.reportVisible.selectPlayer = killerInfo;
				_gameRuleContext.reportVisible.killLists.Clear();
				return true;
			}
		}
		_gameRuleContext.reportVisible.killLists.Clear();
		return false;
	}

	private ReportVisibleComponent.ReportPlayer getKillerInfo(int selfEntityId)
	{
		List<ReportVisibleComponent.KillInfoData> killLists = _gameRuleContext.reportVisible.killLists;
		int count = killLists.Count;
		int num = -1;
		for (int num2 = count - 1; num2 >= 0; num2--)
		{
			if (killLists[num2].BeKillPlayerId == selfEntityId)
			{
				num = num2;
				break;
			}
		}
		if (num == -1)
		{
			return null;
		}
		if (tmpPlayer == null)
		{
			tmpPlayer = new ReportVisibleComponent.ReportPlayer();
		}
		ReportVisibleComponent.KillInfoData killInfoData = killLists[num];
		int killPlayerId = killInfoData.KillPlayerId;
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(killPlayerId);
		if (entityWithEntityId == null)
		{
			return null;
		}
		tmpPlayer.Cid = entityWithEntityId.GetCharacterId();
		tmpPlayer.Name = killInfoData.KillPlayerName;
		return tmpPlayer;
	}
}

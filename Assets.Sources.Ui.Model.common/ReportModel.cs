using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ReportModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleServerContext, ICursorControl, IKeyboardResponder
{
	private ReportViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SimpleNotifyGroup _group = new SimpleNotifyGroup();

	private List<ReportCellModel> _tcells = new List<ReportCellModel>();

	private List<ReportCellModel> _ctcells = new List<ReportCellModel>();

	private BattleServerContext _battleServerContext;

	private int _closeDelay;

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
		_viewModel = new ReportViewModel();
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
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.CancelBtnClicked.AddListener(CancelClicked);
		SimpleNotify.Add(GetVisible, SetVisible);
		_group.Add(SimpleNotify.Add(GetTPlayerCount, SetTPlayerCount));
		_group.Add(SimpleNotify.Add(GetCTPlayerCount, SetCTPlayerCount));
		InitUI();
	}

	private int GetTPlayerCount(int arg1)
	{
		if (_gameRuleContext == null || _gameRuleContext.reportVisible == null)
		{
			return 0;
		}
		return _gameRuleContext.reportVisible.tPlayerList.Count;
	}

	private int GetCTPlayerCount(int arg1)
	{
		if (_gameRuleContext == null || _gameRuleContext.reportVisible == null)
		{
			return 0;
		}
		return _gameRuleContext.reportVisible.ctPlayerList.Count;
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
		GameObject container = ((team == 2) ? _viewModel.tContentObj : _viewModel.ctContentObj);
		List<ReportCellModel> list = ((team == 2) ? _tcells : _ctcells);
		for (int i = list.Count; i < arg1; i++)
		{
			ReportCellModel reportCellModel = new ReportCellModel
			{
				Index = i,
				Container = container,
				Group = _group,
				Team = team
			};
			reportCellModel.SetGameRuleContext(_gameRuleContext);
			reportCellModel.Initialize();
			list.Add(reportCellModel);
		}
	}

	private void SetVisible(bool arg1, int index)
	{
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = arg1;
		_group.SetSuspend(!arg1);
	}

	private bool GetVisible(int index)
	{
		if (_gameRuleContext == null || _gameRuleContext.reportVisible == null)
		{
			return false;
		}
		return _gameRuleContext.reportVisible.Visible;
	}

	private void CancelClicked()
	{
		_gameRuleContext.reportVisible.Visible = false;
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
			_gameRuleContext.reportVisible.Visible = false;
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
}

using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ReportCellModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private ReportCellViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public int Team { get; set; }

	public SimpleNotifyGroup Group { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new ReportCellViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		base.DoSubscribe();
		Group.Add(SimpleNotify.Add(GetVisible, SetVisible, Index));
		Group.Add(SimpleNotify.Add(GetName, SetName, Index));
		_viewModel.ReportCellClicked.AddListener(OnClicked);
	}

	private void SetSelected(bool arg1, int arg2)
	{
		_viewModel.SelectedShow = arg1;
	}

	private bool GetSelected(int index)
	{
		return GetPlayer(index)?.Selected ?? false;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ReportCellShow = arg1;
	}

	private bool GetVisible(int index)
	{
		return GetPlayer(index) != null;
	}

	private ReportVisibleComponent.ReportPlayer GetPlayer(int index)
	{
		List<ReportVisibleComponent.ReportPlayer> list = _gameRuleContext.reportVisible.ctPlayerList;
		if (Team == 2)
		{
			list = _gameRuleContext.reportVisible.tPlayerList;
		}
		if (index >= list.Count)
		{
			return null;
		}
		return list[index];
	}

	private void OnClicked()
	{
		ReportVisibleComponent.ReportPlayer player = GetPlayer(Index);
		_gameRuleContext.reportVisible.selectPlayer = player;
		_gameRuleContext.reportVisible.Visible = false;
		_gameRuleContext.reportVisible.alertFrom = 1;
		_gameRuleContext.reportVisible.alertVisible = true;
	}

	private void SetIsReported(bool arg1, int arg2)
	{
		_viewModel.ReportCellEnabled = !arg1;
		_viewModel.PlayerNameTextcolor = (arg1 ? new Color(0.6f, 0.6f, 0.6f) : Color.white);
		if (arg1)
		{
			_viewModel.SelectedShow = false;
		}
	}

	private bool GetIsReported(int index)
	{
		return GetPlayer(index)?.Reported ?? false;
	}

	private void SetName(string arg1, int index)
	{
		_viewModel.PlayerNameString = arg1;
	}

	private string GetName(int index)
	{
		ReportVisibleComponent.ReportPlayer player = GetPlayer(index);
		if (player == null)
		{
			return "";
		}
		return player.Name;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ReportAlertCellModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private ReportAlertCellViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public string Message { get; set; }

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
		_viewModel = new ReportAlertCellViewModel();
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
		Group.Add(SimpleNotify.Add(GetSelected, SetSelected, Index));
		_viewModel.ReportCellClicked.AddListener(OnClicked);
	}

	private void SetSelected(bool arg1, int arg2)
	{
		_viewModel.GouShow = arg1;
		_viewModel.SelectedShow = false;
	}

	private bool GetSelected(int index)
	{
		if (_gameRuleContext == null || _gameRuleContext.reportVisible == null)
		{
			return false;
		}
		return Index == _gameRuleContext.reportVisible.reasonIndex;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ReportCellShow = arg1;
	}

	private bool GetVisible(int index)
	{
		return true;
	}

	private void OnClicked()
	{
		_gameRuleContext.reportVisible.reasonIndex = Index;
	}

	private void SetName(string arg1, int index)
	{
		_viewModel.PlayerNameString = arg1;
	}

	private string GetName(int index)
	{
		return Message;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

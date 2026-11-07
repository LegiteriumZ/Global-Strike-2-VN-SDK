using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Common;

public class WaitPlayerModel : AbstractModel, IPlaybackSystem
{
	private WaitPlayerViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new WaitPlayerViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioMessageData_WaitingPlayerNum, SetWaitingPlayerNum, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetWaitingPlayerNum(int ov, int num)
	{
		_viewModel.PanelShow = num > 0;
		if (num > 0)
		{
			_viewModel.WaitingPlayerNumberString = StringCache.IntToString(num);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

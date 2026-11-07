using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveFirstWinModel : AbstractModel, IPlaybackSystem
{
	private PveFirstWinViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveFirstWinViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true);
	}

	private void SetObserver(int arg1, int arg2)
	{
		if (Contexts.sharedInstance.gameRule.currentRule.Rule.IsGeneralPve())
		{
			_viewModel.ShowShow = false;
		}
		else
		{
			_viewModel.ShowShow = arg2 == 0;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

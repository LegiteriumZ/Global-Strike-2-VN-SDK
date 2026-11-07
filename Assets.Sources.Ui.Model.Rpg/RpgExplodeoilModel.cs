using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgExplodeoilModel : AbstractModel, IPlaybackSystem
{
	private RpgExplodeoilViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgExplodeoilViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_ExplodeOil, SetExplodeOil, null, initinvoke: true);
	}

	private void SetExplodeOil(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

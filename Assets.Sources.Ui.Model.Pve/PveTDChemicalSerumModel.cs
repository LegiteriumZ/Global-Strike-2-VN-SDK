using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Pve;

public class PveTDChemicalSerumModel : AbstractModel, IPlaybackSystem
{
	private PveTDChemicalSerumViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveTDChemicalSerumViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_BiochemicalMagazineFlag, SetBiochemicalMagazineFlag, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_ArmorBody, SetArmorBody, null, initinvoke: true);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SetBiochemicalMagazineFlag(bool ov, bool show)
	{
		_viewModel.backShow = show;
	}

	private void SetArmorBody(bool ov, bool show)
	{
		_viewModel.armorbodyBackShow = show;
	}
}

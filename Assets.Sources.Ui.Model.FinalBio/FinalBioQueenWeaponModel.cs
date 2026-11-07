using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Finalbio;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioQueenWeaponModel : AbstractModel, IPlaybackSystem
{
	private FinalbioqueenweaponViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new FinalbioqueenweaponViewModel();
	}

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_CurrentWeapon, SetCurrentWeapon, null, initinvoke: true);
	}

	private void SetCurrentWeapon(int ov, int currentWeapon)
	{
		if (currentWeapon == 2)
		{
			_viewModel.SelectWeaponShow1 = true;
			_viewModel.SelectWeaponShow2 = false;
		}
		else
		{
			_viewModel.SelectWeaponShow1 = false;
			_viewModel.SelectWeaponShow2 = true;
		}
	}

	private void SetCareer(string ov, string career)
	{
		_viewModel.BottomShow = career == "queen";
	}

	private void InitChips()
	{
	}
}

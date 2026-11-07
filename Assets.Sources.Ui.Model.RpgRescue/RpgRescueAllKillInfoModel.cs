using Assets.Sources.Ui.Model.PveCommon;

namespace Assets.Sources.Ui.Model.RpgRescue;

public class RpgRescueAllKillInfoModel : PveAllKillInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgrescue";
		_viewModel.ResourceAssetName = "RpgRescueAllKillInfo";
		TeamMember = 10;
	}
}

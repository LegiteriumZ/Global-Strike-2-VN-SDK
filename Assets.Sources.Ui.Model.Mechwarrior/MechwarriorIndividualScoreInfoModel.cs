using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/mechwarrior";
		_viewModel.ResourceAssetName = "MechwarriorIndividualScoreInfo";
	}
}

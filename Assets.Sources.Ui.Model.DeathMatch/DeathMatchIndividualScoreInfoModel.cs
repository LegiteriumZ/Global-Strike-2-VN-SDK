using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/deathmatch";
		_viewModel.ResourceAssetName = "DeathMatchIndividualScoreInfo";
		CellClass = typeof(DeathMatchPlayerScoreCellModel);
	}
}

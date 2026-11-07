using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchStrikeIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/deathmatch";
		_viewModel.ResourceAssetName = "DeathMatchStrikeIndividualScoreInfo";
		CellClass = typeof(DeathMatchStrikePlayerScoreCellModel);
		IsStrike = true;
	}
}

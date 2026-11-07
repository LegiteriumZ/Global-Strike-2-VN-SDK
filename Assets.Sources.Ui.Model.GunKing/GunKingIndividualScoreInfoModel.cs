using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.GunKing;

public class GunKingIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/gunking";
		_viewModel.ResourceAssetName = "GunKingIndividualScoreInfo";
		CellClass = typeof(GunKingPlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}
}

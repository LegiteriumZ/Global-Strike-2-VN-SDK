using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/goldexplode";
		_viewModel.ResourceAssetName = "GoldExplodeIndividualScoreInfo";
		CellClass = typeof(GoldExplodeIndividualScoreCellModel);
	}
}

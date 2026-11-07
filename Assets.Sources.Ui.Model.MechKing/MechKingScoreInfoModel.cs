using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.MechKing;

public class MechKingScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/MechKing";
		_viewModel.ResourceAssetName = "MechKingScoreInfo";
		CellClass = typeof(MechKingScoreCellModel);
	}
}

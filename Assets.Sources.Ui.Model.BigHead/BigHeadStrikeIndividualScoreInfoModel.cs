using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.BigHead;

public class BigHeadStrikeIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/bighead";
		_viewModel.ResourceAssetName = "BigheadStrikeIndividualScoreinfo";
		CellClass = typeof(BigheadStrikeIndividualScoreCellModel);
		IsStrike = true;
	}
}

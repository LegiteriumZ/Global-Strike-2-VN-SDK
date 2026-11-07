using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.BigHead;

public class BigHeadIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/bighead";
		_viewModel.ResourceAssetName = "BigHeadIndividualScoreInfo";
		CellClass = typeof(BigheadIndividualScoreCellModel);
	}
}

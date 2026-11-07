using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biochemical";
		_viewModel.ResourceAssetName = "BiochemicalIndividualScoreInfo";
		CellClass = typeof(BiochemicalPlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}
}

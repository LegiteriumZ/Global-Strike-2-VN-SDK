using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.AllRoundSinglesModel;

internal class AllRoundSinglesRecordInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/allroundsingles";
		_viewModel.ResourceAssetName = "AllRoundSinglesRecordInfo";
		CellClass = typeof(AllRoundSinglesPlayerScorecellModel);
	}
}

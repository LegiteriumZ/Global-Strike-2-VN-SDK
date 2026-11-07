using Assets.Sources.Free.Data;

namespace Assets.Sources.Ui.Model.Common;

public class MatchIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/common";
		_viewModel.ResourceAssetName = "MatchIndividualScoreInfo";
		CellClass = typeof(MatchIndividualScoreCellModel);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		if (GameModelLocator.GetInstance().GameModel.IsMatch)
		{
			_viewModel.ViewGameObjectShow = true;
		}
		else
		{
			_viewModel.ViewGameObjectShow = false;
		}
	}
}

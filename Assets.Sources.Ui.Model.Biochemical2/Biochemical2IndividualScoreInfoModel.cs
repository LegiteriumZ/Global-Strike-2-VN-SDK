using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Biochemical2;

public class Biochemical2IndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biochemical2";
		_viewModel.ResourceAssetName = "Biochemical2IndividualScoreInfo";
		CellClass = typeof(Biochemical2PlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 32;
	}

	protected override void SetPlayerNum(int idx)
	{
		if (RaceType == 122)
		{
			_viewModel.PlayerNumberString = "";
		}
		else
		{
			base.SetPlayerNum(idx);
		}
	}
}

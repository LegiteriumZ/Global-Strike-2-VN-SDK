using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Personal;

public class PersonalStrikeIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/personal";
		_viewModel.ResourceAssetName = "PersonalStrikeIndividualScoreInfo";
		CellClass = typeof(PersonalStrikePlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
		IsStrike = true;
	}
}

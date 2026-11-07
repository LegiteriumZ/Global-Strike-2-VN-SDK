using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Personal;

public class PersonalIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/personal";
		_viewModel.ResourceAssetName = "PersonalIndividualScoreInfo";
		CellClass = typeof(PersonalPlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}
}

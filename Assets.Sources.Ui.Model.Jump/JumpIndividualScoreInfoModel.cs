using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/jump";
		_viewModel.ResourceAssetName = "JumpIndividualScoreInfo";
		CellClass = typeof(JumpPlayerScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}
}

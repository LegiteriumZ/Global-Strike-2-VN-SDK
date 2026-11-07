using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Group;

public class GroupStrikeIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/group";
		_viewModel.ResourceAssetName = "GroupStrikeIndividualScoreInfo";
		CellClass = typeof(GroupStrikeIndividualScoreCellModel);
		IsStrike = true;
	}
}

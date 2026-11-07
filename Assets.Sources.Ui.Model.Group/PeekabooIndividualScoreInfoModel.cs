using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.Group;

public class PeekabooIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/peekaboo";
		_viewModel.ResourceAssetName = "PeekabooAllKillInfo";
		CellClass = typeof(PeekabooIndividualScoreCellModel);
		TeamMember = 16;
	}
}

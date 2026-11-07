using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.BroadSword;

[GameUiTest]
public class BroadSwordIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/BroadSword";
		_viewModel.ResourceAssetName = "BroadSwordIndividualScoreInfo";
		CellClass = typeof(BroadSwordScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}
}

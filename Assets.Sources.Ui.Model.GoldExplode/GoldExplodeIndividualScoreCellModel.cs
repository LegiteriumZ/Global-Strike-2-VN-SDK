using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.GoldExplode;

[GameUiTest]
public class GoldExplodeIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/goldexplode";
		_viewModel.ResourceAssetName = "GoldExplodeIndividualScoreCell";
	}
}

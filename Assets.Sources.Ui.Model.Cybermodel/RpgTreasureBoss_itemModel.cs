using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.Cybermodel;

[GameUiTest]
public class RpgTreasureBoss_itemModel : Cybermodel_itemModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgtreasurebossmodel";
		_viewModel.ResourceAssetName = "treasurebossmodel_item";
	}
}

using Assets.Sources.Ui.Model.Cybermodel;

namespace Assets.Sources.Ui.Model.RpgStarWalker;

public class RpgStarWalkerCyberItemModel : Cybermodel_itemModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgstarwalker";
		_viewModel.ResourceAssetName = "RpgStarWalkerCyberItem";
	}
}

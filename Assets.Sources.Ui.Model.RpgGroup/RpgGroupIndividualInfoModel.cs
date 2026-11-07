using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.RpgGroup;

public class RpgGroupIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpggroup";
		_viewModel.ResourceAssetName = "RpgGroupIndividualInfo";
		CellClass = typeof(RpgGroupIndividualScoreCellModel);
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = false;
	}
}

using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.RpgGroup;

namespace Assets.Sources.Ui.Model.RpgDuel;

public class RpgDuelIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpggroup";
		_viewModel.ResourceAssetName = "RpgGroupIndividualInfo";
		CellClass = typeof(RpgGroupIndividualScoreCellModel);
	}

	protected override void SetMatchBack(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = false;
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
		_viewModel.ObserverBackShow = false;
	}

	protected override void SetObserverList(List<string> ov, List<string> list)
	{
		_viewModel.ObserverBackShow = false;
	}
}

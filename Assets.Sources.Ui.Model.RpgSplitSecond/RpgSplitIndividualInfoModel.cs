using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.RpgSplitSecond;

[GameUiTest]
public class RpgSplitIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgSplitSecond";
		_viewModel.ResourceAssetName = "RpgSplitSecondAllKillInfo";
		CellClass = typeof(RpgSplitScoreCellModel);
		TeamNum = 1;
		TeamMember = 12;
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
	}

	protected override void SetObserverList(List<string> ov, List<string> list)
	{
	}
}

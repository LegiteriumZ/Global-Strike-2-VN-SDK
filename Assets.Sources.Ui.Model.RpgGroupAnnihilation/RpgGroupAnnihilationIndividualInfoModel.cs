using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.RpgGroupAnnihilation;

[GameUiTest]
public class RpgGroupAnnihilationIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgGroupAnnihilation";
		_viewModel.ResourceAssetName = "RpgGroupAnnihilationIndividualInfo";
		CellClass = typeof(RpgGroupAnnihilationScoreCellModel);
		TeamNum = 1;
		TeamMember = 16;
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
	}

	protected override void SetObserverList(List<string> ov, List<string> list)
	{
	}
}

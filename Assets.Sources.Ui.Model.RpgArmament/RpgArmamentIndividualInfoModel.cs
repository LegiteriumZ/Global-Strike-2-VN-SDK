using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.RpgArmament;

[GameUiTest]
public class RpgArmamentIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgArmament";
		_viewModel.ResourceAssetName = "RpgArmamentAllKillInfo";
		CellClass = typeof(RpgArmamentScoreCellModel);
		TeamNum = 1;
		TeamMember = 12;
	}

	protected override void SetMatchBack(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = false;
	}

	protected override void SetIsObserver(bool ov, bool flag)
	{
	}

	protected override void SetObserverList(List<string> ov, List<string> list)
	{
	}
}

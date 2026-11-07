using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.RpgStealExpert;

[GameUiTest]
public class RpgStealExpertIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgStealExpert";
		_viewModel.ResourceAssetName = "RpgStealExpertAllKillInfo";
		CellClass = typeof(RpgStealExpertScoreCellMode);
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

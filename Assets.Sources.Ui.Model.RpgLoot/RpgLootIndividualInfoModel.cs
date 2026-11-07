using System.Collections.Generic;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;

namespace Assets.Sources.Ui.Model.RpgLoot;

[GameUiTest]
public class RpgLootIndividualInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgLoot";
		_viewModel.ResourceAssetName = "RpgLootAllKillInfo";
		CellClass = typeof(RpgLootScoreCellModel);
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

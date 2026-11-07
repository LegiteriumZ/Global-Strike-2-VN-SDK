using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;

namespace Assets.Sources.Ui.Model.Group;

[GameUiTest]
public class GroupStrikeIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/group";
		_viewModel.ResourceAssetName = "GroupStrikeIndividualScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.StrikeScore.ToString();
		_viewModel.PlayerScoreString2 = data.AccessoryScore.ToString();
		_viewModel.PlayerScoreString3 = data.AssistsNum.ToString();
	}
}

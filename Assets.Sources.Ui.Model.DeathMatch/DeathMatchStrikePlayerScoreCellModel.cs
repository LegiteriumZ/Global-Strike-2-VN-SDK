using NetData;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchStrikePlayerScoreCellModel : DeathMatchPlayerScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/deathmatch";
		_viewModel.ResourceAssetName = "DeathMatchStrikePlayerScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.StrikeScore.ToString();
		_viewModel.PlayerScoreString2 = data.AccessoryScore.ToString();
		_viewModel.PlayerScoreString3 = data.ReliveNum.ToString();
		_viewModel.PlayerScoreString4 = data.AssistsNum.ToString();
	}
}

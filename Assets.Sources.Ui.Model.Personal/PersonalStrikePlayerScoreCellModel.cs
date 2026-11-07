using NetData;

namespace Assets.Sources.Ui.Model.Personal;

public class PersonalStrikePlayerScoreCellModel : PersonalPlayerScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/personal";
		_viewModel.ResourceAssetName = "PersonalStrikePlayerScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.StrikeScore.ToString();
		_viewModel.PlayerScoreString2 = data.AccessoryScore.ToString();
	}
}

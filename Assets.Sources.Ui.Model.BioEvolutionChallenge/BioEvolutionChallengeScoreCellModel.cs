using Assets.Sources.Ui.Model.BigHead;
using Assets.Sources.Ui.Model.Common;
using NetData;

namespace Assets.Sources.Ui.Model.BioEvolutionChallenge;

public class BioEvolutionChallengeScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/bioevolutionchallenge";
		_viewModel.ResourceAssetName = "BioEvolutionChallengeScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.Score.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref CommonIndividualScoreCellModel.KdKingAsset);
		index = SetHonoray(data.Mvp, index, ref CommonIndividualScoreCellModel.MvpAsset);
		index = SetHonoray(data.Nurse, index, ref BigheadIndividualScoreCellModel.NurseAsset);
		index = SetHonoray(data.Overload, index, ref BigheadIndividualScoreCellModel.OverloadAsset);
		return SetHonoray(data.Terminator, index, ref BigheadIndividualScoreCellModel.TerminatorAsset);
	}
}

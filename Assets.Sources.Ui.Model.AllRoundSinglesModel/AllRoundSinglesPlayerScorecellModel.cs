using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.AllRoundSinglesModel;

internal class AllRoundSinglesPlayerScorecellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/allroundsingles";
		_viewModel.ResourceAssetName = "AllRoundSinglesPlayerScorecell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.LongToString(data.KillNum);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.BeKillNum);
		BroadcastScoreComponent broadcastScore = Contexts.sharedInstance.gameRule.broadcastScore;
		int value = (int)((data.Team == 1) ? broadcastScore.Team1Score : broadcastScore.Team2Score);
		_viewModel.PlayerScoreString3 = StringCache.IntToString(value);
	}
}

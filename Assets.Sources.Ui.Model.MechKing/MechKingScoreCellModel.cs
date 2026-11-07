using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.MechKing;

public class MechKingScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/MechKing";
		_viewModel.ResourceAssetName = "MechKingScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.LongToString(data.Score);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.BeKillNum);
		_viewModel.PlayerScoreString3 = StringCache.IntToString(data.KillNum);
	}
}

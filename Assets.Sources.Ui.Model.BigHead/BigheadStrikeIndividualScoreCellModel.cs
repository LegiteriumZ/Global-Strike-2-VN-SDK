using Assets.Tests.PlayMode;
using NetData;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class BigheadStrikeIndividualScoreCellModel : BigheadIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/bighead";
		_viewModel.ResourceAssetName = "BigheadStrikeIndividualScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.IntToString(data.StrikeScore);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.AccessoryScore);
		_viewModel.PlayerScoreString3 = StringCache.LongToString(data.Score);
		_viewModel.PlayerScoreString4 = StringCache.IntToString(data.TreatmentScore);
	}
}

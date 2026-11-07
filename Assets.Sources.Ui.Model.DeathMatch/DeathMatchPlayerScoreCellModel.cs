using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchPlayerScoreCellModel : CommonIndividualScoreCellModel
{
	protected static AssetInfo NurseAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/wet.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/deathmatch";
		_viewModel.ResourceAssetName = "deathmatchplayerscorecell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.LongToString(data.Score);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.KillNum);
		_viewModel.PlayerScoreString3 = StringCache.IntToString(data.BeKillNum);
		_viewModel.PlayerScoreString4 = StringCache.IntToString(data.ReliveNum);
		_viewModel.PlayerScoreString5 = StringCache.IntToString(data.AssistsNum);
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref CommonIndividualScoreCellModel.KdKingAsset);
		index = SetHonoray(data.Mvp, index, ref CommonIndividualScoreCellModel.MvpAsset);
		return SetHonoray(data.Nurse, index, ref NurseAsset);
	}
}

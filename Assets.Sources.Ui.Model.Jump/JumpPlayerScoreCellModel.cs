using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpPlayerScoreCellModel : CommonIndividualScoreCellModel
{
	protected static AssetInfo NurseAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/wet.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/jump";
		_viewModel.ResourceAssetName = "jumpplayerscorecell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		int num = data.JumpTime / 1000;
		_viewModel.PlayerScoreString1 = StringCache.IntToStringD2(num / 60);
		_viewModel.PlayerScoreString2 = StringCache.IntToStringD2(num % 60);
		_viewModel.PlayerScoreString3 = StringCache.IntToStringD3(data.JumpTime % 1000 / 10);
		_viewModel.PlayerScoreString4 = StringCache.IntToString(data.AdditionalTime);
		_viewModel.PlayerScoreString5 = StringCache.IntToString(data.SavePoint);
		_viewModel.PlayerScoreString6 = StringCache.IntToString(data.ReadPoint);
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		return SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
	}
}

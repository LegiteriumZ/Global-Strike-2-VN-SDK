using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.Group;

[GameUiTest]
public class PeekabooIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	protected static AssetInfo AceAsset1 = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/killList/ace.png");

	protected static AssetInfo Ace2Asset1 = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/killList/2nd.png");

	protected static AssetInfo Ace3Asset1 = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/killList/3nd.png");

	protected static AssetInfo KdKingAsset1 = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/killList/kd.png");

	protected static AssetInfo MvpAsset1 = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/killList/mvp.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/peekaboo";
		_viewModel.ResourceAssetName = "PeekabooAllKillInfoScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.ReliveNum.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
		_viewModel.PlayerScoreString3 = data.Score.ToString();
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref AceAsset1);
		index = SetHonoray(data.Ace2, index, ref Ace2Asset1);
		index = SetHonoray(data.Ace3, index, ref Ace3Asset1);
		index = SetHonoray(data.KdKing, index, ref KdKingAsset1);
		return SetHonoray(data.Mvp, index, ref MvpAsset1);
	}
}

using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalHonoraryModel : CommonPlayerHonoraryModel
{
	private static AssetInfo _dominateAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/dominate.png");

	private static AssetInfo _survivorAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/survivor.png");

	private static AssetInfo _spreeAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/spree.png");

	protected override int UpdateHonoraryImage(OneKillInfoData killInfo)
	{
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref _dominateAsset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _survivorAsset);
		return SetHonoraryImage(killInfo.Ace3, index, ref _spreeAsset);
	}
}

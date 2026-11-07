using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.GroupGunKing;

public class GroupGunKingHonoraryModel : CommonPlayerHonoraryModel
{
	private static AssetInfo _gunkingAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/gunking.png");

	private static AssetInfo _2NdAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/2nd.png");

	private static AssetInfo _3NdAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/3nd.png");

	private static AssetInfo _kdAsset = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/hononary/kd.png");

	protected override int UpdateHonoraryImage(OneKillInfoData killInfo)
	{
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref _gunkingAsset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _2NdAsset);
		index = SetHonoraryImage(killInfo.Ace3, index, ref _3NdAsset);
		return SetHonoraryImage(killInfo.KdKing, index, ref _kdAsset);
	}
}

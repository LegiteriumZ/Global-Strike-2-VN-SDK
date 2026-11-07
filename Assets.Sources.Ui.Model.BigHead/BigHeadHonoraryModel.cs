using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.BigHead;

internal class BigHeadHonoraryModel : CommonPlayerHonoraryModel
{
	private static AssetInfo _aceAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/ace.png");

	private static AssetInfo _2NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/2nd.png");

	private static AssetInfo _3NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/3nd.png");

	private static AssetInfo _mvpAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/mvp.png");

	private static AssetInfo _kdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/kd.png");

	private static AssetInfo _bigheadKingAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/hononary/bigheadKing.png");

	private static AssetInfo _killBigheadKingAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/hononary/killBigheadKing.png");

	private static AssetInfo _wetAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/hononary/wet.png");

	protected override int UpdateHonoraryImage(OneKillInfoData killInfo)
	{
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref _aceAsset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _2NdAsset);
		index = SetHonoraryImage(killInfo.Ace3, index, ref _3NdAsset);
		index = SetHonoraryImage(killInfo.Mvp, index, ref _mvpAsset);
		index = SetHonoraryImage(killInfo.KdKing, index, ref _kdAsset);
		index = SetHonoraryImage(killInfo.Overload, index, ref _bigheadKingAsset);
		index = SetHonoraryImage(killInfo.Terminator, index, ref _killBigheadKingAsset);
		return SetHonoraryImage(killInfo.Nurse, index, ref _wetAsset);
	}
}

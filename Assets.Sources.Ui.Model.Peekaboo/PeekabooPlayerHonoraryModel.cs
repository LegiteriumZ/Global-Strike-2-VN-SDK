using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.Peekaboo;

public class PeekabooPlayerHonoraryModel : CommonPlayerHonoraryModel
{
	private static AssetInfo _aceAsset = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/hononary/ace.png");

	private static AssetInfo _2NdAsset = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/hononary/2nd.png");

	private static AssetInfo _3NdAsset = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/hononary/3nd.png");

	private static AssetInfo _mvpAsset = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/hononary/mvp.png");

	private static AssetInfo _kdAsset = new AssetInfo("ui/peekabooModel", "Assets/Res/Assets/ui/GameGUIRes/peekabooModel/hononary/kd.png");

	protected override int UpdateHonoraryImage(OneKillInfoData killInfo)
	{
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref _aceAsset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _2NdAsset);
		index = SetHonoraryImage(killInfo.Ace3, index, ref _3NdAsset);
		index = SetHonoraryImage(killInfo.Mvp, index, ref _mvpAsset);
		return SetHonoraryImage(killInfo.KdKing, index, ref _kdAsset);
	}
}

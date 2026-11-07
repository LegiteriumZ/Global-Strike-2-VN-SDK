using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class BreakPointAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _aAreaAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/Aarea.png");

	private static AssetInfo _bAreaAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/Barea.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		if (lv == 0)
		{
			return _aAreaAsset;
		}
		return _bAreaAsset;
	}

	public BreakPointAssetInfo(string name)
		: base(name)
	{
	}
}

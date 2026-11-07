using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class SafeAreaAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/bladefightmodel", "raderFogBack");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}

	public SafeAreaAssetInfo(string name)
		: base(name)
	{
	}
}

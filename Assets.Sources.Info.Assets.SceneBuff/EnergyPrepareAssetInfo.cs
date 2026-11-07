using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class EnergyPrepareAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/bladefightmodel", "reliveBagIcon");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}

	public EnergyPrepareAssetInfo(string name)
		: base(name)
	{
	}
}

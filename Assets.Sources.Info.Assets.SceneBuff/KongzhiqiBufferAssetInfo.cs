using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class KongzhiqiBufferAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return new AssetInfo("", "");
	}

	public KongzhiqiBufferAssetInfo(string name)
		: base(name)
	{
	}
}

using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class KrissHealBufferAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return new AssetInfo("", "");
	}

	public KrissHealBufferAssetInfo(string name)
		: base(name)
	{
	}
}

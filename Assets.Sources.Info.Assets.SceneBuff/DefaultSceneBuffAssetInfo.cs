using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

internal class DefaultSceneBuffAssetInfo : ISceneBuffAssetInfo
{
	private string _name;

	private AssetInfo _smallMapAssetInfo;

	public bool AddRotateSelf => false;

	public string Name => _name;

	public DefaultSceneBuffAssetInfo(string name, AssetInfo smallMapAssetInfo)
	{
		_name = name;
		_smallMapAssetInfo = smallMapAssetInfo;
	}

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAssetInfo;
	}
}

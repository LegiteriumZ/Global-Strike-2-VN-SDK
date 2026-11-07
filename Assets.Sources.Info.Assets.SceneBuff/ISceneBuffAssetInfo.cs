using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public interface ISceneBuffAssetInfo
{
	string Name { get; }

	bool AddRotateSelf { get; }

	AssetInfo GetSmallMapAsset(int lv);
}

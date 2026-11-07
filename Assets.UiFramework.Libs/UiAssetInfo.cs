using SSJJBase.String;

namespace Assets.UiFramework.Libs;

public struct UiAssetInfo
{
	public IgnoreCaseString BundleName { get; private set; }

	public IgnoreCaseString AssetName { get; private set; }

	public UiAssetInfo(string bundle, string asset)
	{
		BundleName = new IgnoreCaseString(bundle);
		AssetName = new IgnoreCaseString(asset);
	}
}

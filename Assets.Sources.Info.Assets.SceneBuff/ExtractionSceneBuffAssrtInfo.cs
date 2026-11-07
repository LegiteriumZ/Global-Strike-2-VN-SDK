using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class ExtractionSceneBuffAssrtInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/cybermodel", "Assets/Res/Assets/ui/GameGUIRes/cybermodel/extractionpoint.png");

	public bool AddRotateSelf { get; private set; }

	public ExtractionSceneBuffAssrtInfo(string name)
		: base(name)
	{
	}

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}
}

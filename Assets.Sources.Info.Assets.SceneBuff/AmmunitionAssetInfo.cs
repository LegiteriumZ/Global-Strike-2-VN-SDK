using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class AmmunitionAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/rader/ammunitionicon.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}

	public AmmunitionAssetInfo(string name)
		: base(name)
	{
	}
}

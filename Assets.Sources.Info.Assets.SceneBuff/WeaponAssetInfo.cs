using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class WeaponAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/rader/weapon.png");

	public bool AddRotateSelf => true;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}

	public WeaponAssetInfo(string name)
		: base(name)
	{
	}
}

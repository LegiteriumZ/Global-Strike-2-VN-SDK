using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class EnergyDeviceAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/titanlaboratorymodel", "Assets/Res/Assets/ui/GameGUIRes/titanlaboratoryModel/rader/energydevice.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return _smallMapAsset;
	}

	public EnergyDeviceAssetInfo(string name)
		: base(name)
	{
	}
}

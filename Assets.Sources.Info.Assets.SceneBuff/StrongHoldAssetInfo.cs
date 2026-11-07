using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class StrongHoldAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _aAsset = new AssetInfo("ui/bladestrongholdmodel", "Assets/Res/Assets/ui/GameGUIRes/bladestrongholdModel/rader/a.png");

	private static AssetInfo _bAsset = new AssetInfo("ui/bladestrongholdmodel", "Assets/Res/Assets/ui/GameGUIRes/bladestrongholdModel/rader/b.png");

	private static AssetInfo _cAsset = new AssetInfo("ui/bladestrongholdmodel", "Assets/Res/Assets/ui/GameGUIRes/bladestrongholdModel/rader/c.png");

	private static AssetInfo _dAsset = new AssetInfo("ui/bladestrongholdmodel", "Assets/Res/Assets/ui/GameGUIRes/bladestrongholdModel/rader/d.png");

	private static AssetInfo _eAsset = new AssetInfo("ui/bladestrongholdmodel", "Assets/Res/Assets/ui/GameGUIRes/bladestrongholdModel/rader/e.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		return lv switch
		{
			0 => _aAsset, 
			1 => _bAsset, 
			2 => _cAsset, 
			3 => _dAsset, 
			4 => _eAsset, 
			_ => _aAsset, 
		};
	}

	public StrongHoldAssetInfo(string name)
		: base(name)
	{
	}
}

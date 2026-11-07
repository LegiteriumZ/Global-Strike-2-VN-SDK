using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class BuySkillAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _smallMapAsset = new AssetInfo("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/rader/buy_skill.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if ((raceType == 1005 || raceType == 1001 || raceType == 1002 || raceType == 1003 || raceType == 1004) && lv > 0)
		{
			return _smallMapAsset;
		}
		return AssetInfo.None;
	}

	public BuySkillAssetInfo(string name)
		: base(name)
	{
	}
}

using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class SkillBufferAssetInfo : AbstractSceneBuffAssetInfo, ISceneBuffAssetInfo
{
	private static AssetInfo _playerskillAsset = new AssetInfo("ui/recreationgroupgodel", "Assets/Res/Assets/ui/GameGUIRes/recreationGroupModel/rader/playerskill.png");

	private static AssetInfo _heroswordskillAsset = new AssetInfo("ui/groupheromodel", "Assets/Res/Assets/ui/GameGUIRes/groupHeroModel/rader/heroswordskill.png");

	public bool AddRotateSelf => false;

	public AssetInfo GetSmallMapAsset(int lv)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (raceType == 1005 || raceType == 1001 || raceType == 1002 || raceType == 1003 || raceType == 1004)
		{
			return AssetInfo.None;
		}
		if (SkillNameConstant.InSkillNameList(base.Name))
		{
			return _playerskillAsset;
		}
		return _heroswordskillAsset;
	}

	public SkillBufferAssetInfo(string name)
		: base(name)
	{
	}
}

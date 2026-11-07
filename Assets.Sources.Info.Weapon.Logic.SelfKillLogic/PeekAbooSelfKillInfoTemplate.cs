using System.Collections.Generic;
using Assets.Sources.Utils;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

public class PeekAbooSelfKillInfoTemplate : ISelfKillInfoTemplate
{
	public int GetSelfKillType()
	{
		return 4;
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		SelfKillTempData selfKillTempData = new SelfKillTempData(1);
		selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/killitem");
		return selfKillTempData;
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		return new List<AssetInfo> { UIResourceUtility.GetCommonTextureName("selfkill/killitem") };
	}

	public void Init(string weapon)
	{
	}
}

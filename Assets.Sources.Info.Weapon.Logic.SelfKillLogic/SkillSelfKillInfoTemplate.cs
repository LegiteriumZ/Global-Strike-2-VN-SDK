using System.Collections.Generic;
using Assets.Sources.Utils;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

internal class SkillSelfKillInfoTemplate : ISelfKillInfoTemplate
{
	public int GetSelfKillType()
	{
		return 5;
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		SelfKillTempData selfKillTempData = new SelfKillTempData(1);
		selfKillTempData.KillImage[0] = UIResourceUtility.GetWeaponUISelfKillTextureName(killInfoData.WeaponName, "selfkill/skillkill");
		return selfKillTempData;
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		return new List<AssetInfo> { UIResourceUtility.GetWeaponUISelfKillTextureName(weapon, "selfkill/skillkill") };
	}

	public void Init(string weapon)
	{
	}
}

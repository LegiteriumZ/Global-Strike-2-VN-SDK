using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Utils;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

public class DragonWeaponSelfKillInfoTemplate : ISelfKillInfoTemplate
{
	public int GetSelfKillType()
	{
		return 3;
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		SelfKillTempData selfKillTempData = new SelfKillTempData(1);
		if (killInfoData.SpecialAttack)
		{
			selfKillTempData.KillImage[0] = UIResourceUtility.GetWeaponUISelfKillTextureName(killInfoData.WeaponName, "selfkillspecialkill");
		}
		else if (killInfoData.Wallshot)
		{
			if (killInfoData.Headshot)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/wallheadshot_dragon");
			}
			else
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/wallkill_dragon");
			}
		}
		else if (killInfoData.WeaponType == 3)
		{
			selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/bombkill_dragon");
		}
		else if (killInfoData.Headshot)
		{
			if (killInfoData.WeaponType == 2)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/knifekill");
			}
			else
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/headshot_dragon");
			}
		}
		else if (isWet)
		{
			if (RuleUtilty.IsDeathRule(raceType))
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetOtherModelTextureName("selfkill/wet", 12);
			}
			else
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetModelTextureName("selfkill/wet", raceType);
			}
		}
		else
		{
			selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/defaultkill_dragon");
		}
		return selfKillTempData;
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		return new List<AssetInfo>
		{
			UIResourceUtility.GetCommonTextureName("selfkill/defaultkill_dragon"),
			UIResourceUtility.GetCommonTextureName("selfkill/wallheadshot_dragon"),
			UIResourceUtility.GetCommonTextureName("selfkill/wallkill_dragon"),
			UIResourceUtility.GetCommonTextureName("selfkill/knifekill"),
			UIResourceUtility.GetCommonTextureName("selfkill/headshot_dragon"),
			UIResourceUtility.GetCommonTextureName("selfkill/bombkill_dragon")
		};
	}

	public void Init(string weapon)
	{
	}
}

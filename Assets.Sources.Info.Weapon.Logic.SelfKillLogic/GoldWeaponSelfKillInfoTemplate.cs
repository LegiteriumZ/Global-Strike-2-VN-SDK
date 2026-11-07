using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Utils;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

public class GoldWeaponSelfKillInfoTemplate : ISelfKillInfoTemplate
{
	private static List<AssetInfo> allselfkillassets = new List<AssetInfo>
	{
		UIResourceUtility.GetCommonTextureName("selfkill/sniperrfilespecialkill_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/knifeselfspecialkill_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/wallheadshot_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/wallkill_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/defaultkill_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/knifekill_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/headshot_g"),
		UIResourceUtility.GetCommonTextureName("selfkill/bombkill_g")
	};

	public int GetSelfKillType()
	{
		return 2;
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		SelfKillTempData selfKillTempData = new SelfKillTempData(1);
		if (killInfoData.SpecialAttack)
		{
			if (killInfoData.WeaponType == 5)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/sniperrfilespecialkill_g");
			}
			else if (killInfoData.WeaponType == 2)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/knifeselfspecialkill_g");
			}
		}
		else if (killInfoData.Wallshot)
		{
			if (killInfoData.Headshot)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/wallheadshot_g");
			}
			else
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/wallkill_g");
			}
		}
		else if (killInfoData.WeaponType == 3)
		{
			selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/bombkill_g");
		}
		else if (killInfoData.Headshot)
		{
			if (killInfoData.WeaponType == 2)
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/knifekill_g");
			}
			else
			{
				selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/headshot_g");
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
			selfKillTempData.KillImage[0] = UIResourceUtility.GetCommonTextureName("selfkill/defaultkill_g");
		}
		return selfKillTempData;
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		return allselfkillassets;
	}

	public void Init(string weapon)
	{
	}
}

using System.Collections.Generic;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class InfiniteHand : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "5_zhendangbo";

	private const string WEAPON_EFFECT2 = "7_tuci";

	private const string WEAPON_EFFECT3 = "01_you_shou";

	private const string WEAPON_EFFECT4 = "01_you_pao";

	private const string WEAPON_EFFECT5 = "01_zuo_shou";

	private const string WEAPON_EFFECT6 = "02_you";

	private const string WEAPON_EFFECT7 = "02_you_juexin";

	private const string WEAPON_EFFECT8 = "02_zuo";

	private const string WEAPON_EFFECT9 = "03_you";

	private const string WEAPON_EFFECT10 = "03_you_juexin";

	private const string WEAPON_EFFECT11 = "03_zuo";

	private const string WEAPON_EFFECT12 = "1_gedou_you03";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		switch (currentWeapon.basicInfo.Info.Name)
		{
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
			SetSkinVisible(skins, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true));
			break;
		case "infinite_hand1":
		case "infinite_hand2":
		case "infinite_hand3":
			if (!currentWeapon.special.SpecialMode)
			{
				SetSkinVisible(skins, "weapon_particle_fire_effect", flag: false);
				SetSkinVisible(skins, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true, right: false));
				break;
			}
			goto default;
		default:
			SetSkinVisible(skins, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true));
			SetSkinVisible(skins, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true, right: false));
			break;
		}
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		int num = -1;
		string name = currentWeapon.basicInfo.Info.Name;
		switch (particle)
		{
		case "01_you_shou":
		case "01_you_pao":
		case "01_zuo_shou":
		case "02_you":
		case "02_you_juexin":
		case "02_zuo":
		case "03_you":
		case "03_you_juexin":
		case "03_zuo":
			num = 0;
			break;
		case "5_zhendangbo":
			num = (((currentWeapon.special.EffectLevel & 1) > 0) ? 1 : 0);
			break;
		case "7_tuci":
			num = (((currentWeapon.special.EffectLevel & 4) > 0) ? 1 : 0);
			break;
		case "1_gedou_you03":
			num = (((currentWeapon.special.EffectLevel & 8) > 0) ? 1 : 0);
			break;
		default:
			{
				if (skin == "weapon_particle_effect")
				{
					num = 0;
					if (particle.IndexOf("01") >= 0)
					{
						switch (name)
						{
						case "infinite_hand1_change_1":
						case "infinite_hand2_change_1":
						case "infinite_hand3_change_1":
							break;
						default:
							goto IL_016c;
						}
						num = (currentWeapon.special.SpecialMode ? 1 : 0);
						break;
					}
					goto IL_016c;
				}
				num = 1;
				break;
			}
			IL_016c:
			if (particle.IndexOf("02") >= 0)
			{
				if (currentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37))
				{
					num = 1;
				}
			}
			else
			{
				num = 1;
			}
			break;
		}
		return num;
	}
}

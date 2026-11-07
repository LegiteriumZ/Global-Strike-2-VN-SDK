using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class AwmStrike : AbstractThirdWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "01qiangshen_manpei";

	private const string WEAPON_EFFECT2 = "01qiangshen";

	private const string WEAPON_EFFECT3 = "02qiangkou";

	private const string WEAPON_EFFECT4 = "03qiangkou";

	private const string WEAPON_EFFECT5 = "06hudun";

	private const string WEAPON_EFFECT6 = "yanmie_manpei";

	private const string WEAPON_EFFECT7 = "yanmie";

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		bool flag = (currentWeaponEffectLevel & 2) > 0 && (currentWeaponEffectLevel & 8) > 0 && (currentWeaponEffectLevel & 4) > 0 && (currentWeaponEffectLevel & 0x10) > 0 && (currentWeaponEffectLevel & 1) > 0;
		skins["weaponeffect21"].enabled = !flag;
		skins["weaponeffect22"].enabled = flag;
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		if (skin == "weapon_particle_effect1")
		{
			if ((currentWeaponEffectLevel & 0x20) > 0)
			{
				if (particle == "06hudun")
				{
					return 1;
				}
				return 0;
			}
			if ((currentWeaponEffectLevel & 2) > 0 && (currentWeaponEffectLevel & 8) > 0 && (currentWeaponEffectLevel & 4) > 0 && (currentWeaponEffectLevel & 0x10) > 0 && (currentWeaponEffectLevel & 1) > 0)
			{
				if (particle == "01qiangshen_manpei" || particle == "yanmie_manpei")
				{
					return 1;
				}
				return 0;
			}
			if (particle == "01qiangshen" || particle == "yanmie")
			{
				return 1;
			}
			return 0;
		}
		if (FireUtility.IsFiring(player, isSelf: false))
		{
			if ((currentWeaponEffectLevel & 2) > 0 && (currentWeaponEffectLevel & 8) > 0 && (currentWeaponEffectLevel & 4) > 0 && (currentWeaponEffectLevel & 0x10) > 0 && (currentWeaponEffectLevel & 1) > 0)
			{
				if (particle == "03qiangkou")
				{
					return 1;
				}
				return 0;
			}
			if (particle == "02qiangkou")
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}
}

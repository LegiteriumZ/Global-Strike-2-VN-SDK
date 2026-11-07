using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class AwmStrike : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "01qiangshen_manpei";

	private const string WEAPON_EFFECT2 = "01qiangshen";

	private const string WEAPON_EFFECT3 = "02qiangkou";

	private const string WEAPON_EFFECT4 = "03qiangkou";

	private const string WEAPON_EFFECT5 = "06hudun";

	private const string WEAPON_EFFECT6 = "yanmie_manpei";

	private const string WEAPON_EFFECT7 = "yanmie";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool flag = (currentWeapon.special.EffectLevel & 2) > 0 && (currentWeapon.special.EffectLevel & 8) > 0 && (currentWeapon.special.EffectLevel & 4) > 0 && (currentWeapon.special.EffectLevel & 0x10) > 0 && (currentWeapon.special.EffectLevel & 1) > 0;
		skins["leftweaponeffect21"].enabled = !flag;
		skins["leftweaponeffect22"].enabled = flag;
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		int effectLevel = currentWeapon.special.EffectLevel;
		if (skin == "weapon_left_particle_effect1")
		{
			if ((effectLevel & 0x20) > 0)
			{
				if (particle == "06hudun")
				{
					return 1;
				}
				return 0;
			}
			if ((effectLevel & 2) > 0 && (effectLevel & 8) > 0 && (effectLevel & 4) > 0 && (effectLevel & 0x10) > 0 && (effectLevel & 1) > 0)
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
		if (FireUtility.IsFiring(player, isSelf: true))
		{
			if ((effectLevel & 2) > 0 && (effectLevel & 8) > 0 && (effectLevel & 4) > 0 && (effectLevel & 0x10) > 0 && (effectLevel & 1) > 0)
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

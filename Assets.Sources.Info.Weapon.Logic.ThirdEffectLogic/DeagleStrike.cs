using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class DeagleStrike : AbstractThirdWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponeffect21", (player.GetCurrentWeaponEffectLevel() & 0x40) > 0);
		SetSkinVisible(skins, "weaponeffect22", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetSkinVisible(skins, "weaponeffect23", (player.GetCurrentWeaponEffectLevel() & 2) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		switch (skin)
		{
		case "weapon_particle_effect2":
		case "weapon_left_particle_effect1":
			if (particle.Contains("qiangshen02"))
			{
				return player.GetCurrentWeaponEffectLevel() & 0x80;
			}
			return 1;
		case "weapon_particle_effect1":
		case "weapon_left_particle_effect":
			return player.GetCurrentWeaponEffectLevel() & 2;
		case "weapon_particle_effect3":
			return player.GetCurrentWeaponEffectLevel() & 0x2000;
		default:
			if (FireUtility.IsFiring(player, isSelf: false))
			{
				if ((player.GetCurrentWeaponEffectLevel() & 0x20) > 0)
				{
					if (!(skin == "weapon_particle_fire_effect1") && !(skin == "weapon_left_particle_fire_effect1"))
					{
						return 0;
					}
					return 1;
				}
				if (!(skin == "weapon_particle_fire_effect") && !(skin == "weapon_left_particle_fire_effect"))
				{
					return 0;
				}
				return 1;
			}
			return -1;
		}
	}
}

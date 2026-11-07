using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class DeagleAssault : AbstractViewWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponeffect21", (currentWeapon.special.EffectLevel & 0x20) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (skin == "weapon_particle_effect")
		{
			return 1;
		}
		if (FireUtility.IsFiring(player, isSelf: true))
		{
			if ((currentWeapon.special.EffectLevel & 0x20) > 0)
			{
				if (!(skin == "weapon_particle_fire_effect1"))
				{
					return 0;
				}
				return 1;
			}
			if (!(skin == "weapon_particle_fire_effect"))
			{
				return 0;
			}
			return 1;
		}
		return -1;
	}
}

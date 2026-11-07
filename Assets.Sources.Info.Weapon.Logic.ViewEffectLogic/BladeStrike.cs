using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BladeStrike : AbstractViewWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (currentWeapon.special.EffectLevel & 0x80) == 0;
		skins["weaponeffect25"].enabled = (currentWeapon.special.EffectLevel & 0x80) > 0;
		skins["weaponeffect22"].enabled = (currentWeapon.special.EffectLevel & 8) == 0;
		skins["weaponeffect24"].enabled = (currentWeapon.special.EffectLevel & 8) > 0;
		skins["weaponeffect23"].enabled = (currentWeapon.special.EffectLevel & 0x20) > 0;
		skins["weaponeffect26"].enabled = (currentWeapon.special.EffectLevel & 0x200) > 0;
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (particle.Contains("daohun"))
		{
			return currentWeapon.special.EffectLevel & 0x200;
		}
		if ((currentWeapon.special.EffectLevel & 0x20) > 0)
		{
			if (!particle.Contains("daoren02"))
			{
				return 0;
			}
			return 1;
		}
		if (!particle.Contains("daoren01"))
		{
			return 0;
		}
		return 1;
	}
}

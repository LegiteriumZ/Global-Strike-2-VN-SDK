using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BladeStrike : AbstractThirdWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x80) == 0;
		skins["weaponeffect25"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x80) > 0;
		skins["weaponeffect22"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) == 0;
		skins["weaponeffect24"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) > 0;
		skins["weaponeffect23"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) > 0;
		skins["weaponeffect26"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x200) > 0;
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		if (particle.Contains("daohun"))
		{
			return player.GetCurrentWeaponEffectLevel() & 0x200;
		}
		if ((player.GetCurrentWeaponEffectLevel() & 0x20) > 0)
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

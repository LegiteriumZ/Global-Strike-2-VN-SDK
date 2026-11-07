using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class RifleOpticor : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(player, Func);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponeffect21", (player.GetCurrentWeaponEffectLevel() & 1) <= 0);
		SetSkinVisible(skins, "weaponeffect22", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
	}

	private int SetEffectFlag(PlayerEntity player, string skin, string particle)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		if ((particle.Equals("1_shengpan_jian") || particle.Equals("ciyuanhuanying_jian")) && skin.Equals("weapon_particle_effect2"))
		{
			if ((currentWeaponEffectLevel & 1) > 0)
			{
				return 1;
			}
		}
		else if ((particle.Equals("1_shengpan_qiang") || particle.Equals("ciyuanhuanying_qiangshen")) && skin.Equals("weapon_particle_effect1"))
		{
			if ((currentWeaponEffectLevel & 1) == 0)
			{
				return 1;
			}
		}
		else if (particle.Equals("2_qiangkouhuohua") && FireUtility.IsFiring(player, isSelf: false))
		{
			return 1;
		}
		return 0;
	}
}

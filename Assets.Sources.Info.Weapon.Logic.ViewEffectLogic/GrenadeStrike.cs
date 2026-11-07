using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class GrenadeStrike : AbstractViewWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponeffect21", (currentWeapon.special.EffectLevel & 2) > 0);
		SetSkinVisible(skins, "weaponeffect22", (currentWeapon.special.EffectLevel & 8) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		int effectLevel = currentWeapon.special.EffectLevel;
		if ((effectLevel & 2) > 0 && (effectLevel & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_quanzhuang")
			{
				return 1;
			}
			return 0;
		}
		if ((effectLevel & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_shanguang")
			{
				return 1;
			}
			return 0;
		}
		if ((effectLevel & 2) > 0)
		{
			if (particle == "qiangxi_wuqi_yanshi")
			{
				return 1;
			}
			return 0;
		}
		if (particle == "qiangxi_wuqi")
		{
			return 1;
		}
		return 0;
	}
}

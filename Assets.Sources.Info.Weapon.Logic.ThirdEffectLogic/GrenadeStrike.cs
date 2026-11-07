using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class GrenadeStrike : AbstractThirdWeaponEffectLogic
{
	public override void Init(PlayerEntity player)
	{
		base.Init(player);
		Hide(player);
	}

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponeffect21", (player.GetCurrentWeaponLevel() & 2) > 0);
		SetSkinVisible(skins, "weaponeffect22", (player.GetCurrentWeaponLevel() & 8) > 0);
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		if ((currentWeaponLevel & 2) > 0 && (currentWeaponLevel & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_quanzhuang_85")
			{
				return 1;
			}
			return 0;
		}
		if ((currentWeaponLevel & 8) > 0)
		{
			if (particle == "qiangxi_wuqi_shanguang_85")
			{
				return 1;
			}
			return 0;
		}
		if ((currentWeaponLevel & 2) > 0)
		{
			if (particle == "qiangxi_wuqi_yanshi_85")
			{
				return 1;
			}
			return 0;
		}
		if (particle == "qiangxi_wuqi_85")
		{
			return 1;
		}
		return 0;
	}
}

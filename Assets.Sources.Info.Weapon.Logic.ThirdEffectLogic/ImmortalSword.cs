using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ImmortalSword : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool flag = player.GetCurrentWeaponSubType() == 2;
		SetParticleActiveParticleName(player, "qiangshen_wanzheng", flag);
		SetParticleActiveParticleName(player, "qiangshen_suilie", !flag);
		if (skins.ContainsKey("weaponanchor"))
		{
			skins["weaponanchor"].gameObject.SetObjectActive(flag);
		}
		if (skins.ContainsKey("weaponanchor3"))
		{
			skins["weaponanchor3"].gameObject.SetObjectActive(!flag);
		}
	}
}

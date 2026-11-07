using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ArcElectricShotgun : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		bool flag = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
		bool flag2 = FireUtility.IsFiring(player, isSelf: false);
		SetParticleActiveParticleName(player, "qiangshen_1", flag);
		SetParticleActiveParticleName(player, "qkhh", flag && flag2);
		SetParticleActiveParticleName(player, "qiangshen_0", !flag);
		SetParticleActiveParticleName(player, "qiangkouhuohua_pj", !flag && flag2);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) <= 0;
		skins["weaponeffect22"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
	}
}

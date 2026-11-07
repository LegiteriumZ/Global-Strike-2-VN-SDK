using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Ak47Assault : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (currentWeapon.special.EffectLevel & 2) > 0;
		skins["weaponeffect22"].enabled = (currentWeapon.special.EffectLevel & 8) > 0;
		skins["weaponeffect23"].enabled = (currentWeapon.special.EffectLevel & 0x20) == 0;
		skins["weaponeffect24"].enabled = (currentWeapon.special.EffectLevel & 0x20) > 0;
		SetParticleActiveParticleName(player, "akm_tx_qiangkou", (player.GetCurrentWeaponEffectLevel() & 0x80) == 0);
		SetParticleActiveParticleName(player, "akm_tx_ztq_qiangkou", (player.GetCurrentWeaponEffectLevel() & 0x80) > 0);
	}
}

using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Ak47Assault : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
		skins["weaponeffect22"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) > 0;
		skins["weaponeffect23"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) == 0;
		skins["weaponeffect24"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) > 0;
		SetParticleActiveParticleName(player, "akm_tx_qiangkou", (player.GetCurrentWeaponEffectLevel() & 0x80) == 0);
		SetParticleActiveParticleName(player, "akm_tx_ztq_qiangkou", (player.GetCurrentWeaponEffectLevel() & 0x80) > 0);
	}
}

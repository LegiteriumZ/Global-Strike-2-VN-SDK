using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Ak47Strike : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect28"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
		skins["weaponeffect27"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) > 0;
		skins["weaponeffect21"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) == 0;
		skins["weaponeffect22"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) > 0;
		skins["weaponeffect25"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x200) == 0;
		skins["weaponeffect26"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x200) > 0;
		skins["weaponeffect23"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x800) == 0;
		skins["weaponeffect24"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x800) > 0;
		SetParticleActiveParticleName(player, "ak47qiangxi_daoshen", (player.GetCurrentWeaponEffectLevel() & 0x2000) > 0);
		SetParticleActiveParticleName(player, "ak47qiangxi_qiangkou_zhituiqi", (player.GetCurrentWeaponEffectLevel() & 0x80) > 0);
		SetParticleActiveParticleName(player, "ak47qiangxi_qiangkou_putong", (player.GetCurrentWeaponEffectLevel() & 0x80) == 0);
		SetParticleActiveParticleName(player, "weilai_kaihuo", flag: true);
	}
}

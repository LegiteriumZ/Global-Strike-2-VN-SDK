using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class TwinsInfinity : AbstractThirdWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "qiangkouhuahua_jineng_qianduan";

	private const string WEAPON_EFFECT2 = "qiangkouhuahua_jineng_xunhuan_houduan";

	private const string WEAPON_EFFECT3 = "qkhh_hong";

	private const string WEAPON_EFFECT4 = "qkhh_lan";

	private const string WEAPON_EFFECT5 = "juqi";

	private const string WEAPON_EFFECT6 = "qiangkouhuahua_jineng_chixu";

	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins.ContainsKey("weapon_particle_fire_effect"))
		{
			skins["weapon_particle_fire_effect"].gameObject.SetObjectActive(isactive: true);
		}
		if (skins.ContainsKey("weapon_left_particle_fire_effect"))
		{
			skins["weapon_left_particle_fire_effect"].gameObject.SetObjectActive(isactive: true);
		}
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_qianduan", (currentWeaponEffectLevel & 2) >= 1);
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_xunhuan_houduan", (currentWeaponEffectLevel & 2) >= 1 && (currentWeaponEffectLevel & 0x40) >= 1);
		SetParticleActiveParticleName(player, "qkhh_hong", (currentWeaponEffectLevel & 2) == 0);
		SetParticleActiveParticleName(player, "qkhh_lan", flag: false);
		SetParticleActiveParticleName(player, "juqi", flag: false);
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_chixu", (currentWeaponEffectLevel & 2) >= 1 && (currentWeaponEffectLevel & 0x40) >= 1);
		SetParticleNoFireControlByParticleName(player, "qiangkouhuahua_jineng_qianduan");
		SetParticleNoFireControlByParticleName(player, "qiangkouhuahua_jineng_xunhuan_houduan");
	}
}

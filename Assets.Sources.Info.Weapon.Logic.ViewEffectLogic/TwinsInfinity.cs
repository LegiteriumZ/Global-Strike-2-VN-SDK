using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class TwinsInfinity : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "qiangkouhuahua_jineng_qianduan";

	private const string WEAPON_EFFECT2 = "qiangkouhuahua_jineng_xunhuan_houduan";

	private const string WEAPON_EFFECT3 = "juqi";

	private const string WEAPON_EFFECT4 = "qiangkouhuahua_jineng_chixu";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weapon_particle_fire_effect"].gameObject.SetObjectActive(isactive: true);
		skins["weapon_left_particle_fire_effect"].gameObject.SetObjectActive(isactive: true);
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false) && player.viewAnim.ViewAnimInfo.StateId == 15 && player.viewAnim.RemainTime > 0);
		SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", FireUtility.IsFiring(player, isSelf: false, right: false) && player.viewAnim.ViewAnimInfo.StateId == 40 && player.viewAnim.RemainTime > 0);
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_qianduan", flag: false);
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_xunhuan_houduan", flag: false);
		SetParticleActiveParticleName(player, "qiangkouhuahua_jineng_chixu", flag: false);
		SetParticleActiveParticleName(player, "juqi", player.viewAnim.ViewAnimInfo.StateId == 28 || player.viewAnim.ViewAnimInfo.StateId == 96);
	}
}

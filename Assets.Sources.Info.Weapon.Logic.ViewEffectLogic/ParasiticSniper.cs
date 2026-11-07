using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ParasiticSniper : AbstractViewWeaponEffectLogic
{
	private bool _setDestory;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (player.hasFov && (player.fov.Fov == 40 || player.fov.Fov == 10))
		{
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", flag: false);
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect1", flag: false);
			return;
		}
		SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect1", (player.GetCurrentWeaponEffectLevel() & 1) == 0);
		bool flag = false;
		if (player.viewAnim.Equals(28) && (player.GetCurrentWeaponEffectLevel() & 1) > 0 && player.viewAnim.RightCurrentTime < 355)
		{
			flag = true;
		}
		if (string.IsNullOrEmpty(currentWeapon.basicInfo.Data.WeaponSkinName))
		{
			if (flag)
			{
				DestoryParticleFireControlByParticleName(player, "chongjibo_qiu");
			}
			SetParticleActiveBySkinName(player, "weapon_left_particle_fire_effect", flag);
			return;
		}
		if (flag)
		{
			DestoryParticleFireControlByParticleName(player, "chongjibo_qiu");
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals("chongjibo_qiu"))
			{
				particle.Value.GetIns().GetComponent<IFireEffectControl>().SetRender(flag);
			}
		}
	}
}

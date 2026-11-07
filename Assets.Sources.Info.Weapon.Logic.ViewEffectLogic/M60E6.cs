using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class M60E6 : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect")?.SetInsActive(currentWeapon.special.Level >= 300);
		int level = currentWeapon.special.Level;
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		float effectTime = (float)level - Time.deltaTime * 1000f + (float)skinnedMeshRenderer.GetComponent<UvHuxiEffect>().WaitTime;
		skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(effectTime);
	}
}

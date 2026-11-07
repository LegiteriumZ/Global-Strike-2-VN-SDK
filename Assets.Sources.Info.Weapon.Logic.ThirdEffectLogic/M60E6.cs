using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M60E6 : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect")?.SetInsActive(player.GetCurrentWeaponLevel() >= 300);
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		float effectTime = (float)currentWeaponLevel - Time.deltaTime * 1000f + (float)skinnedMeshRenderer.GetComponent<UvHuxiEffect>().WaitTime;
		skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(effectTime);
	}
}

using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class GhostTwins : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		SetParticleActiveParticleName(player, "juqi", currentWeaponEffectLevel > 0 && currentWeaponEffectLevel < 10);
		SetParticleActiveParticleName(player, "juqi_putong", currentWeaponEffectLevel > 9);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor3"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["rightweaponeffect1"];
		SkinnedMeshRenderer skinnedMeshRenderer4 = skins["rightweaponeffect2"];
		SkinnedMeshRenderer skinnedMeshRenderer5 = skins["weaponfireeffect"];
		SkinnedMeshRenderer skinnedMeshRenderer6 = skins["weaponfireeffect3"];
		skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: true);
		if (((uint)currentWeaponLevel & (true ? 1u : 0u)) != 0)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer5.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer6.gameObject.SetObjectActive(isactive: false);
		}
		else
		{
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer6.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer5.gameObject.SetObjectActive(isactive: false);
		}
		skinnedMeshRenderer4.enabled = (currentWeaponLevel & 2) != 0;
	}
}

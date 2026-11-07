using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Type91Dagger : AbstractThirdWeaponEffectLogic
{
	private const string WEAPON_EFFECT = "daoshen";

	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponeffect"];
		if ((player.GetCurrentWeaponEffectLevel() & 1) > 0)
		{
			skinnedMeshRenderer.enabled = true;
			SetParticleActiveParticleName(player, "daoshen", flag: false);
		}
		else
		{
			skinnedMeshRenderer.enabled = false;
			SetParticleActiveParticleName(player, "daoshen", flag: true);
		}
	}
}

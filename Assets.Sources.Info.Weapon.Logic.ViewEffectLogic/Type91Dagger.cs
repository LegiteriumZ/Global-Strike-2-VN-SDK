using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Type91Dagger : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT = "daoshen";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponeffect"];
		if ((player.GetCurrentWeaponEffectLevel() & 1) > 0)
		{
			bool flag2 = (skinnedMeshRenderer.enabled = (player.viewAnim.Equals(36) && player.viewAnim.RightCurrentTime > 630) || !player.viewAnim.Equals(36));
			SetParticleActiveParticleName(player, "daoshen", !flag2);
		}
		else
		{
			bool flag3 = (player.viewAnim.Equals(37) && player.viewAnim.RightCurrentTime > 900) || !player.viewAnim.Equals(37);
			skinnedMeshRenderer.enabled = !flag3;
			SetParticleActiveParticleName(player, "daoshen", flag3);
		}
	}
}

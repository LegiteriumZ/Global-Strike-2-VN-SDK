using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Ak47Legent : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "clipeffect", player.GetCurrentWeaponEffectLevel() > 0 && !PlayerAnimationUtility.IsViewAnimEqual(player, 17));
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class HandOfZeuss : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT = "shifang";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "shifang", player.viewAnim.Equals(28) && player.viewAnim.RightCurrentTime > 550);
	}
}

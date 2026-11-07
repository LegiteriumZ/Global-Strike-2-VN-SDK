namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class ShieldCannon : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "huandan";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = player.hasViewAnim && player.viewAnim.Equals(17);
		SetParticleActiveParticleName(player, "huandan", flag);
	}
}

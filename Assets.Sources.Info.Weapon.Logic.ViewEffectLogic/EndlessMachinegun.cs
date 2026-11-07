namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class EndlessMachinegun : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "fashe";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "fashe", player.viewAnim.Equals(28) && player.viewAnim.RightCurrentTime > 300);
	}
}

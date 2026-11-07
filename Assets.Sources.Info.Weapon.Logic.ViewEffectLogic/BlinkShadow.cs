namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BlinkShadow : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = player.viewAnim.ViewAnimInfo.StateId == 17;
		SetParticleActiveParticleName(player, "gaoneng", flag);
	}
}

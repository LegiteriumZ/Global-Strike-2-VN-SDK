namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class GlockHellSnake : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect")?.SetInsActive(flag: false);
	}
}

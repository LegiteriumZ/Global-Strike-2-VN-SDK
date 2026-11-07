namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class MP5Ice : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = (player.viewAnim.Equals(40) || player.viewAnim.Equals(41)) && currentWeapon.special.SpecialMode;
		SetParticleActiveParticleName(player, "qiangkouhuohua", flag);
		SetParticleActiveParticleName(player, "qkhh", !currentWeapon.special.SpecialMode);
		GetSkins(player)["weapon_particle_fire_effect1"].enabled = false;
	}
}

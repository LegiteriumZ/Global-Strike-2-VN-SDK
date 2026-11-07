namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class DataCube : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int effectLevel = currentWeapon.special.EffectLevel;
		SetParticleActiveParticleNameGenIndexOfZero(player, "_daka", (effectLevel & 1) > 0);
		SetParticleActiveParticleNameGenIndexOfLessZero(player, "_daka", (effectLevel & 1) == 0);
	}
}

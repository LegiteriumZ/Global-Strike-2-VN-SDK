namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class ElectricLaserSword : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (currentWeapon.special.EffectLevel > 0)
		{
			if (particle == "electric_hong")
			{
				return 1;
			}
		}
		else if (particle == "electric_nan")
		{
			return 1;
		}
		return 0;
	}
}

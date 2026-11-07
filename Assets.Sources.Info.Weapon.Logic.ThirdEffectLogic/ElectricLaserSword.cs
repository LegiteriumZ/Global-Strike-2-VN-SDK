namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class ElectricLaserSword : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (Func == null)
		{
			Func = GetEffect1Flag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		if (player.GetCurrentWeaponEffectLevel() > 0)
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

using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

internal class Ak47UniqueAccuracyLogic : IAccuracyLogic, IParamParse
{
	public readonly PistolAccuracyLogic Special = new PistolAccuracyLogic();

	public readonly NormalAccuracyLogic Normal = new NormalAccuracyLogic();

	public void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		if (currentWeapon.special.SpecialMode)
		{
			Special.BeforeFire(seed, player, currentWeapon, clientTime);
		}
		else
		{
			Normal.BeforeFire(seed, player, currentWeapon, clientTime);
		}
	}

	public void Parse(string param)
	{
		Special.Parse(param);
	}
}

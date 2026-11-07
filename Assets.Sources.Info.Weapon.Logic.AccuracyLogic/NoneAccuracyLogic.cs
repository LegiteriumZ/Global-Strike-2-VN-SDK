using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

public class NoneAccuracyLogic : IAccuracyLogic, IParamParse
{
	public void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
	}

	public void Parse(string param)
	{
	}
}

using System;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

internal class BurstPistolAccuracyLogic : IAccuracyLogic, IParamParse
{
	private readonly PistolAccuracyLogic _normal = new PistolAccuracyLogic();

	private readonly PistolAccuracyLogic _special = new PistolSpecialAccuracyLogic();

	public void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		if (currentWeapon.special.SpecialMode)
		{
			_special.BeforeFire(seed, player, currentWeapon, clientTime);
		}
		else
		{
			_normal.BeforeFire(seed, player, currentWeapon, clientTime);
		}
	}

	public void Parse(string param)
	{
		string[] array = param.Split(',');
		if (array.Length != 6)
		{
			throw new Exception($"param error:{param}");
		}
		_special.Parse($"{array[0]},{array[1]},{array[2]}");
		_normal.Parse($"{array[3]},{array[4]},{array[5]}");
	}
}

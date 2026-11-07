using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

public class DefaultShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _value;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 1);
		_value = restlts[0];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool isMelee)
	{
		float value = _value;
		if (value > 20000f)
		{
			return value * 1.5f;
		}
		return value;
	}
}

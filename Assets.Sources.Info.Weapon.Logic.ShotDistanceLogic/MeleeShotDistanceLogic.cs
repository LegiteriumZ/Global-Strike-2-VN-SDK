using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

internal class MeleeShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _oVaule;

	private float _value;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		_oVaule = restlts[0];
		_value = restlts[1];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool isMelee)
	{
		float num = (isMelee ? _oVaule : _value);
		if (num > 20000f)
		{
			return num * 1.5f;
		}
		return num;
	}
}

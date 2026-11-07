using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

public class PowerButtonShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _oVaule;

	private float _value;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		_value = restlts[1];
		_oVaule = restlts[0];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool isMelee)
	{
		int num = 0;
		if (currentWeapon != null && currentWeapon.hasPower)
		{
			num = currentWeapon.power.Power;
		}
		float num2 = (cmd.IsAttackOn ? (_oVaule + (float)num) : (_value + (float)num));
		if (num2 > 20000f)
		{
			return num2 * 1.5f;
		}
		return num2;
	}
}

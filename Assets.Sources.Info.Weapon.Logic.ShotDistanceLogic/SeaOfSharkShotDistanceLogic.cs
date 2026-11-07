using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

internal class SeaOfSharkShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _dis1;

	private float _dis2;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		_dis1 = restlts[0];
		_dis2 = restlts[1];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool distanceAdded)
	{
		if (cmd.IsAttackOn)
		{
			return _dis1 * (float)currentWeapon.basicInfo.Data.Kill;
		}
		return _dis2 * (float)currentWeapon.basicInfo.Data.Kill;
	}
}

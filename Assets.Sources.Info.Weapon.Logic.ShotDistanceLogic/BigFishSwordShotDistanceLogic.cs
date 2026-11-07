using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

internal class BigFishSwordShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _dis;

	private float _param1;

	private float _param2;

	private float _param3;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 4);
		_dis = restlts[0];
		_param1 = restlts[1];
		_param2 = restlts[2];
		_param3 = restlts[3];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool distanceAdded)
	{
		float num = _dis + (float)currentWeapon.basicInfo.Data.Power2;
		if (currentWeapon.basicInfo.Data.Kill == 1)
		{
			if ((currentWeapon.basicInfo.Data.EffectLevel & 8) > 0)
			{
				if (RuleUtilty.IsBioMode(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
				{
					return num * _param3;
				}
				return num * _param2;
			}
			if ((currentWeapon.basicInfo.Data.EffectLevel & 4) > 0)
			{
				return num * _param1;
			}
		}
		return num;
	}
}

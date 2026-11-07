using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

internal class TrickDaggerShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _oVaule;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 1);
		_oVaule = restlts[0];
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool isMelee)
	{
		float num = _oVaule + (float)getTrickDistance(TrickDaggerPredicationSystem.GetTrickStage(currentWeapon));
		if (num > 20000f)
		{
			return num * 1.5f;
		}
		return num;
	}

	private int getTrickDistance(int getTrickStage)
	{
		switch (getTrickStage)
		{
		case 1:
			return 0;
		case 2:
		case 3:
			return 5;
		case 4:
		case 5:
			return 10;
		default:
			return 0;
		}
	}
}

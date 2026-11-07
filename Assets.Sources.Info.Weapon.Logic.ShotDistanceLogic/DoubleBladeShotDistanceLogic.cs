using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.ShotDistanceLogic;

public class DoubleBladeShotDistanceLogic : IShotDistanceLogic, IParamParse
{
	private float _value;

	public void Parse(string param)
	{
	}

	public float GetShotDistance(IUserCmd cmd, WeaponEntity currentWeapon, bool isMelee)
	{
		_ = cmd.IsAttackOn;
		return currentWeapon.clip.Clip + 140;
	}
}

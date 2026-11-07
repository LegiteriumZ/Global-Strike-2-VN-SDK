using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

public class MechFar2MaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SlowSpeed;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (Mathf.Abs(player.orientation.MoveYaw - player.orientation.Yaw) > 10f)
		{
			return SlowSpeed;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SlowSpeed = restlts[0];
		Speed = restlts[1];
	}
}

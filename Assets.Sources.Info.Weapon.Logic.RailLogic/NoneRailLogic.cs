using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.RailLogic;

internal class NoneRailLogic : IRailLogic, IParamParse
{
	public void Parse(string param)
	{
	}

	public void CreateBulletRailEntity(PlayerEntity player, WeaponEntity currentWeapon, Vector3 start, Vector3 end)
	{
	}
}

using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic;

public interface IRailLogic
{
	void CreateBulletRailEntity(PlayerEntity player, WeaponEntity currentWeapon, Vector3 start, Vector3 end);
}

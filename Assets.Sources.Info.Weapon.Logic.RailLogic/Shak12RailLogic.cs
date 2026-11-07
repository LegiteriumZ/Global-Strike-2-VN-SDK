using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Utils.Weapon;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.RailLogic;

internal class Shak12RailLogic : IRailLogic, IParamParse
{
	private int _res;

	public void Parse(string param)
	{
		_res = int.Parse(param);
	}

	private bool HasBulletRail(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.fov.IsZoom())
		{
			return false;
		}
		if (currentWeapon.basicInfo.Info.WeaponType == 6)
		{
			return false;
		}
		if (WeaponUtility.HasLeftAnim(currentWeapon.basicInfo.Info))
		{
			return false;
		}
		return true;
	}

	public void CreateBulletRailEntity(PlayerEntity player, WeaponEntity currentWeapon, Vector3 start, Vector3 end)
	{
		if (currentWeapon.attack.ShotsFired > 3)
		{
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res);
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res, 0, isForceLeftParticleRail: true);
		}
		else if (currentWeapon.basicInfo.Data.Kill == 0)
		{
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res);
		}
		else
		{
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res, 0, isForceLeftParticleRail: true);
		}
	}
}

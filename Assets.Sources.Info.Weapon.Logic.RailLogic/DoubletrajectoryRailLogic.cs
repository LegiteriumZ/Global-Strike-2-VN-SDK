using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Utils.Weapon;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.RailLogic;

public class DoubletrajectoryRailLogic : IRailLogic, IParamParse
{
	private int _res;

	private bool isLeft = true;

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
		if (!HasBulletRail(player, currentWeapon))
		{
			return;
		}
		if (player.viewAnim.ViewAnimInfo.StateId == 15)
		{
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res, 0, isForceLeftParticleRail: true);
		}
		else if (player.viewAnim.ViewAnimInfo.StateId == 47 || player.viewAnim.ViewAnimInfo.StateId == 199)
		{
			if (isLeft)
			{
				isLeft = false;
				SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res, 0, isForceLeftParticleRail: true);
			}
			else
			{
				isLeft = true;
				SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res);
			}
		}
		else
		{
			SceneObjectFactory.Instance.CreateBulletRailEntity(player.entityId.Value, start, end, _res);
		}
	}

	public void Parse(string param)
	{
		_res = int.Parse(param);
	}
}

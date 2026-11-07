using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Utils.Weapon;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.RailLogic;

internal class CrystalBowRailLogic : IRailLogic, IParamParse
{
	private int _normalRes;

	private int _specialRes;

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		_normalRes = restlts[0];
		_specialRes = restlts[1];
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
		if (HasBulletRail(player, currentWeapon) && currentWeapon != null && currentWeapon.hasBasicInfo)
		{
			int resId = ((currentWeapon.basicInfo.Data.WeaponSkinName != "") ? _specialRes : _normalRes);
			SceneObjectFactory.Instance.CreateBowRailEntity(player.entityId.Value, start, end, resId, 22);
		}
	}
}

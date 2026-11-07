using Assets.Sources.Modules.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.RailLogic;

internal class BowSpecialRailLogic : IRailLogic, IParamParse
{
	private int _normalRes;

	private int _specialRes;

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		_normalRes = restlts[0];
		_specialRes = restlts[1];
	}

	public void CreateBulletRailEntity(PlayerEntity player, WeaponEntity currentWeapon, Vector3 start, Vector3 end)
	{
		if (currentWeapon.hasSpecial)
		{
			int resId = (currentWeapon.special.SpecialMode ? _specialRes : _normalRes);
			SceneObjectFactory.Instance.CreateBowRailEntity(player.entityId.Value, start, end, resId, 22);
		}
	}
}

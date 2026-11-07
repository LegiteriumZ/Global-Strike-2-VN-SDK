using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Mp5Predator : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["rightweaponeffect1"].gameObject.SetObjectActive(isactive: true);
		skins["rightweaponeffect2"].gameObject.SetObjectActive(isactive: true);
	}
}

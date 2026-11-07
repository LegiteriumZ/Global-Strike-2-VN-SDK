using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Mp5Predator : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["rightweaponeffect1"].gameObject.SetObjectActive(isactive: true);
		skins["rightweaponeffect2"].gameObject.SetObjectActive(isactive: true);
	}
}

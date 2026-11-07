using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BigFishSword : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (currentWeapon.hasSpecial)
		{
			SetSkinVisible(skins, "weaponeffect", (currentWeapon.special.EffectLevel & 0x20) > 0);
			SetSkinVisible(skins, "weaponeffect2", (currentWeapon.special.EffectLevel & 0x20) > 0);
		}
	}
}

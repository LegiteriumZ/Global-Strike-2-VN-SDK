using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class GrenadeLockUniverse : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool enabled = (player.GetCurrentWeaponEffectLevel() & 4) > 0;
		skins["weaponeffect21"].enabled = enabled;
	}
}

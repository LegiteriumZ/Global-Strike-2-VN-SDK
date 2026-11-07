using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class SpiritsSword : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponanchor"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) <= 0;
		skins["weaponanchor3"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) > 0;
	}
}

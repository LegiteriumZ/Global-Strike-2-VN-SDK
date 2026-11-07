using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class SnakeChainSword : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponanchor"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) == 0;
		skins["weaponanchor3"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
	}
}

using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Tanghulu : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponanchor"].gameObject.SetObjectActive((player.GetCurrentWeaponSubType() & 2) == 0);
		skins["weaponanchor3"].gameObject.SetObjectActive((player.GetCurrentWeaponSubType() & 2) != 0);
	}
}

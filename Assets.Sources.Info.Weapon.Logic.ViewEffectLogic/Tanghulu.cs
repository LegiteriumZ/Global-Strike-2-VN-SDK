using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Tanghulu : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponanchor"].gameObject.SetObjectActive((player.GetCurrentWeaponSubType() & 2) == 0);
		skins["weaponanchor3"].gameObject.SetObjectActive((player.GetCurrentWeaponSubType() & 2) != 0);
	}
}

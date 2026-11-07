using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BabyBoxer : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
			SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor3"];
			if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo.StateId == 15)
			{
				skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
				skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			}
			else
			{
				skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
				skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			}
		}
	}
}

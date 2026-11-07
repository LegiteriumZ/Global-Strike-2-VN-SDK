using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Bow : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = player.firstPersonUnityObjects.Skins;
		SkinnedMeshRenderer skinnedMeshRenderer = skins["bingdongjian"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["chuantoujian"];
		if (currentWeapon.clip.Clip > 0)
		{
			if (currentWeapon.special.SpecialMode)
			{
				skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
				skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
			}
			else
			{
				skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
				skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
			}
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
		}
	}
}

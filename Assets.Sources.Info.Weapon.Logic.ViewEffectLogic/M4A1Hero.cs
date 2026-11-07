using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class M4A1Hero : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["m4a1_hero_jiguangjian"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["m4a1_hero_jiguangjian_viewshow"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["m4a1_hero_jiguang"];
		SkinnedMeshRenderer skinnedMeshRenderer4 = skins["m4a1_hero_effect1"];
		SkinnedMeshRenderer skinnedMeshRenderer5 = skins["m4a1_hero_effect2"];
		SkinnedMeshRenderer skinnedMeshRenderer6 = skins["m4a1_hero_effect3"];
		if (skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(player.viewAnim.ViewAnimInfo.StateId == 20);
		}
		if (skinnedMeshRenderer2 != null)
		{
			skinnedMeshRenderer2.gameObject.SetObjectActive(player.viewAnim.ViewAnimInfo.StateId == 44);
		}
		if (skinnedMeshRenderer3 != null)
		{
			skinnedMeshRenderer3.gameObject.SetObjectActive(player.viewAnim.ViewAnimInfo.StateId == 28);
		}
		if (skinnedMeshRenderer4 != null)
		{
			skinnedMeshRenderer4.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() == 0);
		}
		if (skinnedMeshRenderer5 != null)
		{
			skinnedMeshRenderer5.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() == 1);
		}
		if (skinnedMeshRenderer6 != null)
		{
			skinnedMeshRenderer6.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() >= 2);
		}
	}
}

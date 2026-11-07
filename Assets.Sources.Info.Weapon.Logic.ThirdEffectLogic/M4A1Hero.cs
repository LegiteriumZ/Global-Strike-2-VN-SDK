using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M4A1Hero : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["m4a1_hero_jiguangjian"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["m4a1_hero_jiguang"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["m4a1_hero_effect1"];
		SkinnedMeshRenderer skinnedMeshRenderer4 = skins["m4a1_hero_effect2"];
		SkinnedMeshRenderer skinnedMeshRenderer5 = skins["m4a1_hero_effect3"];
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null && skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(player.torseAnim.TorsoAnimInfo.StateId == 20);
		}
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null && skinnedMeshRenderer2 != null)
		{
			skinnedMeshRenderer2.gameObject.SetObjectActive(player.torseAnim.TorsoAnimInfo.StateId == 28);
		}
		if (skinnedMeshRenderer3 != null)
		{
			skinnedMeshRenderer3.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() == 0);
		}
		if (skinnedMeshRenderer4 != null)
		{
			skinnedMeshRenderer4.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() == 1);
		}
		if (skinnedMeshRenderer5 != null)
		{
			skinnedMeshRenderer5.gameObject.SetObjectActive(player.GetCurrentWeaponLevel() >= 2);
		}
	}
}

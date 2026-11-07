using System.Collections.Generic;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Ak47Symphony : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponeffect21"];
			if (!(skinnedMeshRenderer == null) && player.hasEventParticle && player.eventParticle.EventParticles != null)
			{
				skinnedMeshRenderer.enabled = ((!player.eventParticle.EventParticles.ContainsKey(100042) && !player.eventParticle.EventParticles.ContainsKey(100043) && !player.eventParticle.EventParticles.ContainsKey(100044) && !player.eventParticle.EventParticles.ContainsKey(100045) && (player.GetCurrentWeaponEffectLevel() & 0x20) > 0) ? true : false);
			}
		}
	}
}

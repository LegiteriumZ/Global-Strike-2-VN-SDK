using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ThunderScepter : AbstractViewWeaponEffectLogic
{
	private const string WeaponEffect1 = "qiangkouhuohua";

	private const string WeaponEffect2 = "qkhh";

	private const string WeaponEffect3 = "chongneng";

	private const string WeaponEffect4 = "qiangshen_jin";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = (player.GetCurrentWeaponEffectLevel() & 1) > 0;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponanchor3", !flag);
		SetSkinSelfVisible(player, "weaponanchor3", !flag);
		if (string.IsNullOrEmpty(player.currentWeapon.SkinName) && !flag)
		{
			bool flag2 = player.hasViewAnim && player.viewAnim.ViewAnimInfo != null && player.viewAnim.ViewAnimInfo.StateId == 17;
			SetParticleActiveParticleName(player, "chongneng", flag2);
			SetParticleActiveParticleName(player, "qiangshen_jin", flag: true);
			bool flag3 = RuleUtilty.IsPve(raceType) || RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsBigHeadModel(raceType);
			SetParticleActiveParticleName(player, "qkhh", flag3);
			SetParticleActiveParticleName(player, "qiangkouhuohua", !flag3);
		}
	}

	protected void SetSkinSelfVisible(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			GameObject gameObject = particle.Value.getGameObject().transform.parent.gameObject;
			if (gameObject.name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				gameObject.SetObjectActive(flag);
			}
		}
	}
}

using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class MirageDouBlade : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT1 = "qiangshen_jujian";

	private const string WEAPON_EFFECT2 = "qiangshen_shuang";

	private const string WEAPON_EFFECT3 = "zhenhong_qiangshen_jujian";

	private const string WEAPON_EFFECT4 = "zhenhong_qiangshen_shuang";

	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["weaponanchor3"];
		if (player != null && player.hasBasicInfo && (player.GetCurrentWeaponEffectLevel() & 0x20) > 0)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: false);
		}
		SetParticleActiveParticleName(player, "qiangshen_jujian", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0);
		SetParticleActiveParticleName(player, "zhenhong_qiangshen_jujian", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0);
		SetParticleActiveParticleName(player, "qiangshen_shuang", (player.GetCurrentWeaponEffectLevel() & 0x20) == 0);
		SetParticleActiveParticleName(player, "zhenhong_qiangshen_shuang", (player.GetCurrentWeaponEffectLevel() & 0x20) == 0);
	}
}

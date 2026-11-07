using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Pickaxe : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT1 = "qiangshentexiao_putong";

	private const string WEAPON_EFFECT2 = "qiangshentexiao_gaoneng";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "qiangshentexiao_putong", (player.GetCurrentWeaponEffectLevel() & 0x10) == 0);
		SetParticleActiveParticleName(player, "qiangshentexiao_gaoneng", (player.GetCurrentWeaponEffectLevel() & 0x10) > 0);
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			skinnedMeshRenderer.material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[((player.GetCurrentWeaponEffectLevel() & 0x10) > 0) ? 1u : 0u];
		}
	}
}

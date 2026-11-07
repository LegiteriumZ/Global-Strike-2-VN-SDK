using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class M249Rocket : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 1) ? 1u : 0u];
		}
		skinnedMeshRenderer.gameObject.SetObjectActive(level < 3);
		skinnedMeshRenderer = skins["uv2_liuguang_gaoguang"];
		if (_textureList != null)
		{
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 1) ? 1u : 0u];
		}
		skinnedMeshRenderer.gameObject.SetObjectActive(level >= 3);
	}
}

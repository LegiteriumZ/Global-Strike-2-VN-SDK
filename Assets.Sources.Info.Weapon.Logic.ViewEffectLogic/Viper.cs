using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Viper : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		int level = currentWeapon.special.Level;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (_textureList != null)
		{
			Texture2D[] weaponTextures = _textureList.GetWeaponTextures(skinInfo);
			if (weaponTextures != null && weaponTextures.Length > 1)
			{
				skins["weaponanchor"].material.mainTexture = weaponTextures[(level >= 2) ? 1u : 0u];
				skins["weaponanchor2"].material.mainTexture = weaponTextures[(level >= 2) ? 1u : 0u];
			}
		}
		GroupModelTextureSheetAnimation[] componentsInChildren = player.firstPersonUnityObjects.WeaponGameObject.GetComponentsInChildren<GroupModelTextureSheetAnimation>();
		if (componentsInChildren != null)
		{
			GroupModelTextureSheetAnimation[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Group = ((currentWeapon.special.Level > 3) ? 3 : currentWeapon.special.Level);
			}
		}
	}
}

using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Viper : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, int raceType)
	{
		if (_textureList == null)
		{
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
		}
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (_textureList != null && _textureList.GetWeaponTextures(skinInfo).Length >= 2)
		{
			skins["weaponanchor"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 2) ? 1u : 0u];
			skins["weaponanchor2"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 2) ? 1u : 0u];
		}
		GroupModelTextureSheetAnimation[] componentsInChildren = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentsInChildren<GroupModelTextureSheetAnimation>();
		if (componentsInChildren != null)
		{
			GroupModelTextureSheetAnimation[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Group = ((player.GetCurrentWeaponLevel() > 3) ? 3 : player.GetCurrentWeaponLevel());
			}
		}
	}
}

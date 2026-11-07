using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M249Rocket : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (_textureList == null)
		{
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
		}
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		if (_textureList != null)
		{
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 1) ? 1u : 0u];
		}
		skinnedMeshRenderer.gameObject.SetObjectActive(currentWeaponLevel < 3);
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["uv2_liuguang_gaoguang"];
		if (_textureList != null)
		{
			skinnedMeshRenderer2.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 1) ? 1u : 0u];
		}
		skinnedMeshRenderer2.gameObject.SetObjectActive(currentWeaponLevel >= 3);
	}
}

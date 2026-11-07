using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class HorrorClaw : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		if (_textureList != null)
		{
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 1) ? 1u : 0u];
		}
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
		if (_textureList != null)
		{
			skinnedMeshRenderer2.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 1) ? 1u : 0u];
		}
		foreach (IPaticlePrefabInstancecs value in GetParticles(player).Values)
		{
			value.SetInsActive(level == 3);
		}
	}
}

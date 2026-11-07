using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class HorrorClaw : AbstractThirdWeaponEffectLogic
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
			skinnedMeshRenderer.material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 1) ? 1u : 0u];
		}
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
		if (_textureList != null)
		{
			skinnedMeshRenderer2.material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 1) ? 1u : 0u];
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			particle.Value.SetInsActive(currentWeaponLevel == 3);
		}
	}
}

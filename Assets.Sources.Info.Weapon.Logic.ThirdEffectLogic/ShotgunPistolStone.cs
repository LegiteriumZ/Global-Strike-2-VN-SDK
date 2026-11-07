using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ShotgunPistolStone : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, int raceType)
	{
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
			SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			if (_textureList != null)
			{
				skinnedMeshRenderer.material.mainTexture = _textureList.GetWeaponEffectTextures()[(((uint)player.GetCurrentWeaponEffectLevel() & 0x40u) != 0) ? 1 : 0];
				skinnedMeshRenderer2.material.mainTexture = _textureList.GetWeaponEffectTextures()[((player.GetCurrentWeaponEffectLevel() & 0x40) == 0) ? 2 : 3];
			}
		}
	}
}

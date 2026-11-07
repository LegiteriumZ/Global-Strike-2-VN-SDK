using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class TiggerFist : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, int raceType)
	{
		if (_textureList == null)
		{
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
		}
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (_textureList != null)
		{
			skins["weaponanchor"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(((uint)player.GetCurrentWeaponSubType() & 2u) != 0) ? 1 : 0];
			skins["weaponanchor2"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(((uint)player.GetCurrentWeaponSubType() & 2u) != 0) ? 1 : 0];
		}
	}
}

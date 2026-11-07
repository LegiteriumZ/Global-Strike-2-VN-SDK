using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class TiggerFist : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
			Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
			skins["weaponanchor"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(((uint)player.GetCurrentWeaponSubType() & 2u) != 0) ? 1 : 0];
			skins["weaponanchor2"].material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(((uint)player.GetCurrentWeaponSubType() & 2u) != 0) ? 1 : 0];
		}
	}
}

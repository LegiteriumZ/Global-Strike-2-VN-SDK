using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Shotgun3Barrel : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private UvLiuGuangEffect _effect;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (!currentWeapon.hasSpecial)
		{
			return;
		}
		int level = currentWeapon.special.Level;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = player.firstPersonUnityObjects.Skins;
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (skins.TryGetValue("weaponanchor", out var value))
		{
			if (_textureList == null)
			{
				_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
			}
			if (_textureList != null)
			{
				Texture mainTexture = ((level >= 2) ? _textureList.GetWeaponTextures(skinInfo)[2] : ((level < 1) ? _textureList.GetWeaponTextures(skinInfo)[0] : _textureList.GetWeaponTextures(skinInfo)[1]));
				value.sharedMaterial.mainTexture = mainTexture;
			}
			if (_effect == null)
			{
				_effect = value.GetComponent<UvLiuGuangEffect>();
			}
			if (_effect != null)
			{
				_effect.enabled = level >= 3;
			}
		}
	}
}

using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Shotgun3Barrel : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private UvLiuGuangEffect _effect;

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		if (GetSkins(player).TryGetValue("weaponanchor", out var value))
		{
			if (_textureList == null)
			{
				_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			}
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
			if (_textureList != null)
			{
				Texture mainTexture = ((currentWeaponLevel >= 2) ? _textureList.GetWeaponTextures(skinInfo)[2] : ((currentWeaponLevel < 1) ? _textureList.GetWeaponTextures(skinInfo)[0] : _textureList.GetWeaponTextures(skinInfo)[1]));
				value.sharedMaterial.mainTexture = mainTexture;
			}
			if (_effect == null)
			{
				_effect = value.GetComponent<UvLiuGuangEffect>();
			}
			if (_effect != null)
			{
				_effect.enabled = currentWeaponLevel >= 3;
			}
		}
	}
}

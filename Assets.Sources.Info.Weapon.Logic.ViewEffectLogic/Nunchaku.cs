using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Nunchaku : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private UvHuxiEffect _effect;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (_textureList == null)
		{
			_textureList = player.firstPersonUnityObjects.WeaponGameObject.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 1) ? 1u : 0u];
		}
		if (_effect == null)
		{
			_effect = skinnedMeshRenderer.GetComponent<UvHuxiEffect>();
		}
		if (_effect != null)
		{
			_effect.enabled = level >= 2;
		}
	}
}

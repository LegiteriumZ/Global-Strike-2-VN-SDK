using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Nunchaku : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private UvHuxiEffect _uvHuxi;

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (_textureList == null)
		{
			_textureList = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
		}
		if (_textureList != null)
		{
			skinnedMeshRenderer.material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 1) ? 1u : 0u];
		}
		if (_uvHuxi == null)
		{
			_uvHuxi = skinnedMeshRenderer.GetComponent<UvHuxiEffect>();
		}
		if (_uvHuxi != null)
		{
			_uvHuxi.enabled = currentWeaponLevel >= 2;
		}
	}
}

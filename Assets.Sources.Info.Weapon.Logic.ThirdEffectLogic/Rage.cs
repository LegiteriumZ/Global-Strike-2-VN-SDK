using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Player.UnityObjects;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Rage : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

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
			skinnedMeshRenderer.material.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(currentWeaponLevel >= 2) ? 1u : 0u];
		}
		if (!player.hasThirdPersonUnityObjects)
		{
			return;
		}
		ThirdPersonUnityObjectsComponent.GameEffectCache cache = player.thirdPersonUnityObjects.Cache;
		if (cache.GroupTSA != null && cache.GroupTSA.Length != 0)
		{
			IGroupModelTextureSheetAnimation[] groupTSA = cache.GroupTSA;
			for (int i = 0; i < groupTSA.Length; i++)
			{
				groupTSA[i].setGroup(currentWeaponLevel);
			}
		}
	}
}

using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Player.UnityObjects;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Rage : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

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
			skinnedMeshRenderer.sharedMaterial.mainTexture = _textureList.GetWeaponTextures(skinInfo)[(level >= 2) ? 1u : 0u];
		}
		if (!player.hasFirstPersonUnityObjects)
		{
			return;
		}
		FirstPersonUnityObjectsComponent.GameEffectCache cache = player.firstPersonUnityObjects.Cache;
		if (cache.GroupTSA != null && cache.GroupTSA.Length != 0)
		{
			IGroupModelTextureSheetAnimation[] groupTSA = cache.GroupTSA;
			for (int i = 0; i < groupTSA.Length; i++)
			{
				groupTSA[i].setGroup(level);
			}
		}
	}
}

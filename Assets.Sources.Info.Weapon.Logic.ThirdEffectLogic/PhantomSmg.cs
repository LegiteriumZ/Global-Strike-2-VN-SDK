using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.Manager;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class PhantomSmg : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if ((currentWeaponEffectLevel & 0x10) > 0)
		{
			SetSkinVisible(skins, "weaponanchor", flag: true);
			SetSkinVisible(skins, "weaponanchor2", flag: true);
			SetSkinVisible(skins, "weaponanchor3", flag: false);
			return;
		}
		SetSkinVisible(skins, "weaponanchor", flag: false);
		SetSkinVisible(skins, "weaponanchor2", flag: false);
		SetSkinVisible(skins, "weaponanchor3", flag: true);
		BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName);
		if (skins.ContainsKey("weaponanchor3"))
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor3"];
			TextureList component = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponent<TextureList>();
			if (component != null)
			{
				int num = (((currentWeaponEffectLevel & 0x20) > 0) ? 1 : 0);
				skinnedMeshRenderer.material.mainTexture = component.Textures[num];
			}
		}
	}
}

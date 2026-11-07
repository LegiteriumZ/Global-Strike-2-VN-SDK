using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Player.UnityObjects;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Mp5Wr : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "rightweaponeffect2", currentWeaponLevel >= 2);
		SetSkinVisible(skins, "rightweaponeffect1", currentWeaponLevel >= 3);
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

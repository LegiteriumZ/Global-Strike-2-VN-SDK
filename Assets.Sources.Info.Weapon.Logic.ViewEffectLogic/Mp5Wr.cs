using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Player.UnityObjects;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Mp5Wr : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "rightweaponeffect2", level >= 2);
		SetSkinVisible(skins, "rightweaponeffect1", level >= 3);
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

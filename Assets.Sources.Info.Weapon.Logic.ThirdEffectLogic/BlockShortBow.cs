using System.Collections.Generic;
using Assets.Sources.Utils.Player;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BlockShortBow : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["putong"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["mangong"];
		if (((uint)PlayerUtility.GetBowWeaponState(player) & 2u) != 0)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
		}
	}
}

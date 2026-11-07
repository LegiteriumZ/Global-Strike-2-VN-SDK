using System.Collections.Generic;
using Assets.Sources.Utils.Player;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Bow : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["bingdongjian"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["chuantoujian"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["putong"];
		SkinnedMeshRenderer skinnedMeshRenderer4 = skins["mangong"];
		int bowWeaponState = PlayerUtility.GetBowWeaponState(player);
		if (((uint)bowWeaponState & (true ? 1u : 0u)) != 0)
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
		}
		if (((uint)bowWeaponState & 2u) != 0)
		{
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer4.gameObject.SetObjectActive(isactive: false);
		}
		else
		{
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer4.gameObject.SetObjectActive(isactive: true);
		}
	}
}

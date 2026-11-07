using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DoubleScythe : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["weaponanchor3"];
		SkinnedMeshRenderer skinnedMeshRenderer4 = skins["weaponeffect"];
		SkinnedMeshRenderer skinnedMeshRenderer5 = skins["weaponeffect2"];
		SkinnedMeshRenderer skinnedMeshRenderer6 = skins["weaponeffect3"];
		if (IsSpecial(player))
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer4.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer5.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer6.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer4.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer5.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer6.gameObject.SetObjectActive(isactive: false);
		}
		GroupModelTextureSheetAnimation[] componentsInChildren = player.thirdPersonUnityObjects.ThirdTran.WeaponObj.GetComponentsInChildren<GroupModelTextureSheetAnimation>();
		if (componentsInChildren != null)
		{
			GroupModelTextureSheetAnimation[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Group = ((player.GetCurrentWeaponLevel() > 3) ? 3 : player.GetCurrentWeaponLevel());
			}
		}
	}

	protected bool IsSpecial(PlayerEntity player)
	{
		if (player != null && player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			if (!player.torseAnim.TorsoAnimInfo.StateId.Equals(40))
			{
				return player.torseAnim.TorsoAnimInfo.StateId.Equals(39);
			}
			return true;
		}
		return false;
	}
}

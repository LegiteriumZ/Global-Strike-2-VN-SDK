using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class M60RoadMaster : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (level >= 100)
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime((level - 100) * 10);
		}
		else
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(0f);
		}
	}
}

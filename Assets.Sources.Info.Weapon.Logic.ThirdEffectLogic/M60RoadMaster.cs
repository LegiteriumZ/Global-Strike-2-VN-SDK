using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M60RoadMaster : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (currentWeaponLevel >= 100)
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime((currentWeaponLevel - 100) * 10);
		}
		else
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(0f);
		}
	}
}

using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class MiniDeath : AbstractViewWeaponEffectLogic
{
	private const string ZDSSQSTX_EFFECT = "zdssqstx";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "zdssqstx", currentWeapon.special.EffectLevel >= 1000);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (currentWeapon.basicInfo.Data.Level >= 100)
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(currentWeapon.basicInfo.Data.Level);
		}
		else
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(0f);
		}
	}
}

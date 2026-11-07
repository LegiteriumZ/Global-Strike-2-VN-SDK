using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class MiniDeath : AbstractThirdWeaponEffectLogic
{
	private const string ZDSSQSTX_EFFECT = "zdssqstx";

	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "zdssqstx", player.GetCurrentWeaponEffectLevel() >= 1000);
		SkinnedMeshRenderer skinnedMeshRenderer = GetSkins(player)["weaponanchor"];
		if (player.currentWeapon.Level >= 100)
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(player.currentWeapon.Level);
		}
		else
		{
			skinnedMeshRenderer.GetComponent<UvHuxiEffect>().SetEffectTime(0f);
		}
	}
}

using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class M9Devil : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		IPaticlePrefabInstancecs paticleByParticleName = GetPaticleByParticleName(player, "11000_fx_1_atf");
		SetParticleViaAnim(player, paticleByParticleName, 20, 858);
		paticleByParticleName = GetPaticleByParticleName(player, "11000_daoguang01");
		SetParticleViaAnim(player, paticleByParticleName, 31, 132);
		paticleByParticleName = GetPaticleByParticleName(player, "11000_daoguang02");
		SetParticleViaAnim(player, paticleByParticleName, 29, 400);
	}

	private void SetParticleViaAnim(PlayerEntity player, IPaticlePrefabInstancecs particle, int animId, int remainTime)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, animId) || player.GetCurrentWeaponEffectLevel() != 1)
		{
			particle.SetInsActive(flag: false);
		}
		else if (player.viewAnim.RemainTime > remainTime && player.viewAnim.RemainTime < remainTime + 100 && !particle.GetIns().IsActiveSelf())
		{
			particle.SetInsActive(flag: true);
			particle.Restart();
		}
	}
}

using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Riotshield : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		IPaticlePrefabInstancecs paticleByParticleName = GetPaticleByParticleName(player, "11090_dun_liuguang");
		if (currentWeapon.special.EffectLevel == 1)
		{
			paticleByParticleName.SetInsActive(flag: true);
			paticleByParticleName.Restart();
		}
	}
}

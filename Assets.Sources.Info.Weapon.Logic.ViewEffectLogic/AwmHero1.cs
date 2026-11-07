using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class AwmHero1 : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		IPaticlePrefabInstancecs paticleByParticleName = GetPaticleByParticleName(player, "fireeffect");
		if (paticleByParticleName != null && currentWeapon != null && currentWeapon.hasSpecial)
		{
			paticleByParticleName.SetInsActive(currentWeapon.special.SpecialMode);
		}
	}
}

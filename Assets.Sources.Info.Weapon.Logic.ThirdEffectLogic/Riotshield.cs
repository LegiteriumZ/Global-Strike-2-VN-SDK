using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Riotshield : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		IPaticlePrefabInstancecs paticleByParticleName = GetPaticleByParticleName(player, "11090_dun_liuguang");
		if (player.GetCurrentWeaponEffectLevel() == 1)
		{
			paticleByParticleName.SetInsActive(flag: true);
			paticleByParticleName.Restart();
		}
	}
}

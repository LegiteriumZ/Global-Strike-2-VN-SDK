using Assets.Res.Assets.Scripts.PrefabInstance;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class FanaticalTempoFmg : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		PaticlePrefabInstancecs paticlePrefabInstancecs = GetPaticleByParticleName(player, "qangshen") as PaticlePrefabInstancecs;
		if ((player.GetCurrentWeaponEffectLevel() & 1) > 0)
		{
			if (!paticlePrefabInstancecs.enabled)
			{
				paticlePrefabInstancecs.SetInsActive(flag: true);
				paticlePrefabInstancecs.Restart();
			}
		}
		else
		{
			paticlePrefabInstancecs.SetInsActive(flag: false);
		}
	}
}

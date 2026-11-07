using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class WolfClaw : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		foreach (IPaticlePrefabInstancecs value in GetParticles(player).Values)
		{
			value.SetInsActive(player.GetCurrentWeaponEffectLevel() > 0);
		}
	}
}

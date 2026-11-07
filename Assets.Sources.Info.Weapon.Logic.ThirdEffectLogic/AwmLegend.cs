namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class AwmLegend : AbstractThirdWeaponEffectLogic
{
	private bool IsKnifeAttack(PlayerEntity player)
	{
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			return player.torseAnim.TorsoAnimInfo.StateId == 150;
		}
		return false;
	}

	private bool IsShowFireEffect(PlayerEntity player)
	{
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			return player.torseAnim.TorsoAnimInfo.StateId == 150;
		}
		return false;
	}

	public override void Update(PlayerEntity player, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect1")?.SetInsActive(IsKnifeAttack(player));
		GetPaticleBySkinName(player, "weapon_particle_fire_effect")?.SetInsActive(IsShowFireEffect(player));
	}
}

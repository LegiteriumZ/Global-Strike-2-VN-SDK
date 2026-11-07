using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class AwmLegend : AbstractViewWeaponEffectLogic
{
	private bool IsKnifeAttack(PlayerEntity player)
	{
		if (player.viewAnim.ViewAnimInfo.StateId != 31 && player.viewAnim.ViewAnimInfo.StateId != 170 && player.viewAnim.ViewAnimInfo.StateId != 172 && player.viewAnim.ViewAnimInfo.StateId != 174 && player.viewAnim.ViewAnimInfo.StateId != 176 && player.viewAnim.ViewAnimInfo.StateId != 169 && player.viewAnim.ViewAnimInfo.StateId != 171 && player.viewAnim.ViewAnimInfo.StateId != 173)
		{
			return player.viewAnim.ViewAnimInfo.StateId == 175;
		}
		return true;
	}

	private bool IsShowFireEffect(PlayerEntity playerEntity)
	{
		if (playerEntity.viewAnim.ViewAnimInfo.StateId == 150)
		{
			return playerEntity.viewAnim.RightCurrentTime < 300;
		}
		return false;
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect1")?.SetInsActive(IsKnifeAttack(player));
		if (IsShowFireEffect(player))
		{
			WeaponUtility.Fire(player.firstPersonUnityObjects.RightFires, currentWeapon.special.SpecialMode);
		}
	}
}

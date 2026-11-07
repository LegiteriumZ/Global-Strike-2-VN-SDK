namespace Assets.Sources.Info.Weapon.Logic;

public interface IKickbackLogic
{
	void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness);
}

using SSJJUserCmd;

namespace Assets.Sources.Utils.Weapon;

public struct CommonWeaponArg
{
	public PlayerEntity Player;

	public IUserCmd Cmd;

	public WeaponEntity CurrentWeapon;

	public Contexts Contexts;

	public int ClientTime;

	public string FireParentTranName;

	public string FireTranName;
}

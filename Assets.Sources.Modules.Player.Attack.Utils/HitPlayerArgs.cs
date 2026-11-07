using SSJJUserCmd;
using share;

namespace Assets.Sources.Modules.Player.Attack.Utils;

public struct HitPlayerArgs
{
	public PlayerEntity player;

	public WeaponEntity currentWeapon;

	public Contexts contexts;

	public Vector3D startPos;

	public Vector3D endPos;

	public Vector3D normal;

	public PlayerEntity beHitPlayer;

	public int hitGroup;

	public IUserCmd cmd;
}

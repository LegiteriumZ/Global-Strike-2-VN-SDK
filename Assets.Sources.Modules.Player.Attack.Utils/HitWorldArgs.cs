using share;

namespace Assets.Sources.Modules.Player.Attack.Utils;

public struct HitWorldArgs
{
	public PlayerEntity player;

	public WeaponEntity currentWeapon;

	public Contexts contexts;

	public Vector3D startPos;

	public Vector3D endPos;

	public Vector3D normal;

	public int surfaceFlags;

	public int resultId;
}

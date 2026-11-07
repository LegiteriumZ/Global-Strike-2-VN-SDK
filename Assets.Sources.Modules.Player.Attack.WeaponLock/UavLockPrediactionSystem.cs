using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class UavLockPrediactionSystem : AbstractLockPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public UavLockPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		bool weaponLock = false;
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			weaponLock = currentWeaponEntity.special.Level != 0;
		}
		player.SetWeaponLock(weaponLock);
		player.SetWeaponCanDuck(b: true);
	}
}

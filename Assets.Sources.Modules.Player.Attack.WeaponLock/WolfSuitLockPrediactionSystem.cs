using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class WolfSuitLockPrediactionSystem : AbstractLockPrediactionSystem
{
	public WolfSuitLockPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponLock(b: true);
		player.SetWeaponCanDuck(b: true);
	}
}

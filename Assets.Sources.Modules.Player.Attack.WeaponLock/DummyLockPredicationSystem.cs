using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class DummyLockPredicationSystem : AbstractLockPrediactionSystem
{
	public DummyLockPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponLock(b: false);
		player.SetWeaponCanDuck(b: false);
	}
}

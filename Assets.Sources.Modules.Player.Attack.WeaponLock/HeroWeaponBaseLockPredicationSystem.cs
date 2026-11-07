using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class HeroWeaponBaseLockPredicationSystem : AbstractLockPrediactionSystem
{
	public HeroWeaponBaseLockPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponCanDuck(b: false);
	}
}

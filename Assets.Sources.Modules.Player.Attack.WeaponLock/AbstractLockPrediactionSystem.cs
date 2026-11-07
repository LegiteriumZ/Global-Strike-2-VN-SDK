using Assets.Sources.Framework;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class AbstractLockPrediactionSystem : IPredicateSystem
{
	public AbstractLockPrediactionSystem(Contexts contexts)
	{
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		SetLockAndDuck(player, cmd);
	}

	protected virtual void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponLock(b: false);
		player.SetWeaponCanDuck(b: true);
	}
}

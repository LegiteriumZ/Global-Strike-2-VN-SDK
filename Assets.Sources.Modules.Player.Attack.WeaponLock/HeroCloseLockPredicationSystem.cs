using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class HeroCloseLockPredicationSystem : AbstractLockPrediactionSystem
{
	public HeroCloseLockPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		if (player.torseAnim.TorsoAnimInfo.StateId == 122 || player.torseAnim.TorsoAnimInfo.StateId == 124 || player.torseAnim.TorsoAnimInfo.StateId == 126 || player.torseAnim.TorsoAnimInfo.StateId == 123 || player.torseAnim.TorsoAnimInfo.StateId == 125)
		{
			player.SetWeaponCanDuck(b: false);
		}
		else
		{
			player.SetWeaponCanDuck(b: true);
		}
	}
}

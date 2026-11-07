using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class MetalStormLockPrediactionSystem : AbstractLockPrediactionSystem
{
	public MetalStormLockPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponLock(player.basicInfo.Current.UsingBigSkill);
		player.SetWeaponCanDuck(b: true);
	}
}

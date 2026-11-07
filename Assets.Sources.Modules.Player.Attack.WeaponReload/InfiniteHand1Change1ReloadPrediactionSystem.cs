using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class InfiniteHand1Change1ReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public InfiniteHand1Change1ReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		if (WeaponContext.currentWeaponEntity.special.Kil != 1)
		{
			base.PredictCmdOnWeapon(player, cmd);
		}
	}
}

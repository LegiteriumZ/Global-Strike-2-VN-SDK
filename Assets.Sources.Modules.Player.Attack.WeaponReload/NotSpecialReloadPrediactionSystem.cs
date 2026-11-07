using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class NotSpecialReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public NotSpecialReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		if (!WeaponContext.currentWeaponEntity.special.SpecialMode)
		{
			base.PredictCmdOnWeapon(player, cmd);
		}
	}
}

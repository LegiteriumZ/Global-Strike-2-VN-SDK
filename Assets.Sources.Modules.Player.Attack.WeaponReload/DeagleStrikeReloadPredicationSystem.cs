using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class DeagleStrikeReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public DeagleStrikeReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(player, 63) || PlayerAnimationUtility.IsViewAnimEqual(player, 65) || PlayerAnimationUtility.IsViewAnimEqual(player, 64) || PlayerAnimationUtility.IsViewAnimEqual(player, 72) || PlayerAnimationUtility.IsViewAnimEqual(player, 39) || PlayerAnimationUtility.IsViewAnimEqual(player, 29))
		{
			return false;
		}
		return base.CanReloadAnim(player);
	}
}

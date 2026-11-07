using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class KrissReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public KrissReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (!base.CanReloadAnim(player))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(player, 28))
		{
			return false;
		}
		return true;
	}
}

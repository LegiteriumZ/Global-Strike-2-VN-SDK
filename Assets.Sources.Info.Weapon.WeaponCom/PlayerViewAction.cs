using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class PlayerViewAction : IWeaponAction
{
	private readonly int _aniId;

	public PlayerViewAction(int aniId)
	{
		_aniId = aniId;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, _aniId);
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}

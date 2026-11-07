using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class PlayerTorsoAction : IWeaponAction
{
	private readonly int _aniId;

	public PlayerTorsoAction(int aniId)
	{
		_aniId = aniId;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, _aniId);
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}

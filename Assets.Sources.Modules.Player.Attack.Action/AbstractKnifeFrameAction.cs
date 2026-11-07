using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class AbstractKnifeFrameAction : IFrameCmdAction, ICmdAction
{
	public virtual bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasDelayAttack && !CheckDelayAttack(ref arg))
		{
			arg.CurrentWeapon.RemoveDelayAttack();
		}
		PostFrame(ref arg);
		return true;
	}

	protected virtual void PostFrame(ref CommonWeaponArg arg)
	{
	}

	protected virtual bool CheckDelayAttack(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(15) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(122) && !arg.Player.viewAnim.Equals(124) && !arg.Player.viewAnim.Equals(126) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(199) && !arg.Player.viewAnim.Equals(200) && !arg.Player.viewAnim.Equals(201) && !arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(170) && !arg.Player.viewAnim.Equals(172) && !arg.Player.viewAnim.Equals(174) && !arg.Player.viewAnim.Equals(176) && !arg.Player.viewAnim.Equals(40) && !arg.Player.viewAnim.Equals(72) && !arg.Player.viewAnim.Equals(71) && !arg.Player.viewAnim.Equals(69))
		{
			return false;
		}
		return true;
	}
}

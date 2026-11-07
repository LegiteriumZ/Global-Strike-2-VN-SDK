using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroCloseFrameAction : AbstractKnifeFrameAction
{
	protected override bool CheckDelayAttack(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(30) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(122) && !arg.Player.viewAnim.Equals(123) && !arg.Player.viewAnim.Equals(124) && !arg.Player.viewAnim.Equals(125) && !arg.Player.viewAnim.Equals(126))
		{
			return false;
		}
		return true;
	}
}

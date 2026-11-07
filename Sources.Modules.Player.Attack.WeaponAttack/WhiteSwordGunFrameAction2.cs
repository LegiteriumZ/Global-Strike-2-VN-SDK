using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteSwordGunFrameAction2 : IFrameCmdAction, ICmdAction
{
	public WhiteSwordGunFrameAction2(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != arg.CurrentWeapon.basicInfo.Data.CarryClip2)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = arg.CurrentWeapon.basicInfo.Data.CarryClip2;
		}
		return true;
	}
}

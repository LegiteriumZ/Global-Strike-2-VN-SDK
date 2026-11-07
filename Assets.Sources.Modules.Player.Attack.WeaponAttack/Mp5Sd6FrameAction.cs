using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mp5Sd6FrameAction : IFrameCmdAction, ICmdAction
{
	public Mp5Sd6FrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 0)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = 80;
		}
		else
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = arg.CurrentWeapon.basicInfo.Data.EffectLevel;
		}
		return true;
	}
}

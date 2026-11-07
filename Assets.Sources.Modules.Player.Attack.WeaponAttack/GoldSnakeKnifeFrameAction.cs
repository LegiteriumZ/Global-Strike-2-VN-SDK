using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GoldSnakeKnifeFrameAction : IFrameCmdAction, ICmdAction
{
	public GoldSnakeKnifeFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power < arg.CurrentWeapon.power.MaxPower)
		{
			arg.CurrentWeapon.power.Power += arg.Cmd.FrameInterval;
			if (arg.CurrentWeapon.power.Power > arg.CurrentWeapon.power.MaxPower)
			{
				arg.CurrentWeapon.power.Power = arg.CurrentWeapon.power.MaxPower;
			}
		}
		return true;
	}
}

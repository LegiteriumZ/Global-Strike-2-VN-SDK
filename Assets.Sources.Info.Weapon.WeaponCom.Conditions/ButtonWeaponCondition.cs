using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public class ButtonWeaponCondition : IWeaponCondition
{
	public int Button;

	public ButtonWeaponCondition(int button)
	{
		Button = button;
	}

	public bool DoCondition(ref CommonWeaponArg arg)
	{
		IUserCmd cmd = arg.Cmd;
		if (cmd != null)
		{
			return (cmd.Buttons & Button) > 0;
		}
		return false;
	}
}

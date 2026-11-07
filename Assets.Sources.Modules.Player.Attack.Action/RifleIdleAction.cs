using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

public class RifleIdleAction : IIdleCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public RifleIdleAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.DelayFire)
		{
			arg.CurrentWeapon.attack.DelayFire = false;
			if (arg.Player.move.RunUpMax)
			{
				arg.Player.move.RunUpMax = false;
			}
			if (arg.CurrentWeapon.attack.ShotsFired > 8)
			{
				arg.CurrentWeapon.attack.ShotsFired = 8;
			}
			arg.CurrentWeapon.attack.DecreaseShotsFired = arg.ClientTime + 150;
		}
		else if (arg.CurrentWeapon.attack.ShotsFired > 0 && arg.CurrentWeapon.attack.DecreaseShotsFired < arg.ClientTime)
		{
			arg.CurrentWeapon.attack.DecreaseShotsFired = arg.ClientTime + 16;
			arg.CurrentWeapon.attack.ShotsFired--;
		}
		else if (arg.CurrentWeapon.attack.ShotsFired == 0)
		{
			arg.CurrentWeapon.accuracy.Accuracy = arg.CurrentWeapon.basicInfo.Info.DefaultAccuracy;
		}
		return true;
	}
}

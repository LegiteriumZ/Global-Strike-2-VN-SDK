using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class FovRightAction : IRightCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public FovRightAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		int num = 300;
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
		{
			return true;
		}
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + num;
		if (arg.Player.fov.Fov == 90)
		{
			arg.Player.fov.Fov = 40;
			arg.Player.fov.DelayFov = 40;
		}
		else if (arg.Player.fov.Fov == 40)
		{
			arg.Player.fov.Fov = 10;
			arg.Player.fov.DelayFov = 10;
		}
		else
		{
			arg.Player.fov.Fov = 90;
			arg.Player.fov.DelayFov = 90;
		}
		return true;
	}
}

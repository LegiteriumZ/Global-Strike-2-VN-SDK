using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleScopeFovRightAction : IRightCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public RifleScopeFovRightAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleScppeWeaponInfo)
		{
			int fovDelayTime = (arg.CurrentWeapon.basicInfo.Info as IRifleScppeWeaponInfo).FovDelayTime;
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
			{
				return true;
			}
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + fovDelayTime;
			if (arg.Player.fov.Fov == 90)
			{
				arg.Player.fov.Fov = 55;
				arg.Player.fov.DelayFov = 55;
				arg.Player.fov.IsHideFristView = true;
			}
			else
			{
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
				arg.Player.fov.IsHideFristView = false;
			}
		}
		return true;
	}
}

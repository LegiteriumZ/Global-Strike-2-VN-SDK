using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleScope2FovRightAction : IRightCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public RifleScope2FovRightAction(Contexts contexts)
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
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + fovDelayTime;
			if (arg.Player.fov.Fov == 90)
			{
				arg.Player.fov.Fov = 40;
				arg.Player.fov.DelayFov = 40;
				arg.CurrentWeapon.special.SpecialMode = true;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			}
			else
			{
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
				arg.CurrentWeapon.special.SpecialMode = false;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			}
		}
		return true;
	}
}

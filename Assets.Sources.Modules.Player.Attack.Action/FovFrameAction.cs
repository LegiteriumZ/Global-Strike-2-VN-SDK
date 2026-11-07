using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class FovFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public FovFrameAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextAttackTimer <= (float)arg.ClientTime && arg.Player.fov.ResumeZoom)
		{
			arg.Player.fov.Fov = arg.Player.fov.LastFov;
			arg.Player.fov.DelayFov = arg.Player.fov.LastFov;
			arg.Player.fov.ResumeZoom = false;
		}
		if (arg.Player.fov.DelayFov > arg.Player.fov.Fov && (float)arg.ClientTime - arg.CurrentWeapon.attack.NextAttackTimer > (float)(100 - arg.CurrentWeapon.basicInfo.Info.AttackInterval))
		{
			arg.Player.fov.Fov = arg.Player.fov.DelayFov;
		}
		return true;
	}
}

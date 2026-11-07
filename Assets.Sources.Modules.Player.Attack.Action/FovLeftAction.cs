using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class FovLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public FovLeftAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		arg.Player.fov.ResumeZoom = true;
		arg.Player.fov.LastFov = arg.Player.fov.Fov;
		arg.Player.fov.DelayFov = 90;
		arg.Player.fov.Fov = 90;
		return true;
	}
}

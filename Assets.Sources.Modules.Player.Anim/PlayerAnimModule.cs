using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Anim.FirstPerson;
using Assets.Sources.Modules.Player.Anim.ThirdPerson;

namespace Assets.Sources.Modules.Player.Anim;

public sealed class PlayerAnimModule : CompositeGameModule
{
	public PlayerAnimModule(Contexts contexts)
	{
		AddModule(new FirstPersonModule(contexts));
		AddModule(new ThirdPersonModule(contexts));
	}
}

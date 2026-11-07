using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GlockRedflashPredicationSystem : AbstractAttackPredicationSystem
{
	public GlockRedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GlockRedflashLeftAction(contexts));
		RightActions.Add(new GlockRedflashRightAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new GlockRedflashFrameAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteSwordGunPredicationSystem : AbstractAttackPredicationSystem
{
	public WhiteSwordGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new WhiteSwordGunLeftAction(contexts));
		RightActions.Add(new WhiteSwordGunRightAction(contexts));
		FrameActions.Add(new WhiteSwordGunFrameAction1(contexts));
		FrameActions.Add(new WhiteSwordGunFrameAction2(contexts));
	}
}

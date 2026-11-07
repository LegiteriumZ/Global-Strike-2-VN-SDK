using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class YueTuPredicationSystem : AbstractAttackPredicationSystem
{
	public YueTuPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new YueTuLeftAction(contexts));
		RightActions.Add(new YueTuRightAction(contexts));
		FrameActions.Add(new YueTuFrameAction(contexts));
	}
}

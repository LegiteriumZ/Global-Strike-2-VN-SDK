using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HanSwordAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public HanSwordAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new HanSwordKnifeLeftAction(contexts));
		RightActions.Add(new HanSwordKnifeRightAction(contexts));
		FrameActions.Add(new HanSwordFrameAction(contexts));
	}
}

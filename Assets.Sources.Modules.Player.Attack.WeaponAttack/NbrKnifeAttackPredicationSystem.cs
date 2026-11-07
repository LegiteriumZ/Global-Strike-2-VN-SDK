using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class NbrKnifeAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public NbrKnifeAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new NbrKnifeLeftAction(contexts));
		RightActions.Add(new KnifeRightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class KnifeAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public KnifeAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
		RightActions.Add(new KnifeRightAction(contexts));
	}
}

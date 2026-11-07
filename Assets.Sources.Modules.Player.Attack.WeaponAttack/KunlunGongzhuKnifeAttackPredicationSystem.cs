using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class KunlunGongzhuKnifeAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public KunlunGongzhuKnifeAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
	}
}

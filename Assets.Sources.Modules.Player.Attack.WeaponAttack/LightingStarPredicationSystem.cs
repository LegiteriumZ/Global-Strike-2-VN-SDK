using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LightingStarPredicationSystem : AbstractAttackPredicationSystem
{
	public LightingStarPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
		RightActions.Add(new LightStarKnifeRightAction(contexts));
	}
}

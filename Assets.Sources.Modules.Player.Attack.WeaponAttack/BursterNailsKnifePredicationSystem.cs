using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BursterNailsKnifePredicationSystem : AbstractAttackPredicationSystem
{
	public BursterNailsKnifePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
		FrameActions.Add(new BursterNailsKnifeFrameAction(contexts));
		RightActions.Add(new BursterNailsKnifeRightAction(contexts));
	}
}

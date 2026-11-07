using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GoldSnakeKnifePredicationSystem : AbstractAttackPredicationSystem
{
	public GoldSnakeKnifePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
		RightActions.Add(new GoldSnakeKnifeRightAction(contexts));
		FrameActions.Add(new GoldSnakeKnifeFrameAction(contexts));
	}
}

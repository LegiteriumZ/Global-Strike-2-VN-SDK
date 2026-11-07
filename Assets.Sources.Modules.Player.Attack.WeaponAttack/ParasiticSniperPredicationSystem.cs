using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ParasiticSniperPredicationSystem : AbstractAttackPredicationSystem
{
	public ParasiticSniperPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new ParasiticSniperLeftAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
	}
}

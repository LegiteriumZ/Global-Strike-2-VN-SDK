using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteTigerPredicationSystem : AbstractAttackPredicationSystem
{
	public WhiteTigerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new M60FrameAction());
		LeftActions.Add(new WhiteTigerLeftAction(contexts));
		RightActions.Add(new M60RightAction());
	}
}

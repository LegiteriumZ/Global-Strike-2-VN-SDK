using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class UspProPredicationSystem : AbstractAttackPredicationSystem
{
	public UspProPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new UspProLeftAction(contexts));
		FrameActions.Add(new M4a1ProFrameAction(contexts));
	}
}

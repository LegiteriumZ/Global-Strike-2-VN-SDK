using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4a1ProPredicationSystem : AbstractAttackPredicationSystem
{
	public M4a1ProPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new M4a1ProLeftAction(contexts));
		FrameActions.Add(new M4a1ProFrameAction(contexts));
	}
}

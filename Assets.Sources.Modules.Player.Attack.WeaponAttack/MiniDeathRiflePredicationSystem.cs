using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MiniDeathRiflePredicationSystem : AbstractAttackPredicationSystem
{
	public MiniDeathRiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new MiniDeathFrameAction(contexts));
	}
}

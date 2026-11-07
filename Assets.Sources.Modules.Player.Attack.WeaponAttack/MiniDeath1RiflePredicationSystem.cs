using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MiniDeath1RiflePredicationSystem : AbstractAttackPredicationSystem
{
	public MiniDeath1RiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		FrameActions.Add(new MiniDeath1FrameAction(contexts));
	}
}

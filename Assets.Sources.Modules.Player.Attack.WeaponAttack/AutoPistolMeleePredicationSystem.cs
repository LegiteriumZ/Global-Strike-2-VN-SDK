using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AutoPistolMeleePredicationSystem : AbstractAttackPredicationSystem
{
	public AutoPistolMeleePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new G18UniqueLeftAction(contexts));
		RightActions.Add(new RifleMeleeDelaySoundRightAction(contexts));
		FrameActions.Add(new G18FrameAction(contexts));
	}
}

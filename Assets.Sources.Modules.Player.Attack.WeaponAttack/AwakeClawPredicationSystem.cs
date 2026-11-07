using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwakeClawPredicationSystem : AbstractAttackPredicationSystem
{
	public AwakeClawPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new AwakeClawLeftAction(contexts));
		FrameActions.Add(new WolfClawFrameAction(contexts));
	}
}

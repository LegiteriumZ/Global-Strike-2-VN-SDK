using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class WindBoxerPredicationSystem : AbstractAttackPredicationSystem
{
	public WindBoxerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new WindBoxerBaseAction(contexts));
		RightActions.Add(new KnifeRightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Mp5Sd6PredicationSystem : AbstractAttackPredicationSystem
{
	public Mp5Sd6PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Mp5Sd6LeftAction(contexts));
		FrameActions.Add(new Mp5Sd6FrameAction(contexts));
	}
}

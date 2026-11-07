using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class RifleOpticorPredicationSystem : AbstractAttackPredicationSystem
{
	public RifleOpticorPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleOpticorLeftAction(contexts));
		LeftActions.Add(new RifleOpticorKnifeLeftAction(contexts));
		RightActions.Add(new RifleOpticorRightAction(contexts));
		FrameActions.Add(new RifleOpticorSpecialFrameAction(contexts));
		FrameActions.Add(new RifleOpticorFrameAction(contexts));
	}
}

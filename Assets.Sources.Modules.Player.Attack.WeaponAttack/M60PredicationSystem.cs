using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M60PredicationSystem : AbstractAttackPredicationSystem
{
	public static int MAX_LEVEL = 1000;

	public static int BACK_LEVEL_TIME = 25;

	public M60PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new M60FrameAction());
		LeftActions.Add(new M60LeftAction(contexts));
		RightActions.Add(new M60RightAction());
	}
}

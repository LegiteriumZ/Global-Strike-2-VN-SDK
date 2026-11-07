using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Type97PredicationSystem : AbstractAttackPredicationSystem
{
	public Type97PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RifleMeleeDelaySoundRightAction rifleMeleeDelaySoundRightAction = new RifleMeleeDelaySoundRightAction(contexts)
		{
			AttackInterval = 700,
			ViewAnimId = 31,
			DelayAttackStabTimeSet = 300
		};
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(rifleMeleeDelaySoundRightAction);
		FrameActions.Add(new Type97FrameAction(contexts, rifleMeleeDelaySoundRightAction));
	}
}

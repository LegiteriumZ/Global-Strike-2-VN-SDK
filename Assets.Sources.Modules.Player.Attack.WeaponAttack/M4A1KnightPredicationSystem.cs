using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4A1KnightPredicationSystem : AbstractAttackPredicationSystem
{
	public M4A1KnightPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeDelaySoundRightAction(contexts)
		{
			AttackInterval = 1200
		});
	}
}

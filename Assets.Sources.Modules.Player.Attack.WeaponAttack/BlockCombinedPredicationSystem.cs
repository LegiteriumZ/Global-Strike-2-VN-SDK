using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class BlockCombinedPredicationSystem : AbstractAttackPredicationSystem
{
	public BlockCombinedPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BlockCombined1LeftAction(contexts));
	}
}

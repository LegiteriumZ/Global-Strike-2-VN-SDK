using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CrystalBowPredicationSystem : AbstractAttackPredicationSystem
{
	public CrystalBowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new CrystalBowLeftAction(contexts));
		FrameActions.Add(new CrystalBowFrameAction(contexts));
	}
}

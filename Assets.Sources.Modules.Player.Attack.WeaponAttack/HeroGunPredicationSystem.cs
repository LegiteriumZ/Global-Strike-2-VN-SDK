using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroGunPredicationSystem : AbstractAttackPredicationSystem
{
	public HeroGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new HeroGunLeftAction(contexts));
		FrameActions.Add(new HeroGunFrameAction());
	}
}

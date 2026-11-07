using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ArcElectricShotgunPredicationSystem : AbstractAttackPredicationSystem
{
	public ArcElectricShotgunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new ArcElectricShotgunLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new ArcElectricShotgunFrameAction(contexts));
		RightActions.Add(new ArcElectricShotgunRightAction(contexts));
	}
}

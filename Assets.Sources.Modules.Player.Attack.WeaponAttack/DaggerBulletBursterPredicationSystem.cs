namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DaggerBulletBursterPredicationSystem : AbstractAttackPredicationSystem
{
	public DaggerBulletBursterPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DaggerBulletBursterLeftAction(contexts));
		RightActions.Add(new DaggerBulletBursterRightAction(contexts));
		FrameActions.Add(new DaggerBulletBursterFrameAction(contexts));
	}
}

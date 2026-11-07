using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SlimeGunPredicationSystem : AbstractAttackPredicationSystem
{
	public SlimeGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new ShotGunPistolLeftAction(contexts));
		RightActions.Add(new SlimeGunRightAction(contexts));
	}
}

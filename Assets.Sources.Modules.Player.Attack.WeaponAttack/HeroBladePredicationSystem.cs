namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroBladePredicationSystem : AbstractAttackPredicationSystem
{
	public HeroBladePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new HeroBladeKnifeLeftAction(contexts));
		RightActions.Add(new HeroBladeKnifeRightAction(contexts));
		FrameActions.Add(new HeroBladeKnifeFrameAction(contexts));
	}
}

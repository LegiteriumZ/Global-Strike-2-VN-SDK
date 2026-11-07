using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class ShadowDemonBayonetPredicationSystem : AbstractAttackPredicationSystem
{
	public ShadowDemonBayonetPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RightActions.Add(new ShadowDemonBayonetRightAction(contexts));
	}
}

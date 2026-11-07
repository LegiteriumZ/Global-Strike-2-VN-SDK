namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CyBerPunkSwordAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public CyBerPunkSwordAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new CyBerPunkSwordLeftAction(contexts));
		RightActions.Add(new CyBerPunkSwordRightAction(contexts));
	}
}

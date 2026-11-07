namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class P28CannonPredicationSystem : AbstractAttackPredicationSystem
{
	public P28CannonPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new P28CannonLeftAction(contexts));
	}
}

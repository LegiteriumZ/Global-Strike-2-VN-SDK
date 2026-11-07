namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class DoubleBladePredicationSystem : AbstractAttackPredicationSystem
{
	public DoubleBladePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DoubleBlade1LeftAction(contexts));
		RightActions.Add(new DoubleBlade1RightAction(contexts));
	}
}

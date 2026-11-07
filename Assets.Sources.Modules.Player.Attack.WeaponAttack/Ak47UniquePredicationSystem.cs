namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47UniquePredicationSystem : AbstractAttackPredicationSystem
{
	public Ak47UniquePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new Ak47UniqueLeftAction(contexts));
		RightActions.Add(new Ak47UniqueRifleMeleeRightAction(contexts));
		FrameActions.Add(new Ak47UniqueFrameAction(contexts));
	}
}

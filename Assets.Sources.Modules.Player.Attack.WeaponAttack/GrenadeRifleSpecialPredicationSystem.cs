namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GrenadeRifleSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	public GrenadeRifleSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GrenadeRifleLeftAction(contexts));
		RightActions.Add(new GrenadeRifleRightAction(contexts));
	}
}

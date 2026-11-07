namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GrenadeRiflePredicationSystem : AbstractAttackPredicationSystem
{
	public GrenadeRiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GrenadeRifleLeftAction(contexts));
	}
}

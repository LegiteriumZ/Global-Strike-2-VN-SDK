namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HonorShieldPredicationSystem : AbstractAttackPredicationSystem
{
	public HonorShieldPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new HonorShielKnifeLeftAction(contexts));
		FrameActions.Add(new HonorShielKnifeFrameAction(contexts));
	}
}

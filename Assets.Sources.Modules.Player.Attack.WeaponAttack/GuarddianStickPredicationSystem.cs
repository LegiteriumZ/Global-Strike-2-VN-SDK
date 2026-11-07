namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class GuarddianStickPredicationSystem : AbstractAttackPredicationSystem
{
	public GuarddianStickPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new GuarddianStickFrame(contexts));
	}
}

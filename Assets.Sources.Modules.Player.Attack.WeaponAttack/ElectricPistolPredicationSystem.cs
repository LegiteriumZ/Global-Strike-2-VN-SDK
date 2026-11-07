using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ElectricPistolPredicationSystem : AbstractAttackPredicationSystem
{
	public ElectricPistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new ElectricPistolLeftAction(contexts));
		FrameActions.Add(new ElectricPistolFrameAction(contexts));
	}
}

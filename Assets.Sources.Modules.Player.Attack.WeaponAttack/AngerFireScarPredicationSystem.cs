using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AngerFireScarPredicationSystem : AbstractAttackPredicationSystem
{
	public AngerFireScarPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new AngerFireScarLeftAction(contexts));
		RightActions.Add(new AngerFireScarRightAction(contexts));
		FrameActions.Add(new AngerFireScarSwitchAction(contexts));
	}
}

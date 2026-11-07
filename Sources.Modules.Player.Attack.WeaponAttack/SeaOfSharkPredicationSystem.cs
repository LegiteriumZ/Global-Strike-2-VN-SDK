using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class SeaOfSharkPredicationSystem : AbstractAttackPredicationSystem
{
	public SeaOfSharkPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SeaOfSharkLeftAction());
		RightActions.Add(new SawRightAction(contexts));
		FrameActions.Add(new SeaOfSharkFrame1Action(contexts));
		FrameActions.Add(new SeaOfSharkFrame2Action(contexts));
	}
}

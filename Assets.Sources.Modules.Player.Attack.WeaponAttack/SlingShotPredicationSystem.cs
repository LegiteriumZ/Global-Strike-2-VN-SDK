namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SlingShotPredicationSystem : AbstractAttackPredicationSystem
{
	public SlingShotPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SlingShotLeftAction(contexts));
		FrameActions.Add(new SlingShotFrameAction(contexts));
	}
}

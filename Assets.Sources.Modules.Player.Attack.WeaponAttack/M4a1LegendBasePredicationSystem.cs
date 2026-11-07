using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4a1LegendBasePredicationSystem : AbstractAttackPredicationSystem
{
	public static int GONGSU_ADD = 16;

	public static int JI_SU_HUAN_DAN_EFFECT_LEVEL = 8;

	public M4a1LegendBasePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeDelaySoundRightAction(contexts));
	}
}

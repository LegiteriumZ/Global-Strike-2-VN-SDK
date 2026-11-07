using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SanDanHeroSpecial : AbstractAttackPredicationSystem
{
	public SanDanHeroSpecial(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new SanDanHeroSpecialLeftAction(contexts));
	}
}

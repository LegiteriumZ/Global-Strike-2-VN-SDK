using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroCloseLeftAction : KnifeLeftAction
{
	private readonly int LEFT_ATTACK_INTERVAL;

	private readonly int LEFT_ATTACK_INTERVAL2;

	public HeroCloseLeftAction(Contexts contexts, int interval1, int interval2)
		: base(contexts)
	{
		LEFT_ATTACK_INTERVAL = interval1;
		LEFT_ATTACK_INTERVAL2 = interval2;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		_ = arg.CurrentWeapon.basicInfo.Info;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + (arg.CurrentWeapon.special.SpecialMode ? LEFT_ATTACK_INTERVAL2 : LEFT_ATTACK_INTERVAL));
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
		return 0;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		return HeroClosePredicationSystem.getDelayAttackTime(arg.Player.viewAnim.ViewAnimInfo.StateId);
	}
}

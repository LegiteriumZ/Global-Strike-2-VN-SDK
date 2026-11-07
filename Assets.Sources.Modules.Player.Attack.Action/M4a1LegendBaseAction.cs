using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class M4a1LegendBaseAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	private WeaponKnifeAttackAction[] weaponKnifeAttacks;

	public M4a1LegendBaseAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		weaponKnifeAttacks = new WeaponKnifeAttackAction[3]
		{
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(-1).SetNextKnifeAttackAnim(31).SetNextKnifeAttackRaise(30)
				.SetDelayAttackTime(270),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(30).SetNextKnifeAttackAnim(170).SetNextKnifeAttackRaise(169)
				.SetDelayAttackTime(300),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(169).SetNextKnifeAttackAnim(20).SetNextKnifeAttackRaise(13)
				.SetEndAnimTime(50)
				.SetDelayAttackTime(270)
		};
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		KnifeLogic(ref arg);
		arg.CurrentWeapon.basicInfo.Info.AttackInterval = getFixAttackInterval(arg.Player);
		return true;
	}

	private int getFixAttackInterval(PlayerEntity player)
	{
		if ((player.GetCurrentWeaponEffectLevel() & 0x10) > 0)
		{
			return 80;
		}
		return 95;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return false;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, null);
		return 0;
	}

	protected int OnFireWithDelay(ref CommonWeaponArg arg, int delayTime)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, null);
		return 0;
	}

	private void KnifeLogic(ref CommonWeaponArg arg)
	{
		if (arg.Player.viewAnim.ViewAnimInfo.StateId == 31 || arg.Player.viewAnim.ViewAnimInfo.StateId == 170 || arg.Player.viewAnim.ViewAnimInfo.StateId == 20 || arg.Player.viewAnim.ViewAnimInfo.StateId == 30 || arg.Player.viewAnim.ViewAnimInfo.StateId == 169 || arg.Cmd.IsSecondaryAttackOn)
		{
			WeaponKnifeAttackLogic(ref arg);
		}
	}

	private void WeaponKnifeAttackLogic(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasDelayAttack && arg.CurrentWeapon.delayAttack.DelayFireRemain > arg.ClientTime)
		{
			return;
		}
		for (int i = 0; i < weaponKnifeAttacks.Length; i++)
		{
			WeaponKnifeAttackAction weaponKnifeAttackAction = weaponKnifeAttacks[i];
			bool canNextAttack = true;
			if (i == 0)
			{
				canNextAttack = (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			}
			weaponKnifeAttackAction.SetCanNextAttack(canNextAttack);
			if (weaponKnifeAttackAction.KnifeLogic(ref arg))
			{
				OnFireWithDelay(ref arg, weaponKnifeAttackAction.GetDelayAttackTime());
				break;
			}
		}
	}
}

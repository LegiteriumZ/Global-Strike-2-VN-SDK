using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class WindBoxerBaseAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	private WeaponKnifeAttackAction[] weaponKnifeAttacks;

	public WindBoxerBaseAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		weaponKnifeAttacks = new WeaponKnifeAttackAction[5]
		{
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(-1).SetNextKnifeAttackAnim(31).SetNextKnifeAttackRaise(30)
				.SetDelayAttackTime(270),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(30).SetNextKnifeAttackAnim(170).SetNextKnifeAttackRaise(169)
				.SetDelayAttackTime(300),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(169).SetNextKnifeAttackAnim(172).SetNextKnifeAttackRaise(171)
				.SetDelayAttackTime(270),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(171).SetNextKnifeAttackAnim(174).SetNextKnifeAttackRaise(173)
				.SetDelayAttackTime(360),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(173).SetNextKnifeAttackAnim(176).SetNextKnifeAttackRaise(175)
				.SetDelayAttackTime(600)
		};
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		KnifeLogic(ref arg);
		return true;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return base.CanFire(ref arg);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo rifleMeleeWeaponInfo)
		{
			return OnFireWithDelay(ref arg, rifleMeleeWeaponInfo.DelayAttackStabTime);
		}
		return -1;
	}

	protected int OnFireWithDelay(ref CommonWeaponArg arg, int delayTime)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
		{
			float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		}
		return 0;
	}

	private void KnifeLogic(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsAttackOn)
		{
			WeaponKnifeAttackLogic(ref arg);
		}
	}

	private void WeaponKnifeAttackLogic(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasDelayAttack)
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
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
				break;
			}
		}
	}
}

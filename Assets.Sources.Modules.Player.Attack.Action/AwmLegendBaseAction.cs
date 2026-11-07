using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class AwmLegendBaseAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public static int SHI_LI = 1;

	public static int SKILL1 = 2;

	public static int MIAOZHUN = 4;

	private WeaponKnifeAttackAction[] weaponKnifeAttacks;

	private int reduce_cd_time = 2000;

	private float powerCdTimePer;

	public AwmLegendBaseAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
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
		int maxKnifeCdTime = GetMaxKnifeCdTime();
		powerCdTimePer = maxKnifeCdTime / 12;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (!RuleUtilty.IsPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) && !RuleUtilty.IsGeneralPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			KnifeLogic(ref arg);
		}
		return true;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return false;
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
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, null);
		}
		return 0;
	}

	private void KnifeLogic(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.isSkill && !arg.CurrentWeapon.special.SpecialMode && !IsShiLi(arg.CurrentWeapon))
		{
			WeaponKnifeAttackLogic(ref arg);
		}
	}

	public bool IsShiLi(WeaponEntity currentWeapon)
	{
		return (currentWeapon.basicInfo.Data.WeaponFlag & SHI_LI) > 0;
	}

	public static bool IsMiaoZhun(WeaponEntity currentWeapon)
	{
		return (currentWeapon.basicInfo.Data.WeaponFlag & MIAOZHUN) > 0;
	}

	public void SetMiaoZhun(WeaponEntity currentWeapon, bool value)
	{
		if (value)
		{
			currentWeapon.basicInfo.Data.WeaponFlag = currentWeapon.basicInfo.Data.WeaponFlag | MIAOZHUN;
		}
		else
		{
			currentWeapon.basicInfo.Data.WeaponFlag &= ~MIAOZHUN;
		}
	}

	public bool IsSkill1(WeaponEntity currentWeapon)
	{
		return (currentWeapon.basicInfo.Data.WeaponFlag & SKILL1) <= 0;
	}

	private int GetLeftPower(WeaponEntity currentWeapon)
	{
		return currentWeapon.power.MaxPower - currentWeapon.power.Power;
	}

	private void WeaponKnifeAttackLogic(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasDelayAttack)
		{
			return;
		}
		int leftPower = GetLeftPower(arg.CurrentWeapon);
		for (int i = 0; i < weaponKnifeAttacks.Length; i++)
		{
			WeaponKnifeAttackAction weaponKnifeAttackAction = weaponKnifeAttacks[i];
			bool flag = leftPower > 0;
			if (i == 0)
			{
				flag = flag && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			}
			weaponKnifeAttackAction.SetCanNextAttack(flag);
			if (weaponKnifeAttackAction.KnifeLogic(ref arg))
			{
				OnFireWithDelay(ref arg, weaponKnifeAttackAction.GetDelayAttackTime());
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
				arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 = (uint)(arg.ClientTime + reduce_cd_time);
				break;
			}
		}
	}

	public int GetKnifeCdTime(int index)
	{
		int num = 0;
		for (int i = 1; i <= index; i++)
		{
			num += 500 * i;
		}
		return num;
	}

	public int GetMaxKnifeCdTime()
	{
		int num = 0;
		for (int i = 1; i <= 5; i++)
		{
			num += GetKnifeCdTime(i);
		}
		return num;
	}

	public void SetShiLi(WeaponEntity currentWeapon, bool value)
	{
		if (value)
		{
			currentWeapon.basicInfo.Data.WeaponFlag = currentWeapon.basicInfo.Data.WeaponFlag | SHI_LI;
		}
		else
		{
			currentWeapon.basicInfo.Data.WeaponFlag &= ~SHI_LI;
		}
	}

	public void AddPower(WeaponEntity currentWeapon, int num)
	{
		currentWeapon.power.Power += num;
		if (currentWeapon.power.Power < 0)
		{
			currentWeapon.power.Power = 0;
		}
		if (currentWeapon.power.Power > currentWeapon.power.MaxPower)
		{
			currentWeapon.power.Power = currentWeapon.power.MaxPower;
		}
		if (currentWeapon.power.Power == currentWeapon.power.MaxPower)
		{
			SetShiLi(currentWeapon, value: true);
		}
		if (currentWeapon.power.Power <= 0)
		{
			SetShiLi(currentWeapon, value: false);
		}
	}

	private void KnifeCdReduce(WeaponEntity currentWeapon, IUserCmd cmd, int clientTime)
	{
		if (currentWeapon.power.Power > 0 && clientTime >= currentWeapon.basicInfo.Data.WeaponTimer1)
		{
			int num = (int)((double)(-cmd.FrameInterval) * 0.001 * (double)powerCdTimePer);
			AddPower(currentWeapon, num);
		}
	}
}

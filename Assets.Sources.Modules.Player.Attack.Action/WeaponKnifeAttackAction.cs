using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class WeaponKnifeAttackAction
{
	private int nextKnifeAttackAnim = -1;

	private int delayAttackTime;

	private int currentAttackRaise;

	private int nextKnifeAttackRaise;

	private bool isCanNextAttack = true;

	private int endAnimTime = -1;

	public WeaponKnifeAttackAction SetCanNextAttack(bool canNextAttack)
	{
		isCanNextAttack = canNextAttack;
		return this;
	}

	public WeaponKnifeAttackAction SetNextKnifeAttackRaise(int nextKnifeAttackRaise)
	{
		this.nextKnifeAttackRaise = nextKnifeAttackRaise;
		return this;
	}

	public WeaponKnifeAttackAction SetNextKnifeAttackAnim(int nextKnifeAttackAnim)
	{
		this.nextKnifeAttackAnim = nextKnifeAttackAnim;
		return this;
	}

	public WeaponKnifeAttackAction SetDelayAttackTime(int delayAttackTime)
	{
		this.delayAttackTime = delayAttackTime;
		return this;
	}

	public int GetDelayAttackTime()
	{
		return delayAttackTime;
	}

	public WeaponKnifeAttackAction SetCurrentAttackRaise(int currentAttackRaise)
	{
		this.currentAttackRaise = currentAttackRaise;
		return this;
	}

	public WeaponKnifeAttackAction SetEndAnimTime(int value)
	{
		endAnimTime = value;
		return this;
	}

	public bool KnifeLogic(ref CommonWeaponArg arg)
	{
		if (!isCanNextAttack)
		{
			return false;
		}
		if (currentAttackRaise > 0)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, currentAttackRaise))
			{
				return false;
			}
			if (PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, currentAttackRaise) - arg.Player.viewAnim.RemainTime >= 50)
			{
				return false;
			}
		}
		return NextKnife(ref arg);
	}

	private bool NextKnife(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimExist(arg.Player, nextKnifeAttackAnim))
		{
			return false;
		}
		PlayerAnimationUtility.SetViewAnimation(arg.Player, nextKnifeAttackAnim);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, nextKnifeAttackAnim);
		int num = ((endAnimTime > 0) ? endAnimTime : PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, nextKnifeAttackRaise));
		int num2 = arg.ClientTime + num + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = num2;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		return true;
	}
}

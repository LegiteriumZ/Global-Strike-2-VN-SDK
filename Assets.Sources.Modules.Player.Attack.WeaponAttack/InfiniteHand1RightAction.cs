using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1RightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public InfiniteHand1RightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddCondition();
	}

	private void AddCondition()
	{
		WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
		weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain.AddChain((WeaponFireChain)OnFire);
		WeaponChain<CommonWeaponArg> weaponChain2 = base.OnFireFunc.AddChain(1, (WeaponFireChain)SetOtherFireAnim);
		weaponChain2.AddChain((WeaponFireChain)SetNextAttack);
		weaponChain2.AddChain((WeaponFireChain)OnFire);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			base.Action(ref arg);
		}
		return true;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		RifleMeleeWeaponInfo rifleMeleeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + rifleMeleeWeaponInfo.SlashSlashTime);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + rifleMeleeWeaponInfo.SlashStabTime);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
		PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 31);
		return 0;
	}

	protected virtual int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 29);
			return 0;
		}
		return -1;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo rifleMeleeWeaponInfo)
		{
			float shotDistance = rifleMeleeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFire3Sound);
		}
		return 0;
	}
}

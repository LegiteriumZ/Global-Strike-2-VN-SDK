using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleOpticorKnifeLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
{
	public RifleOpticorKnifeLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitWorldAction);
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddCondition();
	}

	private void AddCondition()
	{
		WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
		weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain.AddChain((WeaponFireChain)OnFire);
		WeaponChain<CommonWeaponArg> weaponChain2 = base.OnFireFunc.AddChain(1, (WeaponFireChain)SetOtherFireAnim);
		weaponChain2.AddChain((WeaponFireChain)SetNextAttack);
		weaponChain2.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain2.AddChain((WeaponFireChain)OnFire);
		weaponChain2.AddChain((WeaponFireChain)ResetMode);
	}

	protected virtual int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
		{
			arg.CurrentWeapon.special.Kil = 1;
			return 0;
		}
		return -1;
	}

	private int ResetMode(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.special.Kil = 0;
		return 0;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		RifleMeleeWeaponInfo rifleMeleeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + rifleMeleeWeaponInfo.SlashStabTime);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + rifleMeleeWeaponInfo.SlashStabTime);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.Kil == 1)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 71);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 69);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			return false;
		}
		return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		base.OnFireFunc.Step(ref arg);
		return true;
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

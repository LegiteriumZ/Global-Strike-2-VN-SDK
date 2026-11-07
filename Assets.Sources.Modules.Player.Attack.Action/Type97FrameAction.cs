using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class Type97FrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	public bool StartTripleAttack { get; set; }

	public Type97FrameAction(Contexts contexts, IIdleCmdAction action)
		: base(contexts)
	{
		StartTripleAttack = false;
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(OnFire);
	}

	protected override int IsAttackOn(ref CommonWeaponArg arg)
	{
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20) && StartTripleAttack && arg.Player.viewAnim.RightCurrentTime > 600)
		{
			StartTripleAttack = false;
			return true;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 30) && arg.Player.viewAnim.RightCurrentTime < 50 && arg.Cmd.IsSecondaryAttackOn)
		{
			StartTripleAttack = true;
			SetAttackAnim(ref arg);
			return true;
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
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
		}
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 1220);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		return 0;
	}
}

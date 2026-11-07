using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class WolfClawDoubleAttackAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public WolfClawDoubleAttackAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return true;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
		return 0;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		_ = arg.CurrentWeapon.basicInfo.Info;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 300);
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + 300);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, GetAttackAnimIdByHit(ref arg, arg.CurrentWeapon.special.EffectLevel - 1));
		return 0;
	}

	private int GetAttackAnimIdByHit(ref CommonWeaponArg arg, int hit)
	{
		return WolfClawFrameAction.GetDoubleConfigByHitidx(arg.CurrentWeapon, hit).Effect switch
		{
			1 => PlayerAnimationUtility.IsViewAnimExist(arg.Player, 40) ? 40 : 72, 
			2 => PlayerAnimationUtility.IsViewAnimExist(arg.Player, 71) ? 71 : 72, 
			_ => 72, 
		};
	}

	protected int HitPlayer(ref HitPlayerArgs arg)
	{
		arg.currentWeapon.attack.NextAttackTimer += 100f;
		arg.currentWeapon.attack.NextSecondaryAttackTimer += 100f;
		return 0;
	}
}

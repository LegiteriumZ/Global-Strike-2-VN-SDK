using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DartsRedflashLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
{
	public DartsRedflashLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.SlashSlashTime);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.SlashStabTime);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			arg.CurrentWeapon.special.SpecialMode = false;
		}
		else
		{
			if (arg.CurrentWeapon.special.EffectLevel == 1)
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			}
			if (arg.CurrentWeapon.special.EffectLevel == 2 && CanSpecialAttack(arg.Player))
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 149);
			}
		}
		return 0;
	}

	private bool CanSpecialAttack(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 149) && !PlayerAnimationUtility.IsViewAnimEqual(player, 148))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 150);
		}
		return false;
	}

	protected int HitPlayer(ref HitPlayerArgs arg)
	{
		arg.currentWeapon.attack.NextAttackTimer += 50f;
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (arg.CurrentWeapon.special.EffectLevel == 4)
		{
			return false;
		}
		bool result = false;
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			result = true;
		}
		else if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && 30 == arg.Player.viewAnim.ViewAnimInfo.StateId && !arg.CurrentWeapon.hasDelayAttack && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
		{
			arg.CurrentWeapon.special.SpecialMode = true;
			result = true;
		}
		return result;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		return 0;
	}
}

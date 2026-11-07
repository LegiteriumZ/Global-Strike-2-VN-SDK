using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroBladeKnifeRightAction : KnifeRightAction
{
	public HeroBladeKnifeRightAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(IsAttackOn);
		AddFire(base.CanFireInt);
		AddFire(SetAttackAnim);
		AddFire(SetNewAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected int SetNewAttackAnim(ref CommonWeaponArg arg)
	{
		int index = 2;
		if (arg.CurrentWeapon.GetComponent(index) is AttachComponent attachComponent)
		{
			HeroBladeAttach heroBladeAttach = attachComponent.Data as HeroBladeAttach;
			if (heroBladeAttach.swordProtectionType == 2)
			{
				heroBladeAttach.sweep = true;
			}
			else
			{
				heroBladeAttach.sweep = false;
			}
			if (heroBladeAttach.swordType == 1 || heroBladeAttach.swordType == 0)
			{
				if (heroBladeAttach.swordProtectionType == 1 || heroBladeAttach.swordProtectionType == 0)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				}
			}
			if (heroBladeAttach.swordType == 2)
			{
				if (heroBladeAttach.swordProtectionType == 2)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 96);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				}
			}
			if (heroBladeAttach.swordProtectionType == 1)
			{
				arg.Player.viewAnim.RightSpeed = 1.2f;
			}
			else
			{
				arg.Player.viewAnim.RightSpeed = 1f;
			}
		}
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		DefaultWeaponInfo defaultWeaponInfo = arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo;
		int index = 2;
		HeroBladeAttach obj = (arg.CurrentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach;
		float num = 0f;
		KnifeFire(distance: (!obj.sweep) ? defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false) : defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true), arg: ref arg, seq: arg.Cmd.Seq, soundFunc: FireUtility.PlaySecFireSound);
		return 0;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo knifeWeaponInfo)
		{
			if (arg.Player.viewAnim.Equals(31) || arg.Player.viewAnim.Equals(69))
			{
				return knifeWeaponInfo.DelayAttackSlashTime;
			}
			if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(72))
			{
				return knifeWeaponInfo.DelayAttackStabTime;
			}
			if (arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(71))
			{
				if (knifeWeaponInfo.DelayAttackSlashTime2 > 0)
				{
					return knifeWeaponInfo.DelayAttackSlashTime2;
				}
				return knifeWeaponInfo.DelayAttackSlashTime;
			}
			if (arg.Player.viewAnim.Equals(28) || arg.Player.viewAnim.Equals(96))
			{
				return knifeWeaponInfo.DelayAttackStabTime;
			}
		}
		return 0;
	}
}

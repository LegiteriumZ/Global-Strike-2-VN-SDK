using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroBladeKnifeLeftAction : KnifeLeftAction
{
	public HeroBladeKnifeLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetNewAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected int SetNewAttackAnim(ref CommonWeaponArg arg)
	{
		int index = 2;
		HeroBladeAttach heroBladeAttach = (arg.CurrentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach;
		heroBladeAttach.sweep = false;
		int index2 = 16;
		SpecialComponent specialComponent = arg.CurrentWeapon.GetComponent(index2) as SpecialComponent;
		if (heroBladeAttach.swordProtectionType == 1 || heroBladeAttach.swordProtectionType == 0)
		{
			if (specialComponent.SpecialMode)
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			}
			else
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			}
		}
		else if (specialComponent.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 71);
		}
		else
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 69);
		}
		if (heroBladeAttach.swordProtectionType == 1)
		{
			arg.Player.viewAnim.RightSpeed = 1.2f;
		}
		else
		{
			arg.Player.viewAnim.RightSpeed = 1f;
		}
		specialComponent.SpecialMode = false;
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		bool result = false;
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			result = true;
		}
		else if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && !arg.CurrentWeapon.hasDelayAttack)
		{
			int index = 16;
			SpecialComponent specialComponent = arg.CurrentWeapon.GetComponent(index) as SpecialComponent;
			if ((int)((float)PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) / arg.Player.viewAnim.RightSpeed) - arg.Player.viewAnim.RemainTime < 50)
			{
				result = true;
				specialComponent.SpecialMode = true;
			}
		}
		return result;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo != null)
		{
			_ = arg.CurrentWeapon.basicInfo.Info;
			DefaultWeaponInfo defaultWeaponInfo = arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo;
			int index = 2;
			if (arg.CurrentWeapon.GetComponent(index) is AttachComponent attachComponent)
			{
				HeroBladeAttach heroBladeAttach = attachComponent.Data as HeroBladeAttach;
				float num = 0f;
				KnifeFire(distance: (heroBladeAttach == null || heroBladeAttach.swordProtectionType != 2) ? defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false) : defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true), arg: ref arg, seq: arg.Cmd.Seq, soundFunc: FireUtility.PlayFireSound);
			}
		}
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

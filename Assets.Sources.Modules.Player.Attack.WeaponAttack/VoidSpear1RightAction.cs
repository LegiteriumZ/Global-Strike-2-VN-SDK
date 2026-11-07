using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidSpear1RightAction : KnifeRightAction
{
	public VoidSpear1RightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (arg.Cmd.IsAttackOn)
		{
			return false;
		}
		if (!WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return false;
		}
		return true;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		return 0;
	}

	protected override int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		float num = ((arg.CurrentWeapon.clip.CarryClip2 >= 0) ? 1.2f : 1f);
		arg.Player.viewAnim.RightSpeed = num;
		arg.CurrentWeapon.attack.NextAttackTimer = (float)arg.ClientTime + (float)knifeWeaponInfo.StabSlashTime / num;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (float)arg.ClientTime + (float)knifeWeaponInfo.StabStabTime / num;
		return 0;
	}
}

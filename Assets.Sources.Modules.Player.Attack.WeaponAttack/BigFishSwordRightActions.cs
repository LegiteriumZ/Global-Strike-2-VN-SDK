using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BigFishSwordRightActions : KnifeRightAction
{
	public BigFishSwordRightActions(Contexts contexts)
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
		if (arg.CurrentWeapon.basicInfo.Data.Kill != 0)
		{
			return false;
		}
		return true;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Power != 0)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 96);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		}
		return 0;
	}
}

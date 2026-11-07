using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class ShadowDemonBayonetRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public ShadowDemonBayonetRightAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetLegsAnimation(arg.Player, 50);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return CanSecondaryFirePlayer(ref arg);
		}
		return false;
	}

	private bool CanSecondaryFirePlayer(ref CommonWeaponArg arg)
	{
		return CanSecondaryFirePlayerAnim(ref arg);
	}

	private bool CanSecondaryFirePlayerAnim(ref CommonWeaponArg arg)
	{
		if (arg.Player.GetLegAnimation() != 45 && arg.Player.GetLegAnimation() != 49 && arg.Player.GetLegAnimation() != 184 && arg.Player.GetLegAnimation() != 27 && arg.Player.GetLegAnimation() != 50 && arg.Player.GetLegAnimation() != 54)
		{
			return arg.Player.GetLegAnimation() != 57;
		}
		return false;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		if (CheckCurrentCareer(ref arg))
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 15000;
		}
		else
		{
			int legAnimDuration = PlayerAnimationUtility.GetLegAnimDuration(arg.Player, 50);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + legAnimDuration;
		}
		return 0;
	}

	private bool CheckCurrentCareer(ref CommonWeaponArg arg)
	{
		return arg.Player.GetCareer().Equals("shadow_demon");
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		return 0;
	}
}

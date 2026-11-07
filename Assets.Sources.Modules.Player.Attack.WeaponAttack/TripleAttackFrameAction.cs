using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TripleAttackFrameAction : AbstractFrameAction
{
	public TripleAttackFrameAction(Contexts contexts, IIdleCmdAction action)
		: base(contexts, action)
	{
	}

	protected override int Frame(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 123))
			{
				if (arg.Player.viewAnim.RightCurrentTime < 50)
				{
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 124);
					viewAnimDuration += PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 125);
					SetSecAttack(arg.Player, arg.CurrentWeapon, 124, viewAnimDuration, arg.ClientTime);
					WeaponUtility.SetDelayAttackStabTime(ref arg, 200);
					OnFire(ref arg);
					return 0;
				}
			}
			else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 125) && arg.Player.viewAnim.RightCurrentTime < 50)
			{
				int viewAnimDuration2 = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 126);
				SetSecAttack(arg.Player, arg.CurrentWeapon, 126, viewAnimDuration2, arg.ClientTime);
				WeaponUtility.SetDelayAttackStabTime(ref arg, 200);
				OnFire(ref arg);
				return 0;
			}
		}
		return -1;
	}

	private void SetSecAttack(PlayerEntity player, WeaponEntity currentWeapon, int anim, int duration, int clientTime)
	{
		PlayerAnimationUtility.SetViewAnimation(player, anim);
		PlayerAnimationUtility.SetTorseAnimation(player, 20);
		currentWeapon.attack.NextSecondaryAttackTimer = clientTime + duration;
		currentWeapon.attack.NextAttackTimer = currentWeapon.attack.NextSecondaryAttackTimer;
	}

	protected void OnFire(ref CommonWeaponArg arg)
	{
		if (BindAction is Ak47LegendRightAction ak47LegendRightAction)
		{
			ak47LegendRightAction.Fire(ref arg);
		}
	}
}

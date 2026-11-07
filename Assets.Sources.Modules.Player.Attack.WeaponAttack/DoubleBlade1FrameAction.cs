using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class DoubleBlade1FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	public DoubleBlade1FrameAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != arg.CurrentWeapon.clip.Clip2)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = arg.CurrentWeapon.clip.Clip2;
		}
		return true;
	}

	protected virtual bool CanShowGun(ref CommonWeaponArg arg)
	{
		return true;
	}

	protected virtual bool CanNormalToSpecailAni(ref CommonWeaponArg arg)
	{
		return !arg.CurrentWeapon.special.SpecialMode;
	}

	protected virtual bool CanSpecailToNoramlAni(ref CommonWeaponArg arg)
	{
		return arg.CurrentWeapon.special.SpecialMode;
	}

	protected virtual void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = true;
	}

	protected virtual void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = false;
	}
}

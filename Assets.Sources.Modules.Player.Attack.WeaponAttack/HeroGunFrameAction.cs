using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroGunFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly int HIGHT_EFFECT = 1;

	private readonly SkillReleaseTrigger trigger;

	private int nextUseTime;

	private WeaponEntity weapon;

	public HeroGunFrameAction()
	{
		trigger = new SkillReleaseTrigger(512);
		trigger.pressedCallFun = whenPressed;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		weapon = arg.CurrentWeapon;
		checkTriggered(arg);
		return true;
	}

	private bool whenPressed(PlayerEntity player, int cmd)
	{
		if (!player.viewAnim.Equals(87))
		{
			PlayerAnimationUtility.SetViewAnimation(player, 87);
		}
		setHighEffect(weapon, b: true);
		return true;
	}

	private void checkTriggered(CommonWeaponArg arg)
	{
		if (arg.Player.clientTime.ClientTime > nextUseTime && trigger.triggered(arg.Player, arg.Cmd.Buttons))
		{
			fireLight(arg, trigger.pressedTime > 40);
		}
	}

	private void fireLight(CommonWeaponArg arg, bool hold)
	{
		if (hold)
		{
			nextUseTime = arg.Player.clientTime.ClientTime + 1500;
		}
		else
		{
			nextUseTime = arg.Player.clientTime.ClientTime + 1500;
		}
		FireUtility.PlaySecFireSound(ref arg);
		setHighEffect(arg.CurrentWeapon, b: false);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 88);
	}

	private void setHighEffect(WeaponEntity argCurrentWeapon, bool b)
	{
		if (b)
		{
			argCurrentWeapon.special.EffectLevel |= HIGHT_EFFECT;
		}
		else
		{
			argCurrentWeapon.special.EffectLevel &= ~HIGHT_EFFECT;
		}
	}
}

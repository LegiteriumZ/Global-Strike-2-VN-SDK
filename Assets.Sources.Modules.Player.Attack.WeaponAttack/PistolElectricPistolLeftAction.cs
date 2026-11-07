using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolElectricPistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private MessageContext _messageContext;

	public PistolElectricPistolLeftAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int FireDescClip(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.power.Power -= arg.CurrentWeapon.power.MaxPower2;
		return 0;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (CanFire(ref arg) && canFireButton(arg.Player, arg.CurrentWeapon))
		{
			OnFireFunc.Step(ref arg);
		}
		return true;
	}

	private bool canFireButton(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.power.Power >= currentWeapon.power.MaxPower2)
		{
			return true;
		}
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_ENERGY_RECOVERY"));
		NotifyManager.ForceInvoke(38);
		return false;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return arg.CurrentWeapon.attack.ShotsFired < 1;
	}
}

using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Sa58FutureRightAction : RifleMeleeRightAction, IRightCmdAction, ICmdAction
{
	private int _raceType;

	private int _subRaceType;

	public Sa58FutureRightAction(Contexts contexts)
		: base(contexts)
	{
		_raceType = contexts.battleRoom.roomData.Data.RaceType;
		_subRaceType = contexts.battleRoom.roomData.Data.SubRaceType;
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetNextAttack);
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 72);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
		}
		else
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (CheckRuleCanFire() && CheckEffectLevelCanFire(ref arg))
		{
			if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
			{
				return WeaponUtility.CanSecondaryAttack(ref arg);
			}
			return false;
		}
		return false;
	}

	protected bool CheckEffectLevelCanFire(ref CommonWeaponArg arg)
	{
		return (arg.CurrentWeapon.special.EffectLevel & 4) > 0;
	}

	protected bool CheckRuleCanFire()
	{
		return true;
	}
}

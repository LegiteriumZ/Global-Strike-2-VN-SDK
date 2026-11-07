using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SawFrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	private int _lastAttackTime;

	public SawFrameAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
		{
			if (arg.CurrentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
			{
				arg.CurrentWeapon.special.SpecialMode = false;
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 65);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			}
			return true;
		}
		if (!arg.Cmd.IsAttackOn || arg.CurrentWeapon.power.Power == 0)
		{
			arg.CurrentWeapon.special.SpecialMode = false;
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 65);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + knifeWeaponInfo.SlashStabTime;
			return true;
		}
		if (_lastAttackTime == 0)
		{
			_lastAttackTime = arg.ClientTime;
			return true;
		}
		if (arg.ClientTime - _lastAttackTime > 100)
		{
			_lastAttackTime = arg.ClientTime;
			float shotDistance = knifeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			AttackImmed(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		}
		return true;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return false;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		return 0;
	}
}

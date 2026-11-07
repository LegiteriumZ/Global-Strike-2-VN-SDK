using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiderSlingShotPredicationSystem : SlingShotPredicationSystem
{
	internal class RiderSlingShotRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
	{
		public RiderSlingShotRightAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
			AddFire(SetAttackAnim);
			AddFire(OnFire);
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + base.AttackInterval);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, base.ViewAnimId);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
			if (arg.CurrentWeapon.attach.Data is RiderSwordAttach riderSwordAttach)
			{
				riderSwordAttach.AddKnifeSpeed(arg.Player, arg.CurrentWeapon, 20);
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
			{
				return WeaponUtility.CanSecondaryAttack(ref arg);
			}
			return false;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			IRifleMeleeWeaponInfo obj = arg.CurrentWeapon.basicInfo.Info as IRifleMeleeWeaponInfo;
			float shotDistance = obj.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			int delayAttackStabTime = obj.DelayAttackStabTime;
			RiderSwordAttach riderSwordAttach = arg.CurrentWeapon.attach.Data as RiderSwordAttach;
			KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, shotDistance, (int)((float)delayAttackStabTime / riderSwordAttach.KnifeSpeed), null);
			FireUtility.PlaySecFireSound(ref arg);
			return 0;
		}
	}

	public RiderSlingShotPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RightActions.Add(new RiderSlingShotRightAction(contexts));
	}
}

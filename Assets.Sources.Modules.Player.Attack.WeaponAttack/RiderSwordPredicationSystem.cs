using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiderSwordPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RiderSwordLeftAction : KnifeLeftAction
	{
		public RiderSwordLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			int num;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				num = 29;
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			else
			{
				num = 31;
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetViewAnimation(arg.Player, num);
			(arg.CurrentWeapon.attach.Data as RiderSwordAttach).AddKnifeSpeed(arg.Player, arg.CurrentWeapon, num);
			return 0;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			KnifeWeaponInfo obj = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			int delayAttackSlashTime = obj.DelayAttackSlashTime;
			RiderSwordAttach riderSwordAttach = arg.CurrentWeapon.attach.Data as RiderSwordAttach;
			KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, shotDistance, (int)((float)delayAttackSlashTime / riderSwordAttach.KnifeSpeed), FireUtility.PlaySecFireSound);
			return 0;
		}
	}

	internal class RiderSwordRightAction : KnifeRightAction
	{
		public RiderSwordRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			base.SetAttackAnim(ref arg);
			(arg.CurrentWeapon.attach.Data as RiderSwordAttach).AddKnifeSpeed(arg.Player, arg.CurrentWeapon, 20);
			return 0;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			KnifeWeaponInfo obj = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			int delayAttackStabTime = obj.DelayAttackStabTime;
			RiderSwordAttach riderSwordAttach = arg.CurrentWeapon.attach.Data as RiderSwordAttach;
			KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, shotDistance, (int)((float)delayAttackStabTime / riderSwordAttach.KnifeSpeed), FireUtility.PlaySecFireSound);
			return 0;
		}
	}

	public RiderSwordPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RiderSwordLeftAction(contexts));
		RightActions.Add(new RiderSwordRightAction(contexts));
	}
}

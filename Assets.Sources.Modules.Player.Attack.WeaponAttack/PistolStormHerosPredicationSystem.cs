using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolStormHerosPredicationSystem : AbstractAttackPredicationSystem
{
	internal class StormHerosLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public StormHerosLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.PostolFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.DoubleLeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.LeftFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (base.CanFire(ref arg))
			{
				return arg.CurrentWeapon.attack.ShotsFired < 1;
			}
			return false;
		}
	}

	internal class StormHerosRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		private MessageContext _messageContext;

		public StormHerosRightAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireNextSecAttack);
			AddFire(FireUtility.PlaySecFireSound);
			AddFire(FireUtility.RightFireQkhhAfterFire);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power < arg.CurrentWeapon.power.MaxPower && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("StormheroesNoenergyFire"));
				NotifyManager.ForceInvoke(38);
			}
			return arg.CurrentWeapon.power.Power >= arg.CurrentWeapon.power.MaxPower;
		}

		public static int FireNextSecAttack(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 3000);
			return 0;
		}
	}

	public PistolStormHerosPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new StormHerosLeftAction(contexts));
		RightActions.Add(new StormHerosRightAction(contexts));
	}
}

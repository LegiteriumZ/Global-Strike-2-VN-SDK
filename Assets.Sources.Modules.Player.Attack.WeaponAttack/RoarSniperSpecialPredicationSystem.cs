using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RoarSniperSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RoarSniperSpecialLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public RoarSniperSpecialLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireNoDescClipWhenUpSpeed);
			AddFire(FireUtility.LeftFireSpecialSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlaySecFireSound);
		}
	}

	public RoarSniperSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RoarSniperSpecialLeftAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new GhostTwinsSwitchAction(contexts));
	}
}

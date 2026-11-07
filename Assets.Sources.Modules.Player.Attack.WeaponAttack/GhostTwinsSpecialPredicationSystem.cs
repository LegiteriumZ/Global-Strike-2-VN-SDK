using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GhostTwinsSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	internal class GhostTwinsSpecialLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public GhostTwinsSpecialLeftAction(Contexts contexts)
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

	public GhostTwinsSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new GhostTwinsSpecialLeftAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AngerFireScarSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	internal class AngerFireScarSpecialLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public AngerFireScarSpecialLeftAction(Contexts contexts)
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
			AddFire(FireUtility.PlayFireSound);
		}
	}

	public AngerFireScarSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new AngerFireScarSpecialLeftAction(contexts));
		FrameActions.Add(new AngerFireScarSwitchAction(contexts));
	}
}

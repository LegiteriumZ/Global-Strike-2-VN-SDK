using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

public class RifleLeftSpecialAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public RifleLeftSpecialAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSpecialSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}
}

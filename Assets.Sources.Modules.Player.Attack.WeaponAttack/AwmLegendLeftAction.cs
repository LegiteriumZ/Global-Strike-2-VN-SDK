using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwmLegendLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public AwmLegendLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(setFired);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int setFired(ref CommonWeaponArg arg)
	{
		int index = 2;
		if (arg.CurrentWeapon.GetComponent(index) is AttachComponent { Data: AwmLegendAttach data })
		{
			data.isFire = true;
		}
		return 0;
	}
}

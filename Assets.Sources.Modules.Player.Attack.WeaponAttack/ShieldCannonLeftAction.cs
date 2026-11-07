using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShieldCannonLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public ShieldCannonLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		return 0;
	}
}

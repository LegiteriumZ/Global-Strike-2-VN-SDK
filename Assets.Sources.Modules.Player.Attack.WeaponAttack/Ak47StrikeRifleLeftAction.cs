using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using data;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47StrikeRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public Ak47StrikeRifleLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int FireSetSpread(ref CommonWeaponArg arg)
	{
		bool isWeightlessness = (Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() as SceneMoveData).isWeightlessness;
		BeforeFire(ref arg.CurrentWeapon.spread.Spread, arg.Player, arg.CurrentWeapon, isWeightlessness);
		return 0;
	}

	public static void BeforeFire(ref float spread, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		float num = ((player.OnGround() || isWeightlessness) ? (0.02f * (1f - (float)currentWeapon.power.Power2 * 1f / 1000f)) : ((currentWeapon.clip.Clip2 == 0) ? (0.44f * (1f - (float)currentWeapon.power.Power2 * 1f / 1000f)) : (0.02f * (1f - (float)currentWeapon.power.Power2 * 1f / 1000f))));
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}

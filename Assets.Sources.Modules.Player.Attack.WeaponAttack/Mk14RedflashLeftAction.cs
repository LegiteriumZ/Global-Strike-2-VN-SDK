using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mk14RedflashLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public Mk14RedflashLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private bool CheckFireState(WeaponEntity currentWeapon, int clientTime)
	{
		int raceType = GameModelLocator.GetInstance().GameModel.RoomData.RaceType;
		if (CheckRuleAndState(currentWeapon, raceType))
		{
			if (currentWeapon.power.Power >= currentWeapon.power.RpgMaxPower)
			{
				return clientTime < currentWeapon.basicInfo.Data.NextSkillTimer;
			}
			return true;
		}
		return currentWeapon.clip.Clip == 0;
	}

	private bool CheckRuleAndState(WeaponEntity currentWeapon, int raceType)
	{
		if (RuleUtilty.IsGeneralPve(raceType))
		{
			return currentWeapon.special.SpecialMode;
		}
		return false;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return !CheckFireState(arg.CurrentWeapon, arg.ClientTime);
		}
		return false;
	}

	private static int FireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

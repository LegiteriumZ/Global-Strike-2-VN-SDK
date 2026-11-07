using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Player.Attack.WeaponRaise;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GlockRedflashLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public GlockRedflashLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(SetAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.DebugAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int SetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, GlockRedflashRaisePrediactionSystem.GetLongClipMod(arg.CurrentWeapon) ? 40 : 15);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	private int SetNextAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 355);
			arg.CurrentWeapon.power.Power = 3;
		}
		else
		{
			FireUtility.FireNextAttack(ref arg);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.basicInfo.Data.ShotsFired < 1;
		}
		return false;
	}
}

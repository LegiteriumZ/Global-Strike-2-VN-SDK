using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LightStarKnifeRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public LightStarKnifeRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.PlaySecFireSound);
		AddAction(HitPlayer);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabStabTime);
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabSlashTime);
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo) || RuleUtilty.IsGeneralPve(raceType) || RuleUtilty.IsPveModel(raceType))
		{
			return false;
		}
		if (!WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return false;
		}
		return true;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		_ = arg.Cmd.PredicatedOnce;
		return 0;
	}

	protected int HitPlayer(ref HitPlayerArgs arg)
	{
		arg.currentWeapon.attack.NextAttackTimer += 100f;
		arg.currentWeapon.attack.NextSecondaryAttackTimer += 100f;
		return 0;
	}
}

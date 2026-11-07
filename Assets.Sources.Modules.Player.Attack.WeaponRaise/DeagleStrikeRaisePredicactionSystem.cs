using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class DeagleStrikeRaisePredicactionSystem : AbstractRaisePredicactionSystem
{
	private DeagleStrikePredicationSystem.DeagleStrikeMeleeRightAction _action;

	public DeagleStrikeRaisePredicactionSystem(Contexts contexts)
		: base(contexts)
	{
		_action = new DeagleStrikePredicationSystem.DeagleStrikeMeleeRightAction(contexts);
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if ((currentWeapon.special.EffectLevel & 8) > 0)
		{
			return 170;
		}
		return 16;
	}

	protected override void SetRaiseAnim(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		currentWeapon.special.SpecialMode = false;
		float shotDistance = (currentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(cmd, currentWeapon, isMelee: true);
		SetNewAttackAnim(player, cmd, currentWeapon);
		CommonWeaponArg arg = default(CommonWeaponArg);
		arg.CurrentWeapon = currentWeapon;
		arg.Player = player;
		arg.ClientTime = player.clientTime.ClientTime;
		arg.Cmd = cmd;
		arg.Contexts = Contexts.sharedInstance;
		_action.KnifeFire(ref arg, cmd.Seq, shotDistance + (float)currentWeapon.power.MaxPower2, null);
		FireUtility.ForcePlaySecFireSound(ref arg);
	}

	protected void SetNewAttackAnim(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if ((currentWeapon.special.EffectLevel & 8) > 0)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 170);
			PlayerAnimationUtility.SetTorseAnimation(player, 170);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(player, 16);
			PlayerAnimationUtility.SetTorseAnimation(player, 16);
		}
	}
}

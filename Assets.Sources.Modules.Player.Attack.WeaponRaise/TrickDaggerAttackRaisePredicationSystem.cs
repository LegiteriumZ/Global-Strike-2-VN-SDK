using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class TrickDaggerAttackRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public static readonly int COMPONENT4_EXIST = 16;

	public static readonly int SPECIAL_RAISE_ANIM_TIME = 800;

	public static readonly int SPECIAL_RAISE = 47;

	private readonly TrickDaggerPredicationSystem.TrickDaggerRightAction _action;

	public TrickDaggerAttackRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_action = new TrickDaggerPredicationSystem.TrickDaggerRightAction(contexts, raise: true);
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (!isComponent4(currentWeapon))
		{
			return 16;
		}
		return SPECIAL_RAISE;
	}

	protected override void setTorsoRaiseAnim(PlayerEntity player, int animId, WeaponEntity currentWeapon)
	{
		if (isComponent4(currentWeapon))
		{
			PlayerAnimationUtility.SetTorseAnimation(player, 15);
		}
		else
		{
			PlayerAnimationUtility.SetTorseAnimation(player, animId);
		}
	}

	protected override void setViewRaiseAnim(PlayerEntity player, int animId, WeaponEntity currentWeapon)
	{
		if (isComponent4(currentWeapon))
		{
			PlayerAnimationUtility.SetViewAnimation(player, animId, 1f + TrickDaggerPredicationSystem.GetTrickAttackSpeed(currentWeapon));
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(player, animId);
		}
	}

	protected override void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		float shotDistance = currentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(cmd, currentWeapon, isMelee: true);
		base.RaiseAction(player, currentWeapon, lastWeapon, cmd);
		if (isComponent4(currentWeapon))
		{
			_ = currentWeapon.basicInfo.Info;
			currentWeapon.attack.NextAttackTimer = (uint)((float)player.clientTime.ClientTime + (float)SPECIAL_RAISE_ANIM_TIME * (1f - TrickDaggerPredicationSystem.GetTrickAttackSpeed(currentWeapon)));
			currentWeapon.attack.NextSecondaryAttackTimer = currentWeapon.attack.NextAttackTimer;
			CommonWeaponArg commonWeaponArg = default(CommonWeaponArg);
			commonWeaponArg.CurrentWeapon = currentWeapon;
			commonWeaponArg.Player = player;
			commonWeaponArg.ClientTime = player.clientTime.ClientTime;
			commonWeaponArg.Cmd = cmd;
			commonWeaponArg.Contexts = Contexts.sharedInstance;
			CommonWeaponArg arg = commonWeaponArg;
			_action.KnifeFire(ref arg, cmd.Seq, shotDistance, null);
		}
	}

	public bool isComponent4(WeaponEntity currentWeaponEntity)
	{
		return (currentWeaponEntity.special.EffectLevel & COMPONENT4_EXIST) > 0;
	}
}

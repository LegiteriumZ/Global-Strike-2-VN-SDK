using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class AttackRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	private readonly RifleMeleeRaiseAttackRightAction _action;

	public AttackRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
		_action = new RifleMeleeRaiseAttackRightAction(contexts);
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		float shotDistance = currentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(cmd, currentWeapon, isMelee: true);
		base.RaiseAction(player, currentWeapon, lastWeapon, cmd);
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

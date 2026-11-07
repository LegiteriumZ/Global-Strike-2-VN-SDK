using Assets.Generated.Table;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Singleton;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class BlinkShadowRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	private readonly RifleMeleeRaiseAttackRightAction _action;

	public BlinkShadowRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_action = new RifleMeleeRaiseAttackRightAction(contexts);
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if ((currentWeapon.basicInfo.Data.EffectLevel & 2) > 0)
		{
			return 20;
		}
		return 16;
	}

	protected override void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		if ((currentWeapon.basicInfo.Data.EffectLevel & 2) > 0)
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
			PlaySecFireSound(ref arg);
		}
		else
		{
			base.RaiseAction(player, currentWeapon, lastWeapon, cmd);
		}
	}

	public static int PlaySecFireSound(ref CommonWeaponArg arg)
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		return 0;
	}
}

using Assets.Generated.Table;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolFrozenAirFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	public PistolFrozenAirFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsAttackOn && arg.CurrentWeapon.clip.Clip > 0 && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 16))
		{
			desClipPer(ref arg, arg.Player, arg.CurrentWeapon);
		}
		return true;
	}

	private void desClipPer(ref CommonWeaponArg arg, PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.clientTime.ClientTime > currentWeapon.power.RpgMaxPower)
		{
			currentWeapon.power.RpgMaxPower = player.clientTime.ClientTime + 100;
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself: true, SoundResourceUtility.GetWeaponSoundFireAssetInfo(currentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
			WeaponUtility.DescClip(currentWeapon);
			FireUtility.RightFireQkhhAfterFire(ref arg);
		}
	}
}

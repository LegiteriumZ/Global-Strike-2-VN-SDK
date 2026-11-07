using Assets.Generated.Table;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TmpLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public TmpLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(PlayFireSound);
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 41 : 40);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public int PlayFireSound(ref CommonWeaponArg arg)
	{
		this.DebugFormat("arg.clientTime:{0},{1}", arg.ClientTime, arg.CurrentWeapon.attack.NextAttackTimer);
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, (!arg.CurrentWeapon.special.SpecialMode) ? SoundResourceUtility.GetWeaponSoundFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName) : SoundResourceUtility.GetWeaponSoundFire3AssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		return 0;
	}
}

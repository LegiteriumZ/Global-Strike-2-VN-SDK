using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class FireAction : IWeaponAction
{
	private GunFireCell _cell;

	public FireAction(Contexts contexts)
	{
		_cell = new GunFireCell(contexts);
		_cell.AddAction(HitUtility.BulletHiPlayerAction);
		_cell.AddAction(HitUtility.BulletHitWorldAction);
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (!arg.Cmd.PredicatedOnce)
		{
			_cell.GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			FireUtility.PlayFireSound(ref arg);
		}
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}

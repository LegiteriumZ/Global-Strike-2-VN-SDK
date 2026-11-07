using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class WeaponAction
{
	private bool _exced;

	private int _nextExced;

	private GunFireCell _cell;

	public WeaponAction(Contexts contexts, int nextExced)
	{
		_nextExced = nextExced;
		_cell = new GunFireCell(contexts);
		_cell.AddAction(HitUtility.BulletHiPlayerAction);
		_cell.AddAction(HitUtility.BulletHitWorldAction);
	}

	public void WeaponLogic(ref CommonWeaponArg arg)
	{
		UserCmd userCmd = arg.Cmd as UserCmd;
		if (!_exced && userCmd.RenderTime >= _nextExced)
		{
			_exced = true;
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			if (!arg.Cmd.PredicatedOnce)
			{
				_cell.GunFire(ref arg, arg.Cmd.Seq, shotDistance);
				FireUtility.PlayFireSound(ref arg);
			}
		}
	}

	public bool CanRemove()
	{
		return _exced;
	}
}

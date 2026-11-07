using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DaggerBulletBursterFrameAction : AbstractFrameAction
{
	private readonly GunFireCell _gunFireCell;

	private readonly int[] _bulletNums1 = new int[3] { 4, 6, 12 };

	private readonly int[] _bulletNums2 = new int[3] { 3, 6, 10 };

	public DaggerBulletBursterFrameAction(Contexts contexts)
		: base(contexts)
	{
		_gunFireCell = new GunFireCell(contexts);
		_gunFireCell.AddAction(HitUtility.BulletHiPlayerAction);
		_gunFireCell.AddAction(HitUtility.BulletHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Clip2 != 0 && arg.Player.viewAnim.ViewAnimInfo.StateId != 170 && arg.Player.viewAnim.ViewAnimInfo.StateId != 172 && arg.Player.viewAnim.ViewAnimInfo.StateId != 174 && arg.Player.viewAnim.ViewAnimInfo.StateId != 176 && arg.Player.viewAnim.ViewAnimInfo.StateId != 28)
		{
			arg.CurrentWeapon.basicInfo.Data.Clip2 = 0;
		}
		if (arg.CurrentWeapon.basicInfo.Data.Clip2 != 0)
		{
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId);
			int num = 300;
			int weaponStage = GetWeaponStage(arg.CurrentWeapon.basicInfo.Data.WeaponName);
			if (arg.CurrentWeapon.basicInfo.Data.Clip2 == 2)
			{
				num = 600;
			}
			int num2 = ((arg.CurrentWeapon.basicInfo.Data.Clip2 == 2) ? _bulletNums2[weaponStage] : _bulletNums1[weaponStage]);
			if (viewAnimDuration - arg.Player.viewAnim.RemainTime >= num)
			{
				arg.CurrentWeapon.spread.Spread = 0.06f;
				arg.CurrentWeapon.basicInfo.Data.Clip2 = 0;
				if (arg.CurrentWeapon.power.Power2 == 0)
				{
					int seq = arg.Cmd.Seq;
					for (int i = 0; i < num2; i++)
					{
						_gunFireCell.GunFire(ref arg, seq + i, 20000f);
					}
					FireUtility.RightFireQkhhAfterFire(ref arg);
				}
			}
		}
		return true;
	}

	private int GetWeaponStage(string weaponName)
	{
		if (weaponName.EndsWith("2"))
		{
			return 2;
		}
		if (weaponName.EndsWith("1"))
		{
			return 1;
		}
		return 0;
	}
}

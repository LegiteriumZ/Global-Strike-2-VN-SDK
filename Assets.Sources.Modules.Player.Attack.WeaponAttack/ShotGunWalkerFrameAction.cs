using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunWalkerFrameAction : AbstractFrameAction
{
	private readonly int[] _corrosionPow = new int[5] { 30, 70, 120, 170, 230 };

	private int _baseAttackInterval = 350;

	public ShotGunWalkerFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (base.Action(ref arg) && arg.Cmd.IsShowGun && !arg.Player.viewAnim.Equals(44))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
		UpdateBufferData(ref arg);
		return true;
	}

	private void UpdateBufferData(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.MaxPower2 != 0)
		{
			if (arg.CurrentWeapon.power.Power < _corrosionPow[0] && arg.CurrentWeapon.power.Power2 != 0)
			{
				arg.CurrentWeapon.power.Power2 = 0;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = _baseAttackInterval;
			}
			else if (arg.CurrentWeapon.power.Power >= _corrosionPow[0] && arg.CurrentWeapon.power.Power < _corrosionPow[1] && arg.CurrentWeapon.power.Power2 != 1)
			{
				arg.CurrentWeapon.power.Power2 = 1;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((float)_baseAttackInterval * 0.9f);
			}
			else if (arg.CurrentWeapon.power.Power >= _corrosionPow[1] && arg.CurrentWeapon.power.Power < _corrosionPow[2] && arg.CurrentWeapon.power.Power2 != 2)
			{
				arg.CurrentWeapon.power.Power2 = 2;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((float)_baseAttackInterval * 0.9f);
			}
			else if (arg.CurrentWeapon.power.Power >= _corrosionPow[2] && arg.CurrentWeapon.power.Power < _corrosionPow[3] && arg.CurrentWeapon.power.Power2 != 3)
			{
				arg.CurrentWeapon.power.Power2 = 3;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((float)_baseAttackInterval * 0.9f);
			}
			else if (arg.CurrentWeapon.power.Power >= _corrosionPow[3] && arg.CurrentWeapon.power.Power < _corrosionPow[4] && arg.CurrentWeapon.power.Power2 != 4)
			{
				arg.CurrentWeapon.power.Power2 = 4;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((float)_baseAttackInterval * 0.8f);
			}
			else if (arg.CurrentWeapon.power.Power == _corrosionPow[4] && arg.CurrentWeapon.power.Power2 != 5)
			{
				arg.CurrentWeapon.power.Power2 = 5;
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((float)_baseAttackInterval * 0.8f);
			}
		}
	}
}

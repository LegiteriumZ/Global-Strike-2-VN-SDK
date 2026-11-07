using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleMeleeRaiseAttackRightAction : RifleMeleeRightAction
{
	public RifleMeleeRaiseAttackRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		if (arg.Player.viewAnim.Equals(31) || arg.Player.viewAnim.Equals(170) || arg.Player.viewAnim.Equals(172) || arg.Player.viewAnim.Equals(174) || arg.Player.viewAnim.Equals(176) || arg.Player.viewAnim.Equals(69) || arg.Player.viewAnim.Equals(15) || arg.Player.viewAnim.Equals(40))
		{
			return GetDelayAttackSlashTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(72) || arg.Player.viewAnim.Equals(124) || arg.Player.viewAnim.Equals(122) || arg.Player.viewAnim.Equals(126))
		{
			return GetDelayAttackStabTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(199) || arg.Player.viewAnim.Equals(200) || arg.Player.viewAnim.Equals(201) || arg.Player.viewAnim.Equals(71))
		{
			int delayAttackSlashTime = GetDelayAttackSlashTime2(ref arg);
			if (delayAttackSlashTime > 0)
			{
				return delayAttackSlashTime;
			}
			return GetDelayAttackSlashTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(16))
		{
			string name = arg.CurrentWeapon.basicInfo.Info.Name;
			if (!string.IsNullOrEmpty(name))
			{
				if (name.Equals("ghost_rider") || name.Equals("ghost_rider1"))
				{
					return 495;
				}
				if (name.Equals("blink_shadow"))
				{
					return 500;
				}
			}
			return 300;
		}
		return 0;
	}
}

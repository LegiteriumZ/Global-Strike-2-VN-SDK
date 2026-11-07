using Assets.Sources.Info.Weapon.Logic.SpreadLogic;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MiniDeathFrameAction : IFrameCmdAction, ICmdAction
{
	private const float SpeedRate = 0.045f;

	private const int Stage1Interval = 120;

	private const float Stage1Accuracy = 0.04f;

	public float AccurcyRate { get; protected set; }

	public MiniDeathFrameAction(Contexts contexts)
	{
		AccurcyRate = 2E-05f;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.EffectLevel == 0)
		{
			ResetInfo(arg.CurrentWeapon);
		}
		else
		{
			int num = ((arg.CurrentWeapon.special.EffectLevel == 1) ? (-1) : 0);
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)(120f - 0.045f * (float)(arg.CurrentWeapon.special.EffectLevel + num));
			if (arg.CurrentWeapon.basicInfo.Info.SpreadLogic is MiniDeathSpreadLogic miniDeathSpreadLogic)
			{
				miniDeathSpreadLogic.DefaultParam = 0.04f - AccurcyRate * (float)(arg.CurrentWeapon.special.EffectLevel + num);
			}
		}
		return true;
	}

	private static void ResetInfo(WeaponEntity currentWeapon)
	{
		currentWeapon.basicInfo.Info.AttackInterval = 120;
		if (currentWeapon.basicInfo.Info.SpreadLogic is MiniDeathSpreadLogic miniDeathSpreadLogic)
		{
			miniDeathSpreadLogic.DefaultParam = 0.04f;
		}
	}
}

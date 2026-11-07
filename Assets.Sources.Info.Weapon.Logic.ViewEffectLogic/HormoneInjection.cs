using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class HormoneInjection : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetAllParticleVisiable(player, CheckIsInJection(player, currentWeapon, raceType));
	}

	private bool CheckIsInJection(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
		{
			if (currentWeapon.hasPower && currentWeapon.power.Power > 0)
			{
				return true;
			}
			return false;
		}
		if (currentWeapon.basicInfo.Data.NextSkillTimer - player.clientTime.ClientTime <= 0)
		{
			if (RuleUtilty.IsGeneralPve(raceType))
			{
				if (1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() > (float)currentWeapon.power.MaxPower)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}

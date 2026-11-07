using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

public class TwinsInfiniteMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int normal;

	internal int special;

	internal int specialTwo;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (TwinsInfinitePredicationSystem.isSkillOn(currentWeapon))
		{
			if (RuleUtilty.IsBioMode(UiIEventCondition.Get_uiRoomData_RaceType()))
			{
				return specialTwo;
			}
			return special;
		}
		return normal;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 3);
		special = restlts[0];
		specialTwo = restlts[1];
		normal = restlts[2];
	}
}

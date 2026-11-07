using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MetalStormFrameAction : IFrameCmdAction, ICmdAction
{
	private bool _isRuleSet;

	public MetalStormFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		BaseWeaponData data = arg.CurrentWeapon.basicInfo.Data;
		if (!_isRuleSet)
		{
			if (RuleUtilty.IsGeneralPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
			{
				data.Clip = 300;
				data.Clip2 = 300;
				data.CarryClip = 300;
				data.CarryClip2 = 300;
			}
			_isRuleSet = true;
		}
		return true;
	}
}

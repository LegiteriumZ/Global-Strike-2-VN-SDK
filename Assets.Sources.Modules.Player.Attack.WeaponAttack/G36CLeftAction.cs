using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G36CLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly G36CSkillLeftAction _g36CSkillLeftAction;

	private readonly G36CNormalLeftAction _g36CNormalLeftAction;

	public G36CLeftAction(Contexts contexts)
	{
		_g36CSkillLeftAction = new G36CSkillLeftAction(contexts);
		_g36CNormalLeftAction = new G36CNormalLeftAction(contexts);
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 0)
		{
			return _g36CNormalLeftAction.Action(ref arg);
		}
		return _g36CSkillLeftAction.Action(ref arg);
	}
}

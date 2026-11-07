using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G36CSpecialLeftAction : ILeftCmdAction, ICmdAction
{
	private G36CSpecialNormalLeftAction g36CSpecialNormalLeftAction;

	private G36CSpecialSkillLeftAction g36CSpecialSkillLeftAction;

	public G36CSpecialLeftAction(Contexts contexts)
	{
		g36CSpecialSkillLeftAction = new G36CSpecialSkillLeftAction(contexts);
		g36CSpecialNormalLeftAction = new G36CSpecialNormalLeftAction(contexts);
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 0)
		{
			return g36CSpecialNormalLeftAction.Action(ref arg);
		}
		return g36CSpecialSkillLeftAction.Action(ref arg);
	}
}

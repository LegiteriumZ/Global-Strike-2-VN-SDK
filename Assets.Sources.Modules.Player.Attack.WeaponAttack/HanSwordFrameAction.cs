using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HanSwordFrameAction : AbstractFrameAction
{
	public HanSwordFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (base.Action(ref arg))
		{
			bool or = arg.Player.viewAnim.Equals(199) || arg.Player.viewAnim.Equals(200);
			SetEffectLv(ref arg, or, HanSwordKnifeRightAction.SKILL_EFFECT);
			SetEffectLv(ref arg, !HanSwordKnifeRightAction.IsSpecialEffectByShifNumber(arg.CurrentWeapon, HanSwordKnifeRightAction.SKILL_FA_GUANG), HanSwordKnifeRightAction.SKILL_NORMAL_EFFECT);
			return true;
		}
		return false;
	}

	private void SetEffectLv(ref CommonWeaponArg arg, bool or, int value)
	{
		if (or)
		{
			arg.CurrentWeapon.special.EffectLevel |= 1 << value;
		}
		else
		{
			arg.CurrentWeapon.special.EffectLevel &= ~(1 << value);
		}
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SlimeGunRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	private MessageContext _messageContext;

	public SlimeGunRightAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireNextSecAttack);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power > 0)
		{
			return (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		}
		return false;
	}

	public static int FireNextSecAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		return 0;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleScytheRightAction : KnifeRightAction
{
	public DoubleScytheRightAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(IsAttackOn);
		AddFire(base.CanFireInt);
		AddFire(DoubleScytheSetAttackAnim);
		AddFire(DoubleScytheSetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected int DoubleScytheSetNextAttack(ref CommonWeaponArg arg)
	{
		SetNextAttack(ref arg);
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer += 300f;
			arg.CurrentWeapon.attack.NextAttackTimer += 300f;
		}
		return 0;
	}

	protected int DoubleScytheSetAttackAnim(ref CommonWeaponArg arg)
	{
		int animId = (arg.CurrentWeapon.special.SpecialMode ? 40 : 15);
		int animId2 = (arg.CurrentWeapon.special.SpecialMode ? 72 : 20);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, animId2);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, animId);
		return 0;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleScytheLeftAction : KnifeLeftAction
{
	public DoubleScytheLeftAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(IsAttackOn);
		AddFire(base.CanFireInt);
		AddFire(DoubleScytheSetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected int DoubleScytheSetAttackAnim(ref CommonWeaponArg arg)
	{
		int animId = (arg.CurrentWeapon.special.SpecialMode ? 40 : 15);
		PlayerAnimationUtility.SetViewAnimation(animId: (!WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime)) ? (arg.CurrentWeapon.special.SpecialMode ? 71 : 29) : (arg.CurrentWeapon.special.SpecialMode ? 69 : 31), player: arg.Player);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, animId);
		return 0;
	}
}

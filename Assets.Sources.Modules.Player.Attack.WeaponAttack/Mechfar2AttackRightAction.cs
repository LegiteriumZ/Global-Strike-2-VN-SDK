using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mechfar2AttackRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public Mechfar2AttackRightAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitWorldAction);
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 600;
		FireUtility.PlayFireSound(ref arg);
		return 0;
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GoldSnakeKnifeRightAction : KnifeRightAction
{
	public GoldSnakeKnifeRightAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(IsAttackOn);
		AddFire(base.CanFireInt);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(SetPowerAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected int SetPowerAttack(ref CommonWeaponArg arg)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType) || arg.CurrentWeapon.power.Power >= arg.CurrentWeapon.power.MaxPower)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			arg.CurrentWeapon.power.Power = 0;
		}
		return 0;
	}
}

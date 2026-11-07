using System.Collections.Generic;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwakeClawLeftAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	private readonly WeaponKnifeAttackAction[] _weaponKnifeAttacks;

	private readonly Dictionary<int, int[]> _attackDelayTimer = new Dictionary<int, int[]>();

	private readonly int[] _delayTimer = new int[2] { 45, 90 };

	private readonly int[] _delayTimer1 = new int[2] { 45, 90 };

	private readonly int[] _delayTimer2 = new int[2] { 100, 200 };

	private bool _isAttack;

	private int _delayAttackTime;

	public AwakeClawLeftAction(Contexts contexts)
		: base(contexts)
	{
		Reset();
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(IsAttackOn);
		AddFire(base.CanFireInt);
		AddAction(HitPlayer);
		AddAction(KnifeHit);
		_weaponKnifeAttacks = new WeaponKnifeAttackAction[3]
		{
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(-1).SetNextKnifeAttackAnim(31).SetNextKnifeAttackRaise(30)
				.SetDelayAttackTime(135),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(30).SetNextKnifeAttackAnim(170).SetNextKnifeAttackRaise(169)
				.SetDelayAttackTime(135),
			new WeaponKnifeAttackAction().SetCurrentAttackRaise(169).SetNextKnifeAttackAnim(172).SetNextKnifeAttackRaise(171)
				.SetDelayAttackTime(300)
		};
		_attackDelayTimer.Add(31, _delayTimer);
		_attackDelayTimer.Add(170, _delayTimer1);
		_attackDelayTimer.Add(172, _delayTimer2);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		KnifeLogic(ref arg);
		KnifeMarkLogic(ref arg);
		return true;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return true;
	}

	private void KnifeLogic(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsAttackOn || arg.CurrentWeapon.hasDelayAttack)
		{
			return;
		}
		for (int i = 0; i < _weaponKnifeAttacks.Length; i++)
		{
			WeaponKnifeAttackAction obj = _weaponKnifeAttacks[i];
			bool canNextAttack = true;
			if (i == 0)
			{
				canNextAttack = (float)arg.ClientTime >= arg.CurrentWeapon.attack.NextAttackTimer && !arg.CurrentWeapon.special.SpecialMode;
			}
			obj.SetCanNextAttack(canNextAttack);
			if (obj.KnifeLogic(ref arg))
			{
				_isAttack = true;
				int[] array = _attackDelayTimer[arg.Player.viewAnim.ViewAnimInfo.StateId];
				_delayAttackTime = array[0];
				OnFire(ref arg);
				break;
			}
		}
	}

	private void KnifeMarkLogic(ref CommonWeaponArg arg)
	{
		if (_attackDelayTimer.ContainsKey(arg.Player.viewAnim.ViewAnimInfo.StateId) && _isAttack && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime >= _delayAttackTime)
		{
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			_isAttack = false;
			KnifeHoleFire(arg.Player, arg.CurrentWeapon, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound, arg.Cmd);
		}
	}

	protected int KnifeHit(ref CommonWeaponArg arg)
	{
		if (_attackDelayTimer.ContainsKey(arg.Player.viewAnim.ViewAnimInfo.StateId))
		{
			int[] array = _attackDelayTimer[arg.Player.viewAnim.ViewAnimInfo.StateId];
			if (array != null)
			{
				if (_delayAttackTime < array[1])
				{
					_isAttack = true;
				}
				_delayAttackTime = array[1];
			}
		}
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
		{
			float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		}
		return 0;
	}

	protected int HitPlayer(ref HitPlayerArgs arg)
	{
		arg.currentWeapon.attack.NextAttackTimer += 50f;
		return 0;
	}
}

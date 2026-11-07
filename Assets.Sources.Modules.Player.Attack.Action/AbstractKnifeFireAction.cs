using System.Collections.Generic;
using Assets.Sources.Components.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Player.Chain;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJPhysics;
using SSJJUserCmd;
using Sources.Modules.Player.Chain;
using share;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal abstract class AbstractKnifeFireAction : IIdleCmdAction, ICmdAction
{
	private static readonly float[] Mins = new float[3] { -40f, -40f, -45f };

	private static readonly float[] Maxs = new float[3] { 40f, 40f, 45f };

	protected readonly Contexts Contexts;

	private Vector3D _endPos = new Vector3D();

	private Vector3D _normal = new Vector3D();

	private Vector3D _start = new Vector3D();

	private WeaponChain<HitPlayerArgs> _hitplayers;

	private WeaponChain<HitWorldArgs> _hitWorlds;

	private WeaponChain<CommonWeaponArg> _knifeHits;

	private WeaponChain<CommonWeaponArg> _onFireFunc;

	private int _attackInterval = 1000;

	private int _viewAnimId = 20;

	protected internal WeaponChain<CommonWeaponArg> OnFireFunc => _onFireFunc;

	protected internal WeaponChain<CommonWeaponArg> KnifeHits => _knifeHits;

	protected internal WeaponChain<HitWorldArgs> HitWorlds => _hitWorlds;

	protected internal WeaponChain<HitPlayerArgs> HitPlayers => _hitplayers;

	public int AttackInterval
	{
		get
		{
			return _attackInterval;
		}
		set
		{
			_attackInterval = value;
		}
	}

	public int DelayAttackStabTimeSet { get; set; }

	public int ViewAnimId
	{
		get
		{
			return _viewAnimId;
		}
		set
		{
			_viewAnimId = value;
		}
	}

	public AbstractKnifeFireAction(Contexts contexts)
	{
		Contexts = contexts;
		_hitplayers = new WeaponChain<HitPlayerArgs>(2);
		_hitWorlds = new WeaponChain<HitWorldArgs>(2);
		_onFireFunc = new WeaponChain<CommonWeaponArg>(2);
		_knifeHits = new WeaponChain<CommonWeaponArg>(2);
		_onFireFunc.AddChain((WeaponFireChain)IsAttackOn);
		_onFireFunc.AddChain((WeaponFireChain)CanFireInt);
	}

	protected int CanFireInt(ref CommonWeaponArg arg)
	{
		if (!CanFire(ref arg))
		{
			return 1;
		}
		return 0;
	}

	protected virtual int IsAttackOn(ref CommonWeaponArg arg)
	{
		if (this is ILeftCmdAction)
		{
			if (arg.Cmd.IsAttackOn)
			{
				return 0;
			}
		}
		else if (this is IRightCmdAction && arg.Cmd.IsSecondaryAttackOn)
		{
			return 0;
		}
		return -1;
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		_onFireFunc.Step(ref arg);
		return true;
	}

	protected void Reset()
	{
		_hitplayers.Reset();
		_hitWorlds.Reset();
		_onFireFunc.Reset();
		_knifeHits.Reset();
	}

	protected void AddAction(HitPlayerAction trueChain)
	{
		_hitplayers.AddChain((WeaponHitPlayerChain)trueChain);
	}

	protected void AddAction(HitWorldAction trueChain)
	{
		_hitWorlds.AddChain((WeaponHitWorldChain)trueChain);
	}

	protected void AddAction(KnifeHitAction trueChain)
	{
		_knifeHits.AddChain((WeaponKnifeChain)trueChain);
	}

	protected void AddFire(FireUtility.FireFunc trueChain)
	{
		_onFireFunc.AddChain((WeaponFireChain)trueChain);
	}

	protected virtual bool CanFire(ref CommonWeaponArg arg)
	{
		return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
	}

	protected abstract int OnFire(ref CommonWeaponArg arg);

	public int GetDelayAttackSlashTime(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackSlashTime;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackSlashTime;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackSlashTime;
		}
		return 0;
	}

	public int GetDelayAttackStabTime(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackStabTime;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackStabTime;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackStabTime;
		}
		return 0;
	}

	public int GetDelayAttackSlashTime2(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackSlashTime2;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackSlashTime2;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			return (arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackSlashTime2;
		}
		return 0;
	}

	protected virtual int GetDelayTime(ref CommonWeaponArg arg)
	{
		if (arg.Player.viewAnim.Equals(31) || arg.Player.viewAnim.Equals(170) || arg.Player.viewAnim.Equals(172) || arg.Player.viewAnim.Equals(174) || arg.Player.viewAnim.Equals(176) || arg.Player.viewAnim.Equals(69) || arg.Player.viewAnim.Equals(234) || arg.Player.viewAnim.Equals(236) || arg.Player.viewAnim.Equals(238) || arg.Player.viewAnim.Equals(240) || arg.Player.viewAnim.Equals(15) || arg.Player.viewAnim.Equals(40))
		{
			return GetDelayAttackSlashTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(72) || arg.Player.viewAnim.Equals(122) || arg.Player.viewAnim.Equals(124) || arg.Player.viewAnim.Equals(126))
		{
			return GetDelayAttackStabTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(199) || arg.Player.viewAnim.Equals(200) || arg.Player.viewAnim.Equals(201) || arg.Player.viewAnim.Equals(32) || arg.Player.viewAnim.Equals(71))
		{
			int delayAttackSlashTime = GetDelayAttackSlashTime2(ref arg);
			if (delayAttackSlashTime > 0)
			{
				return delayAttackSlashTime;
			}
			return GetDelayAttackSlashTime(ref arg);
		}
		return 0;
	}

	protected virtual int SetNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + AttackInterval);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		if (DelayAttackStabTimeSet > 0)
		{
			WeaponUtility.SetDelayAttackStabTime(ref arg, DelayAttackStabTimeSet);
		}
		return 0;
	}

	protected virtual int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, ViewAnimId);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		return 0;
	}

	public void KnifeFire(ref CommonWeaponArg arg, int seq, float distance, FireUtility.FireFunc soundFunc, bool isDelayAttackImmdiately = false)
	{
		if ((arg.Cmd.Buttons | 0x40) > 0)
		{
			distance += Contexts.battleRoom.playerInfo.MyPlayerSkillAdditionalData.LeftAttackExtraDis;
		}
		else if ((arg.Cmd.Buttons | 0x200) > 0)
		{
			distance += Contexts.battleRoom.playerInfo.MyPlayerSkillAdditionalData.RightAttackExtraDis;
		}
		int delayTime = GetDelayTime(ref arg);
		KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, distance, delayTime, soundFunc, isDelayAttackImmdiately);
	}

	public void KnifeFireWithSureDelayTime(ref CommonWeaponArg arg, int seq, float distance, int delayTime, FireUtility.FireFunc soundFunc, bool isDelayAttackImmdiately = false)
	{
		if (delayTime > 0 || isDelayAttackImmdiately)
		{
			if (arg.CurrentWeapon.hasDelayAttack)
			{
				arg.CurrentWeapon.delayAttack.IsDelayAttackImmdiately = isDelayAttackImmdiately;
				arg.CurrentWeapon.delayAttack.DelayFireRemain = delayTime;
				arg.CurrentWeapon.delayAttack.IsLeftAttack = arg.Cmd.IsAttackOn;
				arg.CurrentWeapon.delayAttack.Player = arg.Player;
				arg.CurrentWeapon.delayAttack.CurrentWeapon = arg.CurrentWeapon;
				arg.CurrentWeapon.delayAttack.Seq = seq;
				arg.CurrentWeapon.delayAttack.Distance = distance;
				arg.CurrentWeapon.delayAttack.SoundFunc = soundFunc;
				arg.CurrentWeapon.delayAttack.CallBack = DelayAttackDone;
				arg.CurrentWeapon.delayAttack.CurrentFrameInterval = arg.Cmd.FrameInterval;
				arg.CurrentWeapon.delayAttack.Cmds.Clear();
			}
			else
			{
				arg.CurrentWeapon.AddDelayAttack(delayTime, arg.Cmd.IsAttackOn, arg.Player, arg.CurrentWeapon, seq, distance, soundFunc, isDelayAttackImmdiately, arg.Cmd.FrameInterval, new Dictionary<int, IUserCmd>(), DelayAttackDone);
			}
		}
	}

	public void AttackImmed(ref CommonWeaponArg arg, int seq, float distance, FireUtility.FireFunc soundFunc)
	{
		KnifeHoleFire(arg.Player, arg.CurrentWeapon, seq, distance, soundFunc, arg.Cmd);
	}

	protected void DelayAttackDone(DelayAttackComponent comp, IUserCmd cmd)
	{
		KnifeHoleFire(comp.Player, comp.CurrentWeapon, cmd.Seq, comp.Distance, (FireUtility.FireFunc)comp.SoundFunc, cmd);
	}

	protected void KnifeHoleFire(PlayerEntity player, WeaponEntity currentWeapon, int seq, float distance, FireUtility.FireFunc soundFunc, IUserCmd cmd)
	{
		int seq2 = cmd.Seq;
		TraceResult results = FireUtility.Fire(player, currentWeapon, seq2, distance, Mins, Maxs, knife: true);
		FireUtility.GetInfoFromTrace(_start, _endPos, _normal, results, player);
		if (results.EntityId == -2)
		{
			DoHitWorldActions(player, currentWeapon, Contexts, _start, _endPos, _normal, results.SurfaceFlags);
		}
		else if (results.EntityId != -1)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(results.EntityId);
			if (entityWithEntityId != null)
			{
				int hitGroup = HitBoxGroupUtilty.GetHitGroup(results.BoneName);
				DoHitPlayerActions(player, currentWeapon, Contexts, cmd, _start, _endPos, _normal, entityWithEntityId, hitGroup);
			}
		}
		DoKnifeHitsActions(player, cmd, currentWeapon, Contexts, player.clientTime.ClientTime);
		if (soundFunc != null)
		{
			CommonWeaponArg arg = default(CommonWeaponArg);
			arg.Player = player;
			arg.CurrentWeapon = currentWeapon;
			arg.Contexts = Contexts;
			arg.Cmd = cmd;
			arg.ClientTime = player.clientTime.ClientTime;
			soundFunc(ref arg);
		}
	}

	protected void DoHitPlayerActions(PlayerEntity player, WeaponEntity currentWeapon, Contexts contexts, IUserCmd cmd, Vector3D startPos, Vector3D endPos, Vector3D normal, PlayerEntity beHitPlayer, int hitGroup)
	{
		HitPlayerArgs args = default(HitPlayerArgs);
		args.player = player;
		args.currentWeapon = currentWeapon;
		args.contexts = contexts;
		args.startPos = startPos;
		args.endPos = endPos;
		args.normal = normal;
		args.beHitPlayer = beHitPlayer;
		args.hitGroup = hitGroup;
		args.cmd = cmd;
		_hitplayers.Step(ref args);
	}

	protected void DoHitWorldActions(PlayerEntity player, WeaponEntity currentWeapon, Contexts contexts, Vector3D startPos, Vector3D endPos, Vector3D normal, int surfaceFlags)
	{
		HitWorldArgs args = default(HitWorldArgs);
		args.player = player;
		args.currentWeapon = currentWeapon;
		args.contexts = contexts;
		args.startPos = startPos;
		args.endPos = endPos;
		args.normal = normal;
		args.surfaceFlags = surfaceFlags;
		args.resultId = -2;
		_hitWorlds.Step(ref args);
	}

	protected void DoKnifeHitsActions(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon, Contexts contexts, int clientTime)
	{
		CommonWeaponArg args = default(CommonWeaponArg);
		args.Player = player;
		args.CurrentWeapon = currentWeapon;
		args.Contexts = contexts;
		args.ClientTime = clientTime;
		args.Cmd = cmd;
		_knifeHits.Step(ref args);
	}
}

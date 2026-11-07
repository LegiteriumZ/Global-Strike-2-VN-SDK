using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Chain;
using Assets.Sources.Utils.Tps;
using Assets.Sources.Utils.Weapon;
using SSJJPhysics;
using SSJJUserCmd;
using Sources.Modules.Player.Chain;
using share;

namespace Assets.Sources.Modules.Player.Attack.Utils;

public class GunFireCell
{
	private static readonly float[] Mins = new float[3];

	private static readonly float[] Maxs = new float[3];

	protected readonly Contexts Contexts;

	private readonly Vector3D _endPos = new Vector3D();

	private readonly Vector3D _normal = new Vector3D();

	private readonly Vector3D _start = new Vector3D();

	private WeaponChain<HitPlayerArgs> _hitplayers;

	private WeaponChain<HitWorldArgs> _hitWorlds;

	public WeaponChain<HitPlayerArgs> Hitplayers
	{
		get
		{
			return _hitplayers;
		}
		set
		{
			_hitplayers = value;
		}
	}

	public WeaponChain<HitWorldArgs> HitWorlds
	{
		get
		{
			return _hitWorlds;
		}
		set
		{
			_hitWorlds = value;
		}
	}

	public GunFireCell(Contexts contexts)
	{
		Contexts = contexts;
		_hitplayers = new WeaponChain<HitPlayerArgs>(2);
		_hitWorlds = new WeaponChain<HitWorldArgs>(2);
	}

	public void AddAction(HitPlayerAction trueChain)
	{
		_hitplayers.AddChain((WeaponHitPlayerChain)trueChain);
	}

	public void AddAction(HitWorldAction trueChain)
	{
		_hitWorlds.AddChain((WeaponHitWorldChain)trueChain);
	}

	public void GunFire(ref CommonWeaponArg arg, int seq, float distance)
	{
		TraceResult results = FireUtility.Fire(arg.Player, arg.CurrentWeapon, seq, distance, Mins, Maxs);
		if (results.EntityId == -1)
		{
			return;
		}
		if (Contexts.battleRoom.roomData.Data.RaceType == 100 && Contexts.battleRoom.roomData.Data.FreeType == "BulletStorm")
		{
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval * 2;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval * 2;
			return;
		}
		FireUtility.GetInfoFromTrace(_start, _endPos, _normal, results, arg.Player, isKnife: false);
		PlayerEntity entityWithEntityId = Contexts.player.GetEntityWithEntityId(results.EntityId);
		if (entityWithEntityId != null)
		{
			int hitGroup = HitBoxGroupUtilty.GetHitGroup(results.BoneName);
			DoHitPlayerActions(arg.Player, arg.CurrentWeapon, Contexts, arg.Cmd, _start, _endPos, _normal, entityWithEntityId, hitGroup);
		}
		else
		{
			DoHitWorldActions(arg.Player, arg.CurrentWeapon, Contexts, _start, _endPos, _normal, results.SurfaceFlags, results.EntityId);
		}
	}

	public void DoHitPlayerActions(PlayerEntity player, WeaponEntity currentWeapon, Contexts contexts, IUserCmd cmd, Vector3D startPos, Vector3D endPos, Vector3D normal, PlayerEntity beHitPlayer, int hitGroup)
	{
		HitPlayerArgs hitPlayerArgs = default(HitPlayerArgs);
		hitPlayerArgs.player = player;
		hitPlayerArgs.currentWeapon = currentWeapon;
		hitPlayerArgs.contexts = contexts;
		hitPlayerArgs.startPos = startPos;
		hitPlayerArgs.endPos = endPos;
		hitPlayerArgs.normal = normal;
		hitPlayerArgs.beHitPlayer = beHitPlayer;
		hitPlayerArgs.hitGroup = hitGroup;
		hitPlayerArgs.cmd = cmd;
		HitPlayerArgs args = hitPlayerArgs;
		TpsUtility.AdjustGunFireStart(ref args);
		_hitplayers.Step(ref args);
	}

	public void DoHitWorldActions(PlayerEntity player, WeaponEntity currentWeapon, Contexts contexts, Vector3D startPos, Vector3D endPos, Vector3D normal, int surfaceFlags, int resultId)
	{
		HitWorldArgs hitWorldArgs = default(HitWorldArgs);
		hitWorldArgs.player = player;
		hitWorldArgs.currentWeapon = currentWeapon;
		hitWorldArgs.contexts = contexts;
		hitWorldArgs.startPos = startPos;
		hitWorldArgs.endPos = endPos;
		hitWorldArgs.normal = normal;
		hitWorldArgs.surfaceFlags = surfaceFlags;
		hitWorldArgs.resultId = resultId;
		HitWorldArgs args = hitWorldArgs;
		TpsUtility.AdjustGunFireStart(ref args);
		_hitWorlds.Step(ref args);
	}
}

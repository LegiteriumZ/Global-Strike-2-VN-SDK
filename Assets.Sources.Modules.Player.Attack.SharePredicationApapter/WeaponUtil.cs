using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Player.Events;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJPhysics;
using UnityEngine;
using share;
using weapon.predicateSystem.implementSeparately;
using weapon.utils;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class WeaponUtil : IWeaponUtil
{
	public static IWeaponUtil Instance = new WeaponUtil();

	private readonly Vector3D _endPos = new Vector3D();

	private readonly Vector3D _normal = new Vector3D();

	private readonly Vector3D _start = new Vector3D();

	private Vector3D _shotDirectionVector3D = new Vector3D();

	private static float[] Mins = new float[3];

	private static float[] Maxs = new float[3];

	private static float lastFrameTime = 0f;

	public static bool double_fire = false;

	public bool FireBullets(ICommonWeaponArgs args, weapon.utils.Vector3 shotDirection, int distance)
	{
		PlayerEntity playerEntity = args.GetPlayer() as PlayerEntity;
		WeaponEntity weaponEntity = (args.GetCurrentWeapon() as WeaponPropertiesAdapter).WeaponEntity;
		bool flag = args.GetCurrentWeapon().IsMeleeAttack();
		_shotDirectionVector3D.SetTo(shotDirection.x, shotDirection.y, shotDirection.z);
		TraceResult results = FireUtility.BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, playerEntity, Contexts.sharedInstance.player, distance, _shotDirectionVector3D, Mins, Maxs, flag);
		if (results.EntityId != -1)
		{
			if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 100 && Contexts.sharedInstance.battleRoom.roomData.Data.FreeType == "BulletStorm")
			{
				weaponEntity.attack.NextAttackTimer = playerEntity.clientTime.ClientTime + weaponEntity.basicInfo.Info.AttackInterval * 2;
				weaponEntity.attack.NextSecondaryAttackTimer = playerEntity.clientTime.ClientTime + weaponEntity.basicInfo.Info.AttackInterval * 2;
				return false;
			}
			FireUtility.GetInfoFromTrace(_start, _endPos, _normal, results, playerEntity, flag);
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(results.EntityId);
			if (entityWithEntityId != null)
			{
				int hitGroup = HitBoxGroupUtilty.GetHitGroup(results.BoneName);
				HitPlayerArgs hitPlayerArgs = default(HitPlayerArgs);
				hitPlayerArgs.player = playerEntity;
				hitPlayerArgs.currentWeapon = weaponEntity;
				hitPlayerArgs.contexts = Contexts.sharedInstance;
				hitPlayerArgs.startPos = _start;
				hitPlayerArgs.endPos = _endPos;
				hitPlayerArgs.normal = _normal;
				hitPlayerArgs.beHitPlayer = entityWithEntityId;
				hitPlayerArgs.hitGroup = hitGroup;
				hitPlayerArgs.cmd = Contexts.sharedInstance.userCommand.commands.getCurrentCmd();
				HitPlayerArgs arg = hitPlayerArgs;
				if (flag)
				{
					HitUtility.KnifeHitPlayerAction(ref arg);
				}
				else
				{
					HitUtility.BulletHiPlayerAction(ref arg);
				}
				return true;
			}
			HitWorldArgs hitWorldArgs = default(HitWorldArgs);
			hitWorldArgs.player = playerEntity;
			hitWorldArgs.currentWeapon = weaponEntity;
			hitWorldArgs.contexts = Contexts.sharedInstance;
			hitWorldArgs.startPos = _start;
			hitWorldArgs.endPos = _endPos;
			hitWorldArgs.normal = _normal;
			hitWorldArgs.surfaceFlags = results.SurfaceFlags;
			hitWorldArgs.resultId = results.EntityId;
			HitWorldArgs arg2 = hitWorldArgs;
			if (flag)
			{
				HitUtility.KnifeHitWorldAction(ref arg2);
			}
			else
			{
				HitUtility.BulletHitWorldAction(ref arg2);
			}
		}
		return false;
	}

	public void AddFireSparks(ICommonWeaponArgs args, int fire)
	{
		if (!(args.GetPlayer() is PlayerEntity playerEntity))
		{
			return;
		}
		if (fire == 1 || fire == 59 || WeaponUtility.HasBulletOtherFireEffect(playerEntity, fire))
		{
			if (!playerEntity.hasFirstPersonUnityObjects || !WeaponUtility.HasMuzzleFlashForFov(playerEntity, playerEntity.fov.Fov) || args.GetCurrentCmd().FirstPredication())
			{
				return;
			}
			bool flag = false;
			if (playerEntity.viewAnim.ViewAnimInfo.StateId == 29 || playerEntity.viewAnim.ViewAnimInfo.StateId == 17)
			{
				flag = true;
			}
			else if (playerEntity.viewAnim.ViewAnimInfo.StateId == 32)
			{
				double_fire = !double_fire;
				flag = double_fire;
			}
			if (!flag)
			{
				WeaponUtility.Fire(playerEntity.firstPersonUnityObjects.RightFires, args.GetCurrentWeapon().IsSpecialMode());
				WeaponUtility.RightFire(playerEntity);
				if (PlayLeftFire(args))
				{
					WeaponUtility.Fire(playerEntity.firstPersonUnityObjects.LeftFires, args.GetCurrentWeapon().IsSpecialMode());
					WeaponUtility.LeftFire(playerEntity);
				}
			}
			else
			{
				WeaponUtility.Fire(playerEntity.firstPersonUnityObjects.LeftFires, args.GetCurrentWeapon().IsSpecialMode());
				WeaponUtility.LeftFire(playerEntity);
			}
		}
		else if (fire == 47 && playerEntity.hasFirstPersonUnityObjects && !playerEntity.fov.IsZoom() && !args.GetCurrentCmd().FirstPredication())
		{
			WeaponUtility.Fire(playerEntity.firstPersonUnityObjects.LeftFires, args.GetCurrentWeapon().IsSpecialMode());
			WeaponUtility.LeftFire(playerEntity);
		}
	}

	public void AddSound(ICommonWeaponArgs args, int fire)
	{
		AssetInfo assetInfo;
		switch (fire)
		{
		case 1302:
			assetInfo = SoundResourceUtility.GetWeaponSoundFire4AssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		case 59:
			assetInfo = SoundResourceUtility.GetWeaponSoundFire3AssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		case 11:
			assetInfo = SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		case 47:
			assetInfo = SoundResourceUtility.GetWeaponSoundFireAssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		case 1:
			assetInfo = SoundResourceUtility.GetWeaponSoundFireAssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		case 100050:
			assetInfo = SoundResourceUtility.GetWeaponSoundChangeAssetInfo(args.GetCurrentWeapon().GetWeaponName());
			break;
		default:
			return;
		}
		if (args.GetCurrentCmd().FirstPredication())
		{
			return;
		}
		if (WeaponConfigUtils.RealDouble(args.GetCurrentWeapon().GetPredicationConfig().GetAttackType()))
		{
			if (lastFrameTime + 0.05f < Time.time)
			{
				PlayerSound(args, assetInfo);
				lastFrameTime = Time.time;
			}
		}
		else
		{
			PlayerSound(args, assetInfo);
		}
	}

	public void BroadCastEvent(ICommonWeaponArgs args, int fire)
	{
		if (!EventsPlaySystem.ProcessEventParticles(args.GetPlayer() as PlayerEntity, fire))
		{
			AddSound(args, fire);
		}
	}

	private void PlayerSound(ICommonWeaponArgs args, AssetInfo assetInfo)
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, (args.GetPlayer() as PlayerEntity).isMyPlayer, assetInfo, GameSoundManager.Config.WeaponVolume);
	}

	private bool PlayLeftFire(ICommonWeaponArgs args)
	{
		if (args.GetCurrentWeapon().GetWeaponName() == "endless_machinegun")
		{
			return true;
		}
		return false;
	}

	public void AfterSubtractCarryClip(int num, ICommonWeaponArgs args)
	{
	}

	public void AfterSubtractCarryClip2(int num, ICommonWeaponArgs args)
	{
	}

	public void ThrowBomb(ICommonWeaponArgs args)
	{
	}

	public void SetChangeBagStatus(ICommonWeaponArgs args)
	{
	}

	public void DecreaseClipLogic(ICommonWeaponArgs args, int num)
	{
		if (!((PlayerEntity)args.GetPlayer()).HasStateType(512))
		{
			int num2 = args.GetCurrentWeapon().GetClip() - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			args.GetCurrentWeapon().SetClip(num2);
		}
	}

	public void DecreaseClip2Logic(ICommonWeaponArgs args, int num)
	{
		if (!((PlayerEntity)args.GetPlayer()).HasStateType(512))
		{
			int num2 = args.GetCurrentWeapon().GetClip2() - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			args.GetCurrentWeapon().SetClip2(num2);
		}
	}
}

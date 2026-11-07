using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.GPUAnim;
using Assets.Sources.Info.WeaponAnim;
using SSJJAnim.AnimState;
using SSJJAnim.CareerAnim;
using SSJJBase.Manager;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Utils.PlayerAnim;

public class PlayerAnimationUtility
{
	public static bool IsViewAnimExist(IEntitsWeaponInfo weaponInfo, int animId)
	{
		return WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weaponInfo)?.ViewAnimExist(animId) ?? false;
	}

	public static bool IsViewAnimExist(PlayerEntity player, int animId)
	{
		return WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(player.currentWeapon.WeaponInfo)?.ViewAnimExist(animId) ?? false;
	}

	public static void SetViewAnimation(PlayerEntity player, int animId, float speed = 1f, bool isNewEvent = false)
	{
		int viewAnimDuration = GetViewAnimDuration(player.currentWeapon.WeaponInfo, animId);
		player.viewAnim.ViewAnimInfo = AnimStateInfoFactory.Instance.GetViewAnimInfo(animId);
		player.viewAnim.RightCurrentTime = 0;
		player.viewAnim.RemainTime = viewAnimDuration;
		player.viewAnim.RightSpeed = speed;
		if (isNewEvent)
		{
			player.viewAnim.AnimSeq++;
		}
	}

	public static void SetLeftViewAnimation(PlayerEntity player, int animId, float speed = 1f, bool isNewEvent = false)
	{
		int viewAnimDuration = GetViewAnimDuration(player.currentWeapon.WeaponInfo, animId);
		player.viewAnim.LeftViewAnimInfo = AnimStateInfoFactory.Instance.GetViewAnimInfo(animId);
		player.viewAnim.LeftCurrentTime = 0;
		player.viewAnim.LeftRemainTime = viewAnimDuration;
		player.viewAnim.LeftSpeed = speed;
		if (isNewEvent)
		{
			player.viewAnim.AnimSeq++;
		}
	}

	public static int GetViewAnimDuration(IEntitsWeaponInfo weaponInfo, int animId)
	{
		return WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weaponInfo)?.GetViewAnimDuration(animId) ?? 0;
	}

	public static void SetTorseAnimation(PlayerEntity player, int animId)
	{
		player.torseAnim.TorsoAnimInfo = AnimStateInfoFactory.Instance.GetTorseAnimInfo(animId);
		player.torseAnim.EclipsedTime = 0;
		player.torseAnim.RemainTime = GetTorseAnimDuration(player.basicInfo.CareerInfo, player.currentWeapon.WeaponInfo, animId);
	}

	public static void SetLegsAnimation(PlayerEntity player, int animId)
	{
		player.legAnim.LegsAnimInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(animId);
		player.legAnim.ScaledEclipsedTime = 0;
		player.legAnim.RemainTime = GetLegAnimDuration(player.basicInfo.CareerInfo, player.currentWeapon.WeaponInfo, animId);
	}

	public static int GetLegAnimDuration(ICareerInfo careerInfo, IEntitsWeaponInfo weaponInfo, int stateId)
	{
		return BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(careerInfo)?.GetLegsAnimDuration(weaponInfo, stateId) ?? 0;
	}

	public static int GetLegAnimDuration(PlayerEntity player, int animId)
	{
		return GetLegAnimDuration(player.basicInfo.CareerInfo, player.currentWeapon.WeaponInfo, animId);
	}

	public static int GetTorseAnimDuration(ICareerInfo careerInfo, IEntitsWeaponInfo weaponInfo, int stateId)
	{
		return BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(careerInfo)?.GetTorsoAnimDuration(weaponInfo, stateId) ?? 0;
	}

	public static int GetTorseAnimDuration(PlayerEntity player, int animId)
	{
		return GetTorseAnimDuration(player.basicInfo.CareerInfo, player.currentWeapon.WeaponInfo, animId);
	}

	public static bool IsTorseAnimationExist(PlayerEntity player, int animId)
	{
		ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(player.basicInfo.CareerInfo);
		if (careerAnimInfo == null)
		{
			return false;
		}
		if (careerAnimInfo.GetPlayerTorsoAnimation(player.currentWeapon.WeaponInfo, animId) == null)
		{
			return false;
		}
		return true;
	}

	public static bool IsViewAnimEqual(PlayerEntity player, int animId)
	{
		if (player.hasViewAnim && player.viewAnim.ViewAnimInfo != null)
		{
			return player.viewAnim.ViewAnimInfo.StateId == animId;
		}
		return false;
	}

	public static bool IsTorseAnimEqual(PlayerEntity player, int animId)
	{
		if (player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null)
		{
			return player.torseAnim.TorsoAnimInfo.StateId == animId;
		}
		return false;
	}

	public static int GetTorsoAnimId(PlayerEntity entity)
	{
		return entity.torseAnim.TorsoAnimInfo?.StateId ?? (-1);
	}

	public static int GetLegAnimId(PlayerEntity entity)
	{
		return entity.legAnim.LegsAnimInfo?.StateId ?? (-1);
	}

	public static bool CheckIsWarpAnimSystem(PlayerEntity entity, int legStateId, int torsoStateId)
	{
		if (entity.hasBasicInfo && entity.basicInfo.CareerInfo != null)
		{
			ICareerInfo careerInfo = entity.basicInfo.CareerInfo;
			ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(careerInfo);
			if (careerAnimInfo == null)
			{
				return false;
			}
			if (!careerAnimInfo.HasLegWrapAnimationData(legStateId))
			{
				return careerAnimInfo.HasTorsoWrapAnimationData(torsoStateId);
			}
			return true;
		}
		return false;
	}

	public static bool CheckIsTPSAnimSystem(PlayerEntity entity)
	{
		if (entity.hasBasicInfo && entity.basicInfo.CareerInfo != null)
		{
			return PlayerCareerUtil.IsTPS(entity.basicInfo.CareerInfo.Name);
		}
		return false;
	}

	public static bool isGPUAnim(string playerName)
	{
		if (!SpecailDebug.Instance.OpenGPUAnim)
		{
			if (SystemInfo.graphicsDeviceVendorID == 32902)
			{
				return false;
			}
			if (SystemInfo.graphicsMemorySize < 1000)
			{
				return false;
			}
		}
		if (SystemInfo.graphicsDeviceID == 982 && SystemInfo.graphicsDeviceVendorID == 4318)
		{
			return false;
		}
		switch (playerName)
		{
		case "boss1019":
		case "boss1011":
		case "boss06":
		case "boss09":
		case "boss10":
		case "bossjy3001":
		case "bossjy3005":
		case "bossjy3006":
		case "longyin_renzhe":
		case "mechnear2":
		case "pveawp":
		case "boss1003":
		case "rpg_minion_wu":
		case "rpg_cabrite_4":
		case "rpg_cabrite_5":
			return false;
		default:
			if (RuleUtilty.isGPUAnimScreen())
			{
				return BattleSingletonInstance<GpuAnimInfoFactory>.Instance.GetSkinInfo(playerName) != null;
			}
			return false;
		}
	}
}

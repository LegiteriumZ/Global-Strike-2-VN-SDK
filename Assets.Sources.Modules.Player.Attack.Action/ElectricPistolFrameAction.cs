using System;
using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Logger;
using UnityEngine;
using share;
using weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class ElectricPistolFrameAction : IFrameCmdAction, ICmdAction
{
	private const int Distance = 950;

	private const int Angle = 14;

	private const int AngleRrp = 28;

	public ElectricPistolFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		SetClip(arg.CurrentWeapon);
		SetSpecialMode(ref arg);
		SetViewAnim(ref arg);
		ShowButtonUi(ref arg);
		return true;
	}

	private static void ShowButtonUi(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasAttach && arg.CurrentWeapon.attach.Data is ElectricPistolAttach)
		{
			ElectricPistolAttach electricPistolAttach = (ElectricPistolAttach)arg.CurrentWeapon.attach.Data;
			if (arg.CurrentWeapon.special.SpecialMode && electricPistolAttach.NextScanTime < arg.ClientTime)
			{
				electricPistolAttach.NextScanTime = arg.ClientTime + 200;
				electricPistolAttach.IsShowButton = (ScanPlayer(arg.Player) ? true : false);
			}
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				electricPistolAttach.IsShowButton = false;
			}
		}
	}

	private void SetViewAnim(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 16))
		{
			return;
		}
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 39);
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 48);
			}
		}
		if (arg.CurrentWeapon.basicInfo.Data.NextSkillTimer < arg.ClientTime && !arg.CurrentWeapon.special.SpecialMode)
		{
			NormalToSpecialModel(ref arg);
		}
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.basicInfo.Data.NextSkillTimer > arg.ClientTime)
		{
			SpecialToNormalModel(ref arg);
		}
	}

	private void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		arg.CurrentWeapon.special.SpecialMode = true;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		this.DebugFormat("normalToSpecialModel: {0},{1},{2}", arg.CurrentWeapon.basicInfo.Data.NextSkillTimer, arg.ClientTime, arg.CurrentWeapon.attack.NextAttackTimer);
	}

	private void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		arg.CurrentWeapon.special.SpecialMode = false;
		this.DebugFormat("specialToNormalModel {0},{1},{2}", arg.CurrentWeapon.basicInfo.Data.NextSkillTimer, arg.ClientTime, arg.CurrentWeapon.attack.NextAttackTimer);
	}

	private static void SetClip(WeaponEntity weapon)
	{
		weapon.clip.Clip = 0;
		weapon.clip.CarryClip = 0;
	}

	private static void SetSpecialMode(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36))
		{
			arg.CurrentWeapon.special.SpecialMode = true;
		}
	}

	private static double GetCosAngle(PlayerEntity player)
	{
		if (RuleUtilty.IsPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			return Math.Cos(0.24434609338641167);
		}
		return Math.Cos(0.12217304669320583);
	}

	private static bool IsInRage(Vector3 start, Vector3 end, Vector3 shotDir, double cosAngle)
	{
		if (Vector3.Distance(start, end) > 950f)
		{
			return false;
		}
		Vector3 rhs = end - start;
		rhs.z = 0f;
		rhs.Normalize();
		return (double)Vector3.Dot(shotDir, rhs) > cosAngle;
	}

	public static bool ScanPlayer(PlayerEntity player)
	{
		Vector3D vector3D = ShootingDirUtils.CalculateShotingDir(0, player.GetViewYaw() + 2f * player.GetPunchYaw(), player.GetViewPitch() + 2f * player.GetPunchPitch(), 0.0, 0f, 0.0);
		Vector3 shotDir = new Vector3((float)vector3D.x, (float)vector3D.y);
		shotDir.Normalize();
		double cosAngle = GetCosAngle(player);
		foreach (PlayerEntity item in Contexts.sharedInstance.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Fpos)))
		{
			if (item.hasBasicInfo && item.entityId != player.entityId && item.GetTeam() != player.GetTeam() && !item.IsDead() && IsInRage(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()), item.GetCompenstatePos(item.fpos.Change.GetPosIndex()), shotDir, cosAngle) && player.normalTrace.EntityId != -2)
			{
				return true;
			}
		}
		return false;
	}
}

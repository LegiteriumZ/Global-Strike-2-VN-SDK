using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Components.Common;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils;
using Assets.Sources.Utils.ComponentInit;
using NetData;
using SSJJAnim.AnimState;
using SSJJBase.Obscure;
using SSJJPhysics;
using SSJJPhysicsExtensions;
using UnityEngine;

namespace Assets.Tests.PlayMode;

public class PlayerEntityTestUtility
{
	public static PlayerEntity CreateEntity(PlayerContext playerContext, int entityId, string careerName, string weaponName, Vector3 pos)
	{
		return CreateEntity(playerContext, entityId, careerName, "", weaponName, "", "man", "", pos, Vector3.zero, isPredicateSelf: false);
	}

	public static PlayerEntity CreateEntity(PlayerContext playerContext, int entityId, string careerName, string playerSkinName, string weaponName, string weaponSkinName, string viewHandName, string accessory, Vector3 pos, Vector3 angle, bool isPredicateSelf)
	{
		PlayerEntityData playerEntityData = new PlayerEntityData();
		playerEntityData.Id = entityId;
		playerEntityData.Career = careerName;
		playerEntityData.BackAccessory = "hellsnake";
		playerEntityData.BackWeapon = "ak47_g";
		playerEntityData.ModuleNames = "defaultHead_man:defaultCloth_man:defaultPantsr_man";
		playerEntityData.CurrentBagId = 1;
		playerEntityData.CurrentWeapon = 0;
		playerEntityData.CurrentWeaponName = weaponName;
		if (playerSkinName != "")
		{
			playerEntityData.CareerSkin = playerSkinName;
		}
		if (weaponSkinName != "")
		{
			playerEntityData.CurrentWeaponSkinName = weaponSkinName;
		}
		if (accessory != null)
		{
			playerEntityData.BackWeapon = null;
			playerEntityData.BackAccessory = accessory;
		}
		playerEntityData.X = pos.x;
		playerEntityData.Y = pos.y;
		playerEntityData.Z = pos.z;
		playerEntityData.ViewPitch = angle.x;
		playerEntityData.ViewYaw = angle.y;
		playerEntityData.PunchRoll = angle.z;
		playerEntityData.ViewHeight = 200f;
		playerEntityData.CurrentHandName = viewHandName;
		PlayerEntity playerEntity = playerContext.CreateEntity();
		if (isPredicateSelf)
		{
			playerEntity.isMyPlayer = true;
			playerEntity.isCameraOwner = true;
			playerEntity.isPrediction = true;
			playerEntity.isFirstPersonView = true;
		}
		playerEntity.AddEntityId(entityId);
		playerEntity.AddBasicInfo(playerEntityData, playerEntityData, null, new DefaultCareerInfo(careerName), null, 0, newIsPart: false, 0.0);
		playerEntity.AddFpos(new Change());
		PlayerEntityUtility.AddMove(playerEntity, Contexts.sharedInstance.weapon);
		playerEntity.move.PyPlayerMove = new PyPlayerAdapter(playerEntity, Contexts.sharedInstance.weapon);
		PlayerEntityUtility.AddViewHeight(playerEntity);
		PlayerEntityUtility.AddFov(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		PlayerEntityUtility.AddOrientation(playerEntity);
		PlayerEntityUtility.AddPunchOrientation(playerEntity);
		PlayerEntityUtility.AddPunchSmooth(playerEntity);
		PlayerEntityUtility.AddLife(playerEntity);
		PlayerEntityUtility.AddState(playerEntity);
		PlayerEntityUtility.AddBuff(playerEntity);
		playerEntity.AddTorseAnim(new TorseAnimStateInfo(15), 0, 2000, 0, 0, null, new Dictionary<string, float>(), newSpecialMode: false);
		playerEntity.AddViewAnim(0, 0, 0, 0, 0, 0, 1f, 1f, newIsBowing: false, 0, null, new ViewAnimStateInfo(13), null, new ViewAnimStateInfo(13));
		playerEntity.AddCurrentWeapon(0, 0, weaponName, 0, WeaponInfoFactory.Instance.GetWeaponInfo(weaponName), newIsLock: false, newCanDuck: false, playerEntityData.CurrentWeaponSkinName, 0f, 0);
		return playerEntity;
	}

	public static void RefreshPlayerAvatarEntity(PlayerEntity playerEntity, string avatarMsg)
	{
		playerEntity.basicInfo.Current.ModuleNames = avatarMsg;
		playerEntity.thirdPersonUnityObjects.Worn += 0.01f;
	}

	public static void RefreshPlayerEntity(PlayerEntity playerEntity, string career, string playerSkin, string weapon, string weaponSkin, string viewHand, string accessory, Vector3 pos, float angle)
	{
		playerEntity.basicInfo.Current.Career = career;
		playerEntity.basicInfo.Current.CurrentHandName = viewHand;
		playerEntity.basicInfo.SkinName = playerSkin;
		playerEntity.basicInfo.CareerInfo = CareerInfoFactory.Instance.GetCareerInfo(playerEntity.basicInfo.Current.Career);
		playerEntity.basicInfo.Current.CurrentWeaponName = weapon;
		playerEntity.basicInfo.Current.CurrentWeaponSkinName = weaponSkin;
		playerEntity.basicInfo.Current.BackWeapon = null;
		playerEntity.basicInfo.Current.BackAccessory = accessory;
		playerEntity.currentWeapon.WeaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
		playerEntity.currentWeapon.SkinName = weaponSkin;
		playerEntity.currentWeapon.Name = weapon;
		playerEntity.basicInfo.Current.X = pos.x;
		playerEntity.basicInfo.Current.Y = pos.y;
		playerEntity.basicInfo.Current.Z = pos.z;
		playerEntity.basicInfo.Current.ViewYaw = angle;
		playerEntity.basicInfo.Current.PunchPitch = angle;
		playerEntity.basicInfo.Current.MoveYaw = angle;
	}

	public static void ChangeWeapon(PlayerEntity player, string weapon)
	{
		player.basicInfo.Current.CurrentWeaponName = weapon;
		player.currentWeapon.Name = weapon;
		player.currentWeapon.WeaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
	}

	public static void SetRotation(PlayerEntity player, float yaw, float pitch)
	{
		PlayerEntityData current = player.basicInfo.Current;
		OrientationComponent orientation = player.orientation;
		float moveYaw = (current.MoveYaw = yaw);
		orientation.MoveYaw = moveYaw;
		OrientationComponent orientation2 = player.orientation;
		moveYaw = (current.ViewYaw = yaw);
		orientation2.Yaw = moveYaw;
		OrientationComponent orientation3 = player.orientation;
		moveYaw = (current.ViewPitch = pitch);
		orientation3.Pitch = moveYaw;
	}

	public static IEnumerator MoveRandomly(PlayerEntity myPlayerEntity)
	{
		Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0f).normalized;
		while (true)
		{
			if (Random.Range(0, 50) == 0)
			{
				dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0f).normalized;
			}
			Vector3 vector = dir * Time.deltaTime * 500f;
			Vector3 vector2 = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()) + vector;
			TraceResult ret = default(TraceResult);
			if (PyEngineUtility.WorldTrace(myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()), vector2, new float[3], new float[3] { 10f, 10f, 10f }, null, ref ret).Fraction >= 1f)
			{
				myPlayerEntity.fpos.Sp(vector2);
				myPlayerEntity.basicInfo.Current.X = vector2.x;
				myPlayerEntity.basicInfo.Current.Y = vector2.y;
				myPlayerEntity.basicInfo.Current.Z = vector2.z;
			}
			yield return null;
		}
	}

	public static IEnumerator PlayTorseAnim(PlayerEntity myPlayerEntity, int animId)
	{
		myPlayerEntity.torseAnim.TorsoAnimInfo = AnimStateInfoFactory.Instance.GetTorseAnimInfo(animId);
		myPlayerEntity.torseAnim.EclipsedTime = 0;
		while (true)
		{
			myPlayerEntity.torseAnim.EclipsedTime += (int)(Time.deltaTime * 1000f);
			yield return null;
		}
	}
}

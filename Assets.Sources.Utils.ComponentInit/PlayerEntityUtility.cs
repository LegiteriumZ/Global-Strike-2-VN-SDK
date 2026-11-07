using System.Collections.Generic;
using Assets.Scripts.Asset;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.EventParticle;
using Assets.Sources.Components.Interface.Info.PlayerBuff;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Info.Career;
using Assets.Sources.Utils.Weapon;
using Core.Utils.System46;
using NetData;
using SSJJAnim.AnimState;
using SSJJBase.Logger;
using SSJJBase.Obscure;
using SSJJBase.Pool;
using SSJJPhysicsExtensions;
using UnityEngine;
using cakeslice;
using physics.data;

namespace Assets.Sources.Utils.ComponentInit;

public class PlayerEntityUtility
{
	public static LoggerAdapter Logger = new LoggerAdapter(typeof(PlayerEntityUtility));

	public static void AddBasicInfo(PlayerEntity entity)
	{
		entity.AddBasicInfo(null, null, null, null, null, 1000, newIsPart: false, 0.0);
	}

	public static void AddPassiveSkillInfo(PlayerEntity entity)
	{
		entity.AddPassiveSkillGroup(new Dictionary<string, PassiveSkillComponent>(), newPassiveSkillDirty: false);
	}

	public static void AddStudioSkillInfo(PlayerEntity entity)
	{
		entity.AddStudioSkillConditionGroup(new Dictionary<string, StudioSkillConditionComponent>(), newStudioSkillDirty: false);
	}

	public static void AddVoice(PlayerEntity entity)
	{
		entity.AddVoice("", newSpeaking: false);
	}

	public static void AddOneKillInfo(PlayerEntity entity)
	{
		entity.AddOneKillInfo(null);
	}

	public static void AddCurrKill(PlayerEntity entity)
	{
		entity.AddCurrKill(0);
	}

	public static void AddBeinghit(PlayerEntity entity)
	{
		entity.AddBeingHit(0, null);
	}

	public static void AddPartBasicInfo(PlayerEntity entity)
	{
		entity.AddPartBasicInfo(newIsFootStep: false, newOnLadder: false);
	}

	public static void AddTorseAnim(PlayerEntity entity)
	{
		entity.AddTorseAnim(null, 0, 0, 0, 0, null, new Dictionary<string, float>(), newSpecialMode: false);
	}

	public static void AddTransfrom(PlayerEntity entity)
	{
		entity.AddFpos(new Change());
	}

	public static void AddLegAnim(PlayerEntity entity)
	{
		entity.AddLegAnim(0, 0, 0f, null, null, 0f, newIsWarpLoop: false, null, new List<IAnimationWarpsStateData>());
	}

	public static void AddViewAnim(PlayerEntity entity)
	{
		entity.AddViewAnim(0, 0, 0, 0, 0, 0, 1f, 1f, newIsBowing: false, 0, null, null, null, null);
	}

	public static void AddCurrentWeapon(PlayerEntity entity)
	{
		entity.AddCurrentWeapon(0, 0, null, 0, null, newIsLock: false, newCanDuck: true, null, 0f, 0);
	}

	public static void AddQianglingWeaponList(PlayerEntity entity)
	{
		entity.AddQianglingWeapon(null, null);
	}

	public static void PostInitBasicInfo(PlayerEntity entity)
	{
		BasicInfoComponent basicInfo = entity.basicInfo;
		basicInfo.ViewAnimInfo = AnimStateInfoFactory.Instance.GetViewAnimInfo(basicInfo.Current.ViewAnim);
		basicInfo.CareerInfo = CareerInfoFactory.Instance.GetCareerInfo(basicInfo.Current.Career);
		basicInfo.SkinName = basicInfo.Current.CareerSkin;
	}

	public static void PostInitCurrentWeapon(PlayerEntity entity)
	{
		BasicInfoComponent basicInfo = entity.basicInfo;
		CurrentWeaponComponent currentWeapon = entity.currentWeapon;
		if (basicInfo.Current.CurrentWeaponName != currentWeapon.Name)
		{
			entity.isLoadWeapon = true;
		}
		WeaponUtility.CopyToWeaponComponent(currentWeapon, basicInfo.Current);
	}

	public static void PostInitQianglingWeaponList(PlayerEntity entity)
	{
		BasicInfoComponent basicInfo = entity.basicInfo;
		QianglingWeaponComponent qianglingWeapon = entity.qianglingWeapon;
		qianglingWeapon.weaponList = new List<QianglingWeaponData>();
		qianglingWeapon.WeaponInfoList = new List<IEntitsWeaponInfo>();
		if (basicInfo.Current.QianglingWeaponList != null && basicInfo.Current.QianglingWeaponList.Count > 0)
		{
			entity.isLoadWeapon = true;
		}
		WeaponUtility.CopyToQianglingWeaponComponent(qianglingWeapon, basicInfo.Current);
	}

	public static void AddPosition(PlayerEntity player)
	{
		player.AddFpos(new Change());
	}

	public static void AddOrientation(PlayerEntity player)
	{
		player.AddOrientation(0f, 0f, 0f, 0f, 0f, 0f, 0f);
	}

	public static void AddPunchOrientation(PlayerEntity player)
	{
		player.AddPunchOrientation(0f, 0f);
	}

	public static void AddClientTime(PlayerEntity player)
	{
		player.AddClientTime(0);
	}

	public static void AddFavor(PlayerEntity player)
	{
		player.AddFavor(0);
	}

	public static void AddSkill(PlayerEntity player)
	{
		player.AddSkill(new PlayerInfoData(), new Dictionary<int, SkillInfoData>(), new MyDictionary<int, PlayerInfoComponent.StatusDes>(), new PlayerSkillAdditionalData());
	}

	public static void AddVisiable(PlayerEntity player)
	{
		player.AddVisiable(newIsVisiable: true, newIsNear: true, newIsWeaponParticleUnSee: false);
	}

	public static void AddShowHp(PlayerEntity player)
	{
		player.AddHpShow(0, 0, 0, 0f);
	}

	public static void AddDunHp(PlayerEntity player)
	{
		player.AddDunHpShow(0f, 0f, 0);
	}

	public static void AddPredicationComfirm(PlayerEntity player)
	{
		player.AddPredicateComfirm(newBeingHit: false, 0, 0);
	}

	public static void AddMove(PlayerEntity player, WeaponContext weapon)
	{
		player.AddMove(newNotMove: false, null, new RootMotionAnimationAdapter(player), newOnGround: true, Vector3.zero, 0, newRunUpMax: false, 0f, 0, newMoving: false, 0f, 0, 0, 0, 0, 0f, newBeingHit: false, 0, newIsSwitchWalk: false, 0f, newIsLimitMaxSpeed: true, newLimitSpeedInJumpRule: true, newCtrlDuck: false, newAnimPosition: false, newAnimPositionChangeYaw: false, 0, newActThirdMove: false, 0, newKeepFly: false, 0, 0, 0, 0);
	}

	public static void AddPostionErrorSmooth(PlayerEntity player)
	{
		player.AddPostionErrorSmooth(1, Vector3.zero, 0, Vector3.zero);
	}

	public static void AddFov(PlayerEntity player)
	{
		player.AddFov(90, 90, newResumeZoom: false, 90, newIsHideFristView: false);
	}

	public static void AddHitBox(PlayerEntity player)
	{
		player.AddHitBox(new List<HitBox>(), new HitPreliminaryGeo(), new Dictionary<int, Transform>(), newHitBoxBrushDirty: true, new List<HitBoxBrush>());
	}

	public static void AddDecay(PlayerEntity playerEntity)
	{
		playerEntity.AddDecay(0);
	}

	public static void AddViewHeight(PlayerEntity playerEntity)
	{
		playerEntity.AddViewHeight(0f, 0f, 0);
	}

	public static void AddState(PlayerEntity playerEntity)
	{
		playerEntity.AddState(0);
	}

	public static void AddPunchSmooth(PlayerEntity playerEntity)
	{
		playerEntity.AddPunchSmooth(0f, 0f);
	}

	public static void AddEvents(PlayerEntity playerEntity)
	{
		playerEntity.AddEvents(null, null);
	}

	public static void AddBuff(PlayerEntity playerEntity)
	{
		playerEntity.AddBuff(new Dictionary<string, IPlayerBuff>(), new List<int>(), -1);
	}

	public static void AddLife(PlayerEntity playerEntity)
	{
		playerEntity.AddLife(newIsDead: false);
	}

	public static void AddEventParticles(PlayerEntity playerEntity)
	{
		playerEntity.AddEventParticle(new Dictionary<int, IEventParticle>(), 0);
	}

	public static void CleanupFirstPersonUnityObjects(PlayerEntity playerEntity)
	{
		if (!playerEntity.hasFirstPersonUnityObjects)
		{
			return;
		}
		if (RuleUtilty.EnableAvater())
		{
			WeaponUtility.UseInputShader(playerEntity, "SSJJ/Diffuse");
		}
		CollectReusable(playerEntity.firstPersonUnityObjects.HandCameraObject);
		CollectReusable(playerEntity.firstPersonUnityObjects.HandGameObject);
		CollectReusable(playerEntity.firstPersonUnityObjects.WeaponGameObject);
		if (playerEntity.firstPersonUnityObjects.KnifeEffectGameObject != null)
		{
			CollectReusable(playerEntity.firstPersonUnityObjects.KnifeEffectGameObject);
		}
		if (playerEntity.hasViewAccessory)
		{
			for (int num = playerEntity.viewAccessory.Renders.Count - 1; num >= 0; num--)
			{
				CollectReusable(playerEntity.viewAccessory.Renders[num].getGameObject());
				playerEntity.viewAccessory.Renders.RemoveAt(num);
			}
			playerEntity.RemoveViewAccessory();
		}
		playerEntity.firstPersonUnityObjects.HandGameObject = null;
		playerEntity.firstPersonUnityObjects.WeaponGameObject = null;
		playerEntity.firstPersonUnityObjects.KnifeEffectGameObject = null;
		playerEntity.RemoveFirstPersonUnityObjects();
	}

	public static void CleanupThirdPersonUnityObjects(PlayerEntity playerEntity)
	{
		if (playerEntity.hasThirdPersonUnityObjects)
		{
			playerEntity.thirdPersonUnityObjects.Clear();
			LodUtility.RemoveParticleLod(playerEntity.thirdPersonUnityObjects.WeaponParticles);
			LodUtility.RemoveParticleLod(playerEntity.thirdPersonUnityObjects.PlayerParticles);
			if (playerEntity.thirdPersonUnityObjects.OutLineAdded)
			{
				foreach (SkinnedMeshRenderer careerSkin in playerEntity.thirdPersonUnityObjects.CareerSkins)
				{
					Outline component = careerSkin.GetComponent<Outline>();
					if (component != null)
					{
						Object.Destroy(component);
					}
				}
				playerEntity.thirdPersonUnityObjects.OutLineAdded = false;
			}
			if (playerEntity.thirdPersonUnityObjects.Avater != null)
			{
				playerEntity.thirdPersonUnityObjects.Avater.Release();
			}
			if (playerEntity.thirdPersonUnityObjects.KnifeEffectGameObject != null)
			{
				CollectReusable(playerEntity.thirdPersonUnityObjects.KnifeEffectGameObject);
			}
			playerEntity.thirdPersonUnityObjects.ThirdTran.WeaponObj.transform.localScale = Vector3.one;
			CollectReusable(playerEntity.thirdPersonUnityObjects.ThirdTran.WeaponObj);
			CollectReusable(playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer);
			Object.Destroy(playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer);
			playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer = null;
			playerEntity.RemoveThirdPersonUnityObjects();
			if (playerEntity.hasThirdBoneCache && playerEntity.thirdBoneCache.Cache != null)
			{
				DictionaryPool<GameObject, Vector3>.Release(playerEntity.thirdBoneCache.Cache);
				playerEntity.thirdBoneCache.Cache = null;
				playerEntity.thirdBoneCache.LeftGameObject = null;
				playerEntity.thirdBoneCache.RighGameObject = null;
			}
		}
		if (playerEntity.hasAcgShadow)
		{
			CollectReusable(playerEntity.acgShadow.AcgShadow);
			playerEntity.RemoveAcgShadow();
		}
		CleanupBackAccessoryUnityObjects(playerEntity);
		CleanupBackWeaponUnityObjects(playerEntity);
		CleanupWaistJewelryUnityObjects(playerEntity);
	}

	public static void CleanupWaistJewelryUnityObjects(PlayerEntity playerEntity, bool isClearLoadedList = true)
	{
		if (playerEntity.hasWaistJewelryAccessory)
		{
			foreach (IAccessoryRenderComponent render in playerEntity.waistJewelryAccessory.Renders)
			{
				LodUtility.RemoveParticleLod(render.getPatricles());
				CollectReusable(render.getGameObject());
			}
			playerEntity.RemoveWaistJewelryAccessory();
		}
		if (playerEntity.hasWaistJewelryAccessoryLoadList && isClearLoadedList)
		{
			playerEntity.RemoveWaistJewelryAccessoryLoadList();
		}
	}

	public static void CleanupBackAccessoryUnityObjects(PlayerEntity playerEntity)
	{
		if (playerEntity.hasBackAccessoryUnityObjects)
		{
			CollectReusable(playerEntity.backAccessoryUnityObjects.Render.getGameObject());
			playerEntity.RemoveBackAccessoryUnityObjects();
		}
	}

	public static void CleanupBackWeaponUnityObjects(PlayerEntity playerEntity)
	{
		if (playerEntity.hasBackWeaponUnityObjects)
		{
			CollectReusable(playerEntity.backWeaponUnityObjects.Render.getGameObject());
			playerEntity.RemoveBackWeaponUnityObjects();
		}
	}

	public static string GetPlayerEntityWeaponSkinName(int entityId)
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(entityId);
		if (entityWithEntityId != null && entityWithEntityId.hasBasicInfo && entityWithEntityId.basicInfo.Current != null)
		{
			return entityWithEntityId.basicInfo.Current.CurrentWeaponSkinName;
		}
		return null;
	}

	public static void CleanupNpcUnityObjects(SceneObjectEntity entity)
	{
		if (entity.hasNpcUnityObjects)
		{
			LodUtility.RemoveParticleLod(entity.npcUnityObjects.EffectGameObjects);
			CollectReusable(entity.npcUnityObjects.RootContainer);
			Object.Destroy(entity.npcUnityObjects.NameText.gameObject);
			Object.Destroy(entity.npcUnityObjects.RootContainer);
			entity.RemoveNpcUnityObjects();
		}
		if (entity.hasNpcHp)
		{
			CollectReusable(entity.npcHp.Hp);
			entity.RemoveNpcHp();
		}
	}

	public static void CleanupChickenUnityObjects(SceneObjectEntity entity)
	{
		if (entity.hasChickenUnityObjects)
		{
			CollectReusable(entity.chickenUnityObjects.Root);
			entity.RemoveChickenUnityObjects();
		}
	}

	public static void CollectReusable(GameObject obj)
	{
		ReusableGameObjectBase componentInChildren = obj.GetComponentInChildren<ReusableGameObjectBase>();
		if (componentInChildren != null)
		{
			Contexts.sharedInstance.battleRoom.gameObjectPool.Pool.Collect(componentInChildren);
		}
		else
		{
			Object.Destroy(obj);
		}
	}

	public static void AddNormalTrace(PlayerEntity playerEntity)
	{
		playerEntity.AddNormalTrace(-1, new List<int>(), Vector3.zero);
	}

	public static void AddHeadScale(PlayerEntity playerEntity)
	{
		playerEntity.AddHeadScale(1f);
	}
}

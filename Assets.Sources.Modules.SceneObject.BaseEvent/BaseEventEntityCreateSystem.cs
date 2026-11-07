using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Framework;
using Assets.Sources.Modules.SceneObject.BaseEvent.Creator;
using Assets.Sources.Modules.WorldCamera;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Constant;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.BaseEvent;

internal class BaseEventEntityCreateSystem : IEntityCreateSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly PlayerContext _playerContext;

	private readonly WeaponContext _weaponContext;

	private readonly MessageContext _messageContext;

	private readonly TimeContext _timeContext;

	private readonly Dictionary<int, IBaseEventCreator> _creators = new Dictionary<int, IBaseEventCreator>();

	private int _lastSnapshotId;

	public BaseEventEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_messageContext = contexts.message;
		_timeContext = contexts.time;
		_creators.Add(81, new Vertogo());
		_creators.Add(67, new SoundEvent(SoundSystemTable.SoundSubtype.Operate, SoundResourceUtility.GetCommonSoundUrl("pickweapon"), SoundType.Weapon));
		_creators.Add(1153, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundAssetInfo("ak47_legend_2", ""), SoundType.Weapon, is3D: true));
		_creators.Add(10048, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("awm_legend_ct"), SoundType.Weapon, is3D: true));
		_creators.Add(10047, new SoundEvent(SoundSystemTable.SoundSubtype.Shoot, SoundResourceUtility.GetWeaponSoundFireAssetInfo("awm_legend_ct"), SoundType.Environment, is3D: true));
		_creators.Add(1243, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("abyss_blade"), SoundType.Weapon, is3D: true));
		_creators.Add(1244, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("abyss_blade1"), SoundType.Weapon, is3D: true));
		_creators.Add(1245, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("abyss_blade2"), SoundType.Weapon, is3D: true));
		_creators.Add(21000, new SoundToggleEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetChickenFlySoundUrl(), loop: false));
		_creators.Add(21001, new SoundDistanceEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetChickenLandSoundUrl(), loop: false));
		_creators.Add(21004, new SoundDistanceEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetPigJumpLandSoundUrl(), loop: false));
		_creators.Add(21005, new SoundDistanceEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetPigJumpSoundUrl(), loop: false));
		_creators.Add(21002, new SoundToggleEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetCatSprintSoundUrl(), loop: false, 10f));
		_creators.Add(21003, new SoundDistanceEvent(SoundSystemTable.SoundSubtype.Other, SoundResourceUtility.GetCatStopSoundUrl(), loop: false));
		_creators.Add(1268, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("justice_from_above"), SoundType.Weapon, is3D: true));
		_creators.Add(1270, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkill2AssetInfo("justice_from_above"), SoundType.Weapon, is3D: true));
		_creators.Add(1336, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundFire4AssetInfo("claymore_tactical_360"), SoundType.Weapon, is3D: true));
		_creators.Add(1400, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("trick_dagger"), SoundType.Weapon, is3D: true));
		_creators.Add(1300, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, SoundResourceUtility.GetWeaponSoundSkillAssetInfo("rider_slingshot"), SoundType.Weapon, is3D: true));
		_creators.Add(1405, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, ParticleManager.Instance().TryGetSoundAsset(1405), SoundType.Weapon, is3D: true));
		_creators.Add(1406, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, ParticleManager.Instance().TryGetSoundAsset(1406), SoundType.Weapon, is3D: true));
		_creators.Add(1407, new SoundEvent(SoundSystemTable.SoundSubtype.Skill, ParticleManager.Instance().TryGetSoundAsset(1407), SoundType.Weapon, is3D: true));
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null || nowSnapshot.SeqId == _lastSnapshotId)
		{
			return;
		}
		_lastSnapshotId = nowSnapshot.SeqId;
		foreach (KeyValuePair<int, BaseEventEntityData> item in nowSnapshot.BaseEventEntityDataDict)
		{
			BaseEventEntityData value = item.Value;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(value.OwnerId);
			bool flag = entityWithEntityId?.isMyPlayer ?? false;
			if (_sceneObjectContext.GetEntityWithEntityId(value.Id) != null)
			{
				continue;
			}
			if (_creators.ContainsKey(value.EventId))
			{
				_creators[value.EventId].Create(value, _playerContext, _sceneObjectContext);
				continue;
			}
			if (ParticleManager.Instance().TryGetSound(value.EventId, out var data))
			{
				Vector3? entityPosition = null;
				if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.hasFpos)
				{
					entityPosition = _playerContext.cameraOwnerEntity.GetCompenstatePos(_playerContext.cameraOwnerEntity.fpos.Change.GetPosIndex());
				}
				FireUtility.PlayConfigSound(data, value, entityPosition);
				continue;
			}
			if (value.EventId == 1034)
			{
				NotifyManager.ForceInvoke(8);
				continue;
			}
			if (value.EventId == 1035)
			{
				NotifyManager.ForceInvoke(9);
				continue;
			}
			if (value.EventId == 1141)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/ak47_legent_skill1.mp3"), GameSoundManager.Config.WeaponVolume);
				continue;
			}
			if (value.EventId == 1145)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/ak47_legent_skill2.mp3"), GameSoundManager.Config.WeaponVolume);
				continue;
			}
			if (value.EventId == 33)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Other, flag, new AssetInfo("sound/deathmatch", "Assets/Res/Assets/sound/deathmatch/relive.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(value.X, value.Y, value.Z)), GameSoundManager.Config.AsideVolume, 3000);
				continue;
			}
			if (value.EventId == 1197)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/weapon/darts_redflash1_skill", "Assets/Res/Assets/sound/weapon/darts_redflash1_skill.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(value.X, value.Y, value.Z)), GameSoundManager.Config.WeaponVolume, 10000);
				continue;
			}
			if (value.EventId == 1153)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/weapon/ak47_legend_2", "Assets/Res/Assets/sound/weapon/ak47_legend_2.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(value.X, value.Y, value.Z)), GameSoundManager.Config.WeaponVolume, 10000);
				continue;
			}
			if (value.EventId == 1208)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/weapon/sword_hell_snake_skill", "Assets/Res/Assets/sound/weapon/sword_hell_snake_skill.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(value.X, value.Y, value.Z)), GameSoundManager.Config.WeaponVolume, 10000);
				continue;
			}
			if (value.EventId == 1202)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_PHOTO_SWORD_COMBINATION_USEKNIFE"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1267)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("AMMO_NO_ENOUGH"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1624)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_FAIL_TO_RECEIVE"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1271)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CHOOSE_TARGET"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1272)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("IN_BATTLE"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100013)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_M99_SKILL"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1609)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_MAX_BONUS_ALREADY"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1608)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CANNOT_STUCK"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100065)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_HIPPO_GRENADE_NOTARGET"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100014)
			{
				long nextSkillTimer = _weaponContext.currentWeaponEntity.basicInfo.Data.NextSkillTimer;
				int clientTime = _playerContext.myPlayerEntity.clientTime.ClientTime;
				int value2 = (int)Mathf.Ceil((float)(nextSkillTimer - clientTime) / 1000f);
				string text = ScriptLocalization.Get("EV_CANDY_PISTOL_CAN_NOT_FIRE").Replace("s", StringCache.IntToString(value2));
				_messageContext.messageRemindData.SetMessage(text, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1819)
			{
				string text2 = ScriptLocalization.Get("RAINBOW_PISTOL_LETTER");
				_messageContext.messageRemindData.SetMessage(text2, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100149)
			{
				string text3 = ScriptLocalization.Get("EV_SHOTGUN_LEGEND_IMMUNE_DEAD");
				_messageContext.messageRemindData.SetMessage(text3, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1612)
			{
				int value3 = (_weaponContext.currentWeaponEntity.hasPower ? _weaponContext.currentWeaponEntity.power.Power : 0);
				string text4 = ScriptLocalization.Get("EV_PLEASE_RETRY_AFTER_LEFT").Replace("s", StringCache.IntToString(value3));
				_messageContext.messageRemindData.SetMessage(text4, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 30013)
			{
				long weaponTimer = _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponTimer1;
				int serverTime = _timeContext.time.ServerTime;
				int value4 = (int)Mathf.Ceil((float)(weaponTimer - serverTime) / 1000f);
				string text5 = ScriptLocalization.Get("EV_THUNDER_LEGEND_MESSAGE").Replace("s", StringCache.IntToString(value4));
				_messageContext.messageRemindData.SetMessage(text5, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 30014)
			{
				int number = _playerContext.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.THUNDER_LEGEND_SPURT_CD.ID].Number;
				int serverTime2 = _timeContext.time.ServerTime;
				int value5 = (int)Mathf.Ceil((float)(number - serverTime2) / 1000f);
				string text6 = ScriptLocalization.Get("EV_THUNDER_LEGEND_MESSAGE").Replace("s", StringCache.IntToString(value5));
				_messageContext.messageRemindData.SetMessage(text6, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100125)
			{
				int number2 = _playerContext.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.FISSURE_TRAVELLER_SUBMACHINEGUN_FAKER_CD.ID].Number;
				int serverTime3 = _timeContext.time.ServerTime;
				int value6 = (int)Mathf.Ceil((float)(number2 - serverTime3) / 1000f);
				string text7 = ScriptLocalization.Get("EV_FISSURE_TRAVELLER_SUBMACHINEGUN_FAKER_CD").Replace("s", StringCache.IntToString(value6));
				_messageContext.messageRemindData.SetMessage(text7, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1693)
			{
				_ = _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponTimer1;
				_ = _timeContext.time.ServerTime;
				int value7 = (int)Mathf.Ceil((float)value.Data / 1000f);
				string text8 = ScriptLocalization.Get("EV_NIGHT_OWL_SUBMACHINEGUN").Replace("s", StringCache.IntToString(value7));
				_messageContext.messageRemindData.SetMessage(text8, 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1613)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_SKY_DOME_BEACON_COOL_DOWN"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1614)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_SUPER_AREA_CANNOT_EVOLVE"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1621)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_SKY_DOME_CAN_EVOLVE"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1622)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_PLEASE_EVOLVE_AFTER_APPROACHED"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1623)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_SUMMON_MAXIMUM_ALREADY"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1638)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_WHITE_SWORD_GUN_ENERGY_NOT_ENOUGH"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 110003)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_LIGHT_BIRTH_EXPLOISION_WARNNING"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 110006)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_KNIFE_WHEEL_SPRINT_WARNING"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 110011)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_TRAP_NO_NUM_WARNNING"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160002)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_BIG_HEAD_KNIFE2_ADD_BUFF_SUCCESS"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160003)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_BIG_HEAD_KNIFE2_GET_BUFF_SUCCESS"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160006)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_BIG_HEAD_KNIFE2_CHANGE_WEAPON12"), 2000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160004)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_BIG_HEAD_KNIFE2_CHANGE_WEAPON_LOCK"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160007)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_BIG_HEAD_KNIFE2_THROW_WEAPON"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160001)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_XRAYING_WARNING"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1680)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("GLAIVE_FAIL_TO_RECEIVE"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1681)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("GLAIVE_EXCEED_MAX_DISTANCE"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1682)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("DARTS_REDFLASH_RETURNDESTORY"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 160014)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_SNAKE_CANNOT_USING_V"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100003)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CRYSTAL_BOW_DAOXIANG"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 100004)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CRYSTAL_BOW_JICHU"), 1000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37001)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF1"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37002)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF2"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37003)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF3"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37004)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF4"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37005)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF5"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 37006)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLADE_STRONGHOLD_GET_BUFF6"));
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 1412)
			{
				GrenadeExplosionEventEntityData grenadeExplosionEventEntityData = new GrenadeExplosionEventEntityData();
				grenadeExplosionEventEntityData.CollisionPoint = new Vector3DData();
				grenadeExplosionEventEntityData.CollisionPoint.X = value.X;
				grenadeExplosionEventEntityData.CollisionPoint.Y = value.Y;
				grenadeExplosionEventEntityData.CollisionPoint.Z = value.Z;
				Contexts.sharedInstance.gameRule.flashExplosionData.Data = grenadeExplosionEventEntityData;
				continue;
			}
			if (value.EventId == 1333)
			{
				if (entityWithEntityId == null)
				{
					continue;
				}
				if (!flag)
				{
					if (entityWithEntityId.hasEventGhost)
					{
						entityWithEntityId.ReplaceEventGhost(value.Data);
					}
					else
					{
						entityWithEntityId.AddEventGhost(value.Data);
					}
					continue;
				}
				foreach (ICameraLogic cameraLogic in BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList)
				{
					if (cameraLogic.CameraMode() == PlayerCameraModeEnum.Third && cameraLogic.IsActive())
					{
						if (entityWithEntityId.hasEventGhost)
						{
							entityWithEntityId.ReplaceEventGhost(value.Data);
						}
						else
						{
							entityWithEntityId.AddEventGhost(value.Data);
						}
					}
				}
				continue;
			}
			if (value.EventId == 31004)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_GREY_CORE_CHANGE_ACTIVE"), 2000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			if (value.EventId == 31005)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_GREY_CORE_CHANGE_UNACTIVE"), 2000);
				NotifyManager.ForceInvoke(38);
				continue;
			}
			EventEffectData eventEntityData = ParticleManager.Instance().GetEventEntityData(value.EventId);
			if (eventEntityData != null)
			{
				SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddBaseEvent(value);
				sceneObjectEntity.AddLoadBaseEventResource(new LoadRequests(eventEntityData.AssetInfo), value.EventId);
				if (eventEntityData.viewAttach)
				{
					if (value.Data == Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.Id)
					{
						Transform transform = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform;
						Vector3 vector = transform.rotation * (Vector3.forward * eventEntityData.viewAttachX + Vector3.left * eventEntityData.viewAttachY + Vector3.up * eventEntityData.viewAttachZ);
						sceneObjectEntity.AddPosition(VectorCoordConverter.UnityToSsjj(transform.position + vector));
					}
					else
					{
						sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
					}
				}
				else
				{
					sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
				}
				sceneObjectEntity.AddOrientation(value.Yaw, value.Pitch, 0f, 0f, 0f, 0f, 0f);
				Vector3 one = Vector3.one;
				if (value.Scale != null)
				{
					if (value.Scale.XSpecified)
					{
						one.x = value.Scale.X;
					}
					if (value.Scale.YSpecified)
					{
						one.y = value.Scale.Y;
					}
					if (value.Scale.ZSpecified)
					{
						one.z = value.Scale.Z;
					}
				}
				sceneObjectEntity.AddScale(VectorCoordConverter.SsjjScaleToUnity(one));
			}
			else if (value.EventId != 1069 && value.EventId != 0 && value.EventId != 20 && value.EventId != 28 && value.EventId != 4 && value.EventId != 1404 && value.EventId != 1405 && value.EventId != 100005 && value.EventId != 100006 && value.EventId != 100098 && value.EventId != 100099 && value.EventId != 110009 && value.EventId != 100101)
			{
				this.LogErrorFormat("BaseEventEntityCreateSystem Unknow eventid:{0}", value.EventId);
			}
		}
	}
}

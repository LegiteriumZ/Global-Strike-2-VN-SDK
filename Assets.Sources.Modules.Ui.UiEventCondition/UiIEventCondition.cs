using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Components.Interface.Info.Quest;
using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Components.Message.Common;
using Assets.Sources.Components.Message.DeathMatch;
using Assets.Sources.Components.PlayerBag;
using Assets.Sources.Components.Rader;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Free.Data;
using Assets.Sources.Info.Quest;
using Assets.Sources.Info.Weapon;
using Entitas;
using I2.Loc;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;
using physics;
using share;
using share.constant;
using weapon.predicateSystem;
using weapon.utils;

namespace Assets.Sources.Modules.Ui.UiEventCondition;

public class UiIEventCondition
{
	public class UiEventUtils
	{
		public static bool True = true;

		public static bool False = false;

		public static int One = 1;

		public static HashSet<string> GoldFontWeapons = new HashSet<string> { "rpk_legend_ct", "rpk_legend_t", "ak47_legend_ct", "ak47_legend_t" };

		public static Dictionary<int, SkillInfoData> GetCameraOwnerSkills()
		{
			if (CameraOwnerEntity == null || !CameraOwnerEntity.hasSkill)
			{
				return null;
			}
			return CameraOwnerEntity.skill.Skills;
		}

		public static bool HasCameraOwnerStatus(int statusId)
		{
			if (CameraOwnerEntity != null && CameraOwnerEntity.skill != null)
			{
				return CameraOwnerEntity.HasStatus(statusId);
			}
			return false;
		}

		public static int GetCameraOwnerStatus(int statusId)
		{
			if (HasCameraOwnerStatus(statusId))
			{
				return CameraOwnerEntity.skill.Status[statusId].Number;
			}
			return 0;
		}

		public static PlayerInfoData GetCameraOwnerPlayerInfo()
		{
			if (CameraOwnerEntity != null)
			{
				return CameraOwnerEntity.GetPlayerInfo();
			}
			return null;
		}

		public static bool HasCameraOwnerState(int flag)
		{
			if (CameraOwnerEntity != null)
			{
				return CameraOwnerEntity.HasState(flag);
			}
			return false;
		}

		public static PlayerBagData GetCurrentBag()
		{
			return Contexts.sharedInstance.playerBag.currentBagEntity?.basicInfo.Data;
		}

		public static BaseWeaponData GetWeaponFormBag()
		{
			if (CameraOwnerEntity == null)
			{
				return null;
			}
			PlayerBagData currentBag = GetCurrentBag();
			if (currentBag == null)
			{
				return null;
			}
			int weapon = CameraOwnerEntity.currentWeapon.Weapon;
			int index = CameraOwnerEntity.currentWeapon.Index;
			switch (weapon)
			{
			case 5:
				if (SnapshotEntity != null && SnapshotEntity.hasSnapshots && SnapshotEntity.snapshots.LatestSnapshot != null && SnapshotEntity.snapshots.LatestSnapshot.BagList != null)
				{
					return SnapshotEntity.snapshots.LatestSnapshot.BagList.C4Weapon;
				}
				return null;
			case 1:
				return currentBag.FirstWeapon;
			case 2:
				return currentBag.SecondaryWeapon;
			case 3:
				return currentBag.MeleeWeapon;
			case 4:
				switch (index)
				{
				case 0:
					return currentBag.BombWeapons0;
				case 1:
					return currentBag.BombWeapons1;
				case 2:
					return currentBag.BombWeapons2;
				}
				break;
			}
			return null;
		}

		public static string GetWeaponName()
		{
			if (CurrentWeaponEntity == null || !CurrentWeaponEntity.hasBasicInfo)
			{
				return "";
			}
			return CurrentWeaponEntity.basicInfo.Data.WeaponName;
		}

		public static int GetWeaponEffectLevel()
		{
			if (CurrentWeaponEntity != null)
			{
				if (!CurrentWeaponEntity.hasSpecial)
				{
					return 0;
				}
				return CurrentWeaponEntity.special.EffectLevel;
			}
			return 0;
		}
	}

	public const int MAX_ACG_TEAM_MATE = 2;

	private static readonly List<PlayerEntity> AcgTeamPlayerEntityList = new List<PlayerEntity>(2);

	private static readonly List<PlayerEntity> AcgAllPlayerEntityList = new List<PlayerEntity>(3);

	private static List<IAcgQuest> AcgQuestList = new List<IAcgQuest>();

	private static IGroup<PlayerEntity> _otherShowAk47Group;

	public static Dictionary<long, PlayerEntity> Cid2PlayerEntity = new Dictionary<long, PlayerEntity>();

	public static PlayerEntity CameraOwnerEntity;

	public static WeaponEntity CurrentWeaponEntity;

	public static SnapshotEntity SnapshotEntity;

	public static PlayerEntity MyPlayerEntity;

	private static readonly List<PlayerEntity> PlayerEntityList = new List<PlayerEntity>(32);

	public static List<PlayerEntity> Get_AcgTeamPlayerEntity()
	{
		AcgTeamPlayerEntityList.Clear();
		if (Contexts.sharedInstance.player.cameraOwnerEntity.IsObserver())
		{
			foreach (PlayerEntity item in Contexts.sharedInstance.player)
			{
				if (item.basicInfo.Current.Id != Contexts.sharedInstance.snapshot.snapshots.GetCurrentObserver() && item.GetTeam() == MyPlayerEntity.GetTeam())
				{
					AcgTeamPlayerEntityList.Add(item);
				}
			}
		}
		else
		{
			foreach (PlayerEntity item2 in Contexts.sharedInstance.player)
			{
				if (item2 != null && !item2.IsMySelf() && !item2.IsBot() && item2.GetTeam() == MyPlayerEntity.GetTeam())
				{
					AcgTeamPlayerEntityList.Add(item2);
				}
			}
		}
		return AcgTeamPlayerEntityList;
	}

	public static List<PlayerEntity> Get_AcgAllPlayerEntity()
	{
		AcgAllPlayerEntityList.Clear();
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item != null && !item.IsBot() && item.GetTeam() == MyPlayerEntity.GetTeam())
			{
				AcgAllPlayerEntityList.Add(item);
			}
		}
		return AcgAllPlayerEntityList;
	}

	public static List<IAcgQuest> Get_AcgQuestList()
	{
		if (Contexts.sharedInstance.gameRule.acgQuest.AcgQuestList == null)
		{
			return AcgQuestList;
		}
		return Contexts.sharedInstance.gameRule.acgQuest.AcgQuestList;
	}

	public static int Get_hpProgressData_AcgTargetId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.AcgTargetId;
	}

	public static float Get_hpProgressData_AcgTargetHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.AcgTargetHpPercent;
	}

	public static float Get_hpProgressData_AcgTargetHpDamagePercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.AcgTargetHpDamagePercent;
	}

	public static float Get_hpProgressData_AcgTargetShieldHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.AcgTargetShieldHpPercent;
	}

	public static long Get_cameraOwnerData_AcgShieldHp()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.AcgShieldHp;
		}
		return 0L;
	}

	public static int Get_cameraOwnerData_AcgCoin()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.AcgGold;
		}
		return 0;
	}

	public static List<int> Get_cameraOwnerData_AcgBuffList()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBuff)
		{
			return CameraOwnerEntity.buff.AcgBuffs;
		}
		return null;
	}

	public static int Get_AcgCharacterSkillName()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill.SkillName;
		}
		return 0;
	}

	public static int Get_AcgWeaponSkillName()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill.SkillName;
		}
		return 0;
	}

	public static int Get_AcgCharacterEnergy()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill.Energy;
		}
		return 0;
	}

	public static int Get_AcgWeaponEnergy()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill.Energy;
		}
		return 0;
	}

	public static bool Get_AcgCharacterSilented()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgCharacterSkill.IsSilent;
		}
		return false;
	}

	public static bool Get_AcgWeaponSilented()
	{
		if (Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill != null)
		{
			return Contexts.sharedInstance.gameRule.acgSkill.AcgWeaponSkill.IsSilent;
		}
		return false;
	}

	public static int Get_PlayerEntity_AcgPlayerDamage(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0;
		}
		return player.basicInfo.Current.AcgDamage;
	}

	public static int Get_PlayerEntity_AcgPlayerCoin(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0;
		}
		return player.basicInfo.Current.AcgGold;
	}

	public static int Get_PlayerEntity_AcgPlayerCommonPU(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0;
		}
		return player.basicInfo.Current.AcgGeneralBenefitCount;
	}

	public static int Get_PlayerEntity_AcgPlayerCharacterPU(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0;
		}
		return player.basicInfo.Current.AcgCareerBenefitCount;
	}

	public static int Get_PlayerEntity_AcgPlayerWeaponPU(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0;
		}
		return player.basicInfo.Current.AcgWeaponBenefitCount;
	}

	public static int Get_CameraOwner_AcgPlayerCommonPU()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.AcgGeneralBenefitCount;
		}
		return 0;
	}

	public static int Get_CameraOwner_AcgPlayerCharacterPU()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.AcgCareerBenefitCount;
		}
		return 0;
	}

	public static int Get_CameraOwner_AcgPlayerWeaponPU()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.AcgWeaponBenefitCount;
		}
		return 0;
	}

	public static Queue<GameMessageDataComponent.AcgMessageData> Get_AcgMessageQueue()
	{
		if (Contexts.sharedInstance.message.gameMessageData.AcgMessageQueue != null)
		{
			return Contexts.sharedInstance.message.gameMessageData.AcgMessageQueue;
		}
		return null;
	}

	public static int Get_AcgQuestId(AcgQuest quest, int idx)
	{
		return quest.id;
	}

	public static bool Get_AcgQuestStatus(AcgQuest quest, int idx)
	{
		return quest.isCleared;
	}

	public static int GetPlayerMoney()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetPlayerInfo().Money;
		}
		return 0;
	}

	public static int GetPlayerStar()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetPlayerInfo().Star;
		}
		return 0;
	}

	public static int GetPlayerGp()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetPlayerInfo().Gp;
		}
		return 0;
	}

	public static string Get_PlayerEntity_PlayerName(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return "";
		}
		return player.basicInfo.Current.PlayerName;
	}

	public static long Get_PlayerEntity_PlayerHp(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return 0L;
		}
		return player.basicInfo.Current.Hp;
	}

	public static bool Get_PlayerEntity_IsDead(PlayerEntity player, int idx)
	{
		if (!player.hasBasicInfo)
		{
			return false;
		}
		return player.basicInfo.Current.IsDead;
	}

	public static List<int> Get_PlayerEntity_AcgBuffs(PlayerEntity player, int idx)
	{
		if (!player.hasBuff)
		{
			return null;
		}
		return player.buff.AcgBuffs;
	}

	public static string Get_OneKillInfoData_PlayerName(OneKillInfoData val, int idx)
	{
		return val.PlayerName;
	}

	public static int Get_OneKillInfoData_VipLevel(OneKillInfoData val, int idx)
	{
		int value = 0;
		Contexts.sharedInstance.battleRoom.playerInfo.VipLevels.TryGetValue(val.PlayerName, out value);
		return value;
	}

	public static string Get_OneKillInfoData_TeamName(OneKillInfoData val, int idx)
	{
		return val.TeamName;
	}

	public static int Get_OneKillInfoData_Level(OneKillInfoData val, int idx)
	{
		return val.Lv;
	}

	public static int Get_OneKillInfoData_Team(OneKillInfoData val, int idx)
	{
		return val.Team;
	}

	public static bool Get_OneKillInfoData_HasHeroWeapon(OneKillInfoData val, int idx)
	{
		return val.HasHeroWeapon;
	}

	public static int Get_OneKillInfoData_SavePoint(OneKillInfoData val, int idx)
	{
		return val.SavePoint;
	}

	public static int Get_OneKillInfoData_ReadPoint(OneKillInfoData val, int idx)
	{
		return val.ReadPoint;
	}

	public static int Get_OneKillInfoData_Ping(OneKillInfoData val, int idx)
	{
		return val.Ping;
	}

	public static int Get_OneKillInfoData_JumpTime(OneKillInfoData val, int idx)
	{
		return val.JumpTime;
	}

	public static int Get_OneKillInfoData_AdditionalTime(OneKillInfoData val, int idx)
	{
		return val.AdditionalTime;
	}

	public static string Get_OneKillInfoData_FastWeapon(OneKillInfoData val, int idx)
	{
		return val.FastWeapon;
	}

	public static bool Get_OneKillInfoData_Ace(OneKillInfoData val, int idx)
	{
		return val.Ace;
	}

	public static bool Get_OneKillInfoData_Ace2(OneKillInfoData val, int idx)
	{
		return val.Ace2;
	}

	public static bool Get_OneKillInfoData_Ace3(OneKillInfoData val, int idx)
	{
		return val.Ace3;
	}

	public static bool Get_OneKillInfoData_IsDead(OneKillInfoData val, int idx)
	{
		return val.IsDead;
	}

	public static bool Get_OneKillInfoData_LoginUnity(OneKillInfoData val, int idx)
	{
		return val.LoginUnity;
	}

	public static int Get_roomData_SceneId()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.SceneId;
	}

	public static bool Get_status_HurtDeep()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HURT_DEEP.ID);
		}
		return false;
	}

	public static bool Get_status_ShengHuaZhiDi()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SHENG_HUA_ZHI_DI_TEAM1.ID);
		}
		return false;
	}

	public static bool Get_status_PistolElectric()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HORMONE_EFFECT.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.PISTOL_ELECTRIC_MABI_EFFECT.ID);
			}
			return true;
		}
		return false;
	}

	public static bool Get_status_HolidayBossEffect()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HOILDAY_EFFECT_RANSHAO.ID);
		}
		return false;
	}

	public static bool Get_status_RevolverBattleEffect()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.REVOLVER_BATTLE_EFFECT.ID);
		}
		return false;
	}

	public static bool Get_status_SkinRevolverBattlePrupEffect()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SKIN_JUE_DOU_FLAG_PURPLESURGE.ID);
		}
		return false;
	}

	public static bool Get_status_DeadEyeFlag()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DEAD_EYE_FLAG.ID);
		}
		return false;
	}

	public static bool Get_status_SkinDeadEyeFlagPurp()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SKIN_DEAD_EYE_FLAG_PURPLESURGE.ID);
		}
		return false;
	}

	public static bool Get_status_SlowDownPistolFlag()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SLOW_DOWN_PISTOL_FLAG.ID);
		}
		return false;
	}

	public static bool Get_status_JinJie1()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.M4A1_JINJIE1.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CORE_SNIPER_XING_NENG_P1.ID);
			}
			return true;
		}
		return false;
	}

	public static bool Get_status_GaiaSniper_Flag()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.GAIA_SNIPER_FLAG.ID);
		}
		return false;
	}

	public static bool Get_status_GaiaSniper_Blink()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.GAIA_SNIPER_BLINK.ID);
		}
		return false;
	}

	public static bool Get_status_DiaoChan_Biyue1()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DIAOCHAN_BIYUE1.ID);
		}
		return false;
	}

	public static bool Get_status_DiaoChan_Biyue2()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DIAOCHAN_BIYUE2.ID);
		}
		return false;
	}

	public static bool Get_status_DiaoChan_Biyue3()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DIAOCHAN_BIYUE3.ID);
		}
		return false;
	}

	public static bool Get_status_DiaoChan_Biyue4()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DIAOCHAN_BIYUE4.ID);
		}
		return false;
	}

	public static bool Get_status_yufeng_p1()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DUST_SHOTGUN_DRIVE_WIND_P1.ID);
		}
		return false;
	}

	public static bool Get_status_rainbowpistol_combo()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.RAINBOW_PISTOL_COMBO.ID);
		}
		return false;
	}

	public static bool Get_status_JinJie2()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.M4A1_JINJIE2.ID);
		}
		return false;
	}

	public static bool Get_status_JinJie3()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.M4A1_JINJIE3.ID);
		}
		return false;
	}

	public static bool GetStatus_PingmuDuwu()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.rpg_10300401_pingmuduwu.ID);
		}
		return false;
	}

	public static bool GetStatus_JiShenti()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.Fx_Jiujijishenti_skill3_jishen.ID);
		}
		return false;
	}

	public static bool GetStatus_Jian()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.HasStatus(PlayerInfoStatusConstant.rpg_10600501_jian.ID);
		}
		return false;
	}

	public static bool GetStatus_Dun()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.HasStatus(PlayerInfoStatusConstant.rpg_10600501_dun.ID);
		}
		return false;
	}

	public static bool GetStatus_MAGIC_SHIELD()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.MAGIC_SHIELD.ID);
		}
		return false;
	}

	public static bool GetStatus_EV_SCAR_LEGEND_FLAG()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.EV_SCAR_LEGEND_FLAG.ID);
		}
		return false;
	}

	public static bool GetStatus_HASU_HUNLUANGUANGBO_VALUE()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.HOILDAY_EFFECT_HUNLUANGUANGBO_VALUE.ID);
	}

	public static bool GetStatus_LASER_HERO_PISTOL_SHIELD()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.LASER_HERO_PISTOL_SHIELD_NEW_P1.ID);
	}

	public static bool GetStatus_THERMAL_SCOPE()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.InXRaySee.ID);
	}

	public static bool GetStatus_HASU_YOULING_REBACK()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HaSuTaoZhuangJiNeng.ID);
		}
		return false;
	}

	public static bool GetStatus_CUTTLEFISH_GRENADE_IN_CHAOS()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CUTTLEFISH_GRENADE_IN_CHAOS.ID);
		}
		return false;
	}

	public static bool GetStatus_NianYe()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ICE_CREAM_EFFECT.ID);
		}
		return false;
	}

	public static bool GetStatus_FogHurt()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BE_HURT_BY_FOG.ID);
		}
		return false;
	}

	public static bool GetStatus_TANGYUANP1()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.TangYuanP1.ID);
		}
		return false;
	}

	public static bool GetStatus_Stealh()
	{
		PlayerContext player = Contexts.sharedInstance.player;
		if (player.isCameraOwner)
		{
			return player.cameraOwnerEntity.HasStatus(1260);
		}
		return false;
	}

	public static bool GetStatus_Hufeng_Quanping()
	{
		PlayerContext player = Contexts.sharedInstance.player;
		if (player.isCameraOwner)
		{
			return player.cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.GRENADE_WASP_BREATH_EFFECT.ID);
		}
		return false;
	}

	public static bool GetStatus_VOID_JUMP_TRANSPORT_P1()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.VOID_JUMP_TRANSPORT_P1.ID);
		}
		return false;
	}

	public static bool Get_State_Ammunitionpack()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.WINDWARD_WAITING.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.LASER_HERO_PISTOL_SHIELD_OLD_P1.ID);
			}
			return true;
		}
		return false;
	}

	public static bool GetStatus_STORM_SHOTGUN_SHIELD()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.STORM_SHOTGUN_SHIELD.ID);
		}
		return false;
	}

	public static bool GetStatus_SLIDE_STATUS()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SLIDE_STATUS.ID);
		}
		return false;
	}

	public static bool GetStatus_COZYWINTER_FROZEN_GRADUALLY()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.COZYWINTER_FROZEN_GRADUALLY.ID);
		}
		return false;
	}

	public static bool GetStatus_JIU_WEI_AIXIN_BEHIT()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.JIU_WEI_AIXIN_BEHIT.ID);
		}
		return false;
	}

	public static bool GetStatus_HYPER_REVOLVER_FIRE_RING_DURATION()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HYPER_REVOLVER_FIRE_RING_DURATION.ID);
		}
		return false;
	}

	public static bool GetStatus_WAVES_PAVEMENT()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HERO_SHARK_AIM.ID);
		}
		return false;
	}

	public static bool GetStatus_VOID_JUMP_MASK_EFFECT()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.VOID_JUMP_MASK_EFFECT.ID);
		}
		return false;
	}

	public static bool GetStatus_TWINS_INFINITE()
	{
		if (CurrentWeaponEntity == null || !CurrentWeaponEntity.hasBasicInfo)
		{
			return false;
		}
		if ((CurrentWeaponEntity.basicInfo.Data.WeaponName.Equals("twins_infinity1") || CurrentWeaponEntity.basicInfo.Data.WeaponName.Equals("twins_infinity2")) && (CurrentWeaponEntity.basicInfo.Data.EffectLevel & 2) > 0)
		{
			return true;
		}
		return false;
	}

	public static bool GetStatus_MouseYearBai()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.Prefab_buff_bai.ID);
		}
		return false;
	}

	public static bool GetStatus_MouseYearHong()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.Prefab_buff_hong.ID);
		}
		return false;
	}

	public static bool GetStatus_MouseYearHuang()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.Prefab_buff_huang.ID);
		}
		return false;
	}

	public static bool GetStatus_MouseYearLan()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.Prefab_buff_lan.ID);
		}
		return false;
	}

	public static bool Get_status_ElectricElementChongci()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ELECTRIC_ELEMENT_CHONGCI.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ELECTRIC_INTERACTION.ID);
			}
			return true;
		}
		return false;
	}

	public static bool Get_status_LongQibingUIEffect()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.rpg_LONGQIBING_125UIEffect.ID);
		}
		return false;
	}

	public static bool Get_status_RpgBeattackGedang()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.RPG_BEATTACK_GEDANG.ID);
		}
		return false;
	}

	public static bool Get_status_RpgButterflyGrenadeKill()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ButterflyGrenadeShield.ID);
		}
		return false;
	}

	public static bool Get_status_CyberPunkSwordBurn()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CYBER_PUNK_SWORD_BURN.ID) && !CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SuppressingP1.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.MpAdd.ID);
			}
			return true;
		}
		return false;
	}

	public static bool Get_status_WildFire()
	{
		if (CameraOwnerEntity != null && PlayerCareerConstantUtility.IsHumanity(CameraOwnerEntity.GetCareer()))
		{
			return CameraOwnerEntity.GetPlayerInfo().Wildfire;
		}
		return false;
	}

	public static bool Get_status_SoulLink()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SOUL_LINK_FLAG.ID);
		}
		return false;
	}

	public static bool Get_status_ExplodeOil()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.EXPLODE_OIL.ID);
		}
		return false;
	}

	public static bool Get_status_AddSpeed()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.P90_HERO_HUANRAO.ID);
		}
		return false;
	}

	public static bool Get_status_ShieldP1()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.IronShieldP1.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ExtremeShieldP1.ID);
			}
			return true;
		}
		return false;
	}

	public static bool GetStatus_EV_FEATHER_BOW_MARK_FLAG()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.EV_FEATHER_BOW_MARK_FLAG.ID);
		}
		return false;
	}

	public static bool GetStatus_LEGENDENERGY()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BREAK_STAR_MACHINEGUN_LEGEND_ENERGY.ID);
		}
		return false;
	}

	public static bool GetStatus_BERSERKER_AXE_HERO_SPIRIT()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BERSERKER_AXE_HERO_SPIRIT.ID))
			{
				return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.BERSERKER_AXE_HERO_SPIRIT_FIRE.ID);
			}
			return true;
		}
		return false;
	}

	public static bool GetStatus_HolyRosaryJinGang()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HolyRosaryJinGang.ID);
		}
		return false;
	}

	public static bool GetStatus_ZiLongHuTi()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.ZHAOYUN_RIFLE_DOUQIHUTI.ID);
		}
		return false;
	}

	public static bool GetStatus_RPG_BOSS_AI_GIRL_ELEC_P1_RED()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.RPG_BOSS_AI_GIRL_ELEC_P1_RED.ID);
		}
		return false;
	}

	public static bool GetStatus_RPG_BOSS_AI_GIRL_ELEC_P1_BLUE()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.RPG_BOSS_AI_GIRL_ELEC_P1_BLUE.ID);
		}
		return false;
	}

	public static bool GetStatus_GREY_CORE_STAR_CIRCLE()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.GREY_CORE_STAR_CIRCLE.ID);
		}
		return false;
	}

	public static bool GetStatus_DARKFIRE_RIFLE_POWER()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DARKFIRE_RIFLE_POWER.ID);
		}
		return false;
	}

	public static bool GetStatus_DARKFIRE_RIFLE_POWER_WAVE()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DARKFIRE_RIFLE_POWER_WAVE.ID);
		}
		return false;
	}

	public static bool GetStatus_SHOTGUN_LEGEND_BREAK()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.SHOTGUN_LEGEND_BREAK.ID))
			{
				return CameraOwnerEntity.HasStatus(10160090);
			}
			return true;
		}
		return false;
	}

	public static bool GetStatus_LIGHT_SNIPER_RAMPAGE()
	{
		if (CameraOwnerEntity != null)
		{
			if (!CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.LIGHT_SNIPER_RAMPAGE.ID) && !CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.LIGHT_SNIPER_THUNDER_FLAG.ID) && !CameraOwnerEntity.HasStatus(10160092))
			{
				return CameraOwnerEntity.HasStatus(10160093);
			}
			return true;
		}
		return false;
	}

	public static bool GetStatus_BLOCK_UMBRELLA()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(160095);
		}
		return false;
	}

	public static bool GetStatus_SKIN_BLOCK_UMBRELLA_FLOWER()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(10160095);
		}
		return false;
	}

	public static bool GetStatus_DARK_DIAMOND_WRATH()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.DarkDiamondWrath.ID);
		}
		return false;
	}

	public static long Get_OneKillInfoData_Score(OneKillInfoData val, int idx)
	{
		return val.Score;
	}

	public static int Get_OneKillInfoData_BeKillNum(OneKillInfoData val, int idx)
	{
		return val.BeKillNum;
	}

	public static string Get_OneKillInfoData_Career(OneKillInfoData val, int idx)
	{
		return val.Career;
	}

	public static bool Get_EngineEntity_InScreen(SimpleEngineEntityData val, int idx)
	{
		SceneObjectEntity entityWithEntityId = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(val.Id);
		if (entityWithEntityId == null || !entityWithEntityId.hasScreenPosition)
		{
			return false;
		}
		return entityWithEntityId.screenPosition.InScreen;
	}

	public static long Get_EngineEntity_Hp(SimpleEngineEntityData val, int idx)
	{
		return val.Hp;
	}

	public static UnityEngine.Vector3 Get_EngineEntity_Position(SimpleEngineEntityData val, int idx)
	{
		SceneObjectEntity entityWithEntityId = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(val.Id);
		if (entityWithEntityId == null || !entityWithEntityId.hasScreenPosition)
		{
			return UnityEngine.Vector3.zero;
		}
		return entityWithEntityId.screenPosition.Position;
	}

	public static string Get_SmallMapImageItem_Name(ISmallMapImageItem val, int idx)
	{
		return val.Name;
	}

	public static AssetInfo Get_SmallMapImageItem_SmallMapImage(ISmallMapImageItem val, int idx)
	{
		return val.SmallMapImage;
	}

	public static AssetInfo Get_SmallMapImageItem_RadarImage(ISmallMapImageItem val, int idx)
	{
		return val.RadarImage;
	}

	public static UnityEngine.Vector3 Get_SmallMapImageItem_Position(ISmallMapImageItem val, int idx)
	{
		return val.Position;
	}

	public static long Get_SmallMapImageItem_Hp(ISmallMapImageItem val, int idx)
	{
		return val.Hp;
	}

	public static bool Get_SmallMapImageItem_TacticsSoundTime(ISmallMapImageItem val, int idx)
	{
		return val.TacticsSoundTime;
	}

	public static float Get_SmallMapImageItem_Alpha(ISmallMapImageItem val, int idx)
	{
		return val.Alpha;
	}

	public static float Get_SmallMapImageItem_ScaleX(ISmallMapImageItem val, int idx)
	{
		return val.ScaleX;
	}

	public static float Get_SmallMapImageItem_SmallMapScale(ISmallMapImageItem val, int idx)
	{
		return val.SmallMapScale;
	}

	public static int Get_SmallMapImageItem_Mask(ISmallMapImageItem val, int idx)
	{
		return val.Mask;
	}

	public static bool Get_SmallMapImageItem_FreeRadar(ISmallMapImageItem val, int idx)
	{
		return val.FreeRadar;
	}

	public static float Get_SmallMapImageItem_Rotation(ISmallMapImageItem val, int idx)
	{
		return val.Rotation;
	}

	public static float Get_SmallMapImageItem_RealWidth(ISmallMapImageItem val, int idx)
	{
		return val.RealWidth;
	}

	public static bool Get_minimapData_ShowDuwu()
	{
		foreach (ISmallMapImageItem image in Contexts.sharedInstance.battleRoom.mapInfo.ImageList)
		{
			if (image.Mask > 0)
			{
				return true;
			}
		}
		return false;
	}

	public static int Get_SmallMapImageItem_DeadTime(ISmallMapImageItem val, int idx)
	{
		return val.DeadTime;
	}

	public static int Get_OneKillInfoData_KillNum(OneKillInfoData val, int idx)
	{
		return val.KillNum;
	}

	public static int Get_OneKillInfoData_TreatmentScore(OneKillInfoData val, int idx)
	{
		return val.TreatmentScore;
	}

	public static int Get_OneKillInfoData_AssistsNum(OneKillInfoData val, int idx)
	{
		return val.AssistsNum;
	}

	public static bool Get_OneKillInfoData_KdKing(OneKillInfoData val, int idx)
	{
		return val.KdKing;
	}

	public static bool Get_OneKillInfoData_Mvp(OneKillInfoData val, int idx)
	{
		return val.Mvp;
	}

	public static bool Get_OneKillInfoData_Nurse(OneKillInfoData val, int idx)
	{
		return val.Nurse;
	}

	public static bool Get_OneKillInfoData_CompeteKing(OneKillInfoData val, int idx)
	{
		return val.CompeteKing;
	}

	public static bool Get_OneKillInfoData_Overload(OneKillInfoData val, int idx)
	{
		return val.Overload;
	}

	public static bool Get_OneKillInfoData_Terminator(OneKillInfoData val, int idx)
	{
		return val.Terminator;
	}

	public static int Get_OneKillInfoData_ReliveNum(OneKillInfoData val, int idx)
	{
		return val.ReliveNum;
	}

	public static bool Get_OneKillInfoData_HasC4(OneKillInfoData val, int idx)
	{
		return val.HasC4;
	}

	public static bool Get_OneKillInfoData_GoldHunter(OneKillInfoData val, int idx)
	{
		return val.GoldHunter;
	}

	public static bool Get_OneKillInfoData_MaxHidePack(OneKillInfoData val, int idx)
	{
		return val.MaxHidePack;
	}

	public static int Get_OneKillInfoData_OpenPackNum(OneKillInfoData val, int idx)
	{
		return val.OpenPackNum;
	}

	public static bool Get_OneKillInfoData_MaxOpenPack(OneKillInfoData val, int idx)
	{
		return val.MaxOpenPack;
	}

	public static int Get_OneKillInfoData_KnifeKill(OneKillInfoData val, int idx)
	{
		return val.KnifeKill;
	}

	public static int Get_OneKillInfoData_PlayerLv(OneKillInfoData val, int idx)
	{
		return val.Lv;
	}

	public static int Get_OneKillInfoData_Lv(OneKillInfoData val, int idx)
	{
		return val.Id;
	}

	public static int Get_OneKillInfoData_RankSect(OneKillInfoData val, int idx)
	{
		if (Contexts.sharedInstance.battleRoom != null && Contexts.sharedInstance.battleRoom.hasPlayerInfo && Contexts.sharedInstance.battleRoom.playerInfo.ObserverInfoDatas != null && Contexts.sharedInstance.battleRoom.playerInfo.ObserverInfoDatas.TryGetValue(val.Id, out var value))
		{
			return value.RaceRankSect;
		}
		return 0;
	}

	public static int Get_OneKillInfoData_RankLv(OneKillInfoData val, int idx)
	{
		if (val != null && Contexts.sharedInstance.battleRoom != null && Contexts.sharedInstance.battleRoom.hasPlayerInfo && Contexts.sharedInstance.battleRoom.playerInfo.ObserverInfoDatas != null && Contexts.sharedInstance.battleRoom.playerInfo.ObserverInfoDatas.TryGetValue(val.Id, out var value))
		{
			return value?.RaceRankLv ?? 0;
		}
		return 0;
	}

	public static int Get_OneKillInfoData_hurt(OneKillInfoData val, int idx)
	{
		return val.AllMoney;
	}

	public static long Get_OneKillInfoData_Save(OneKillInfoData val, int idx)
	{
		return val.Score;
	}

	public static int Get_allKillInfo_TeamCount2()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.Team2.Count;
	}

	public static int Get_allKillInfo_AllCount()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.All.Count;
	}

	public static float Get_pveScoreRank_RelivePercent(OneKillInfoData val, int idx)
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(val.Id);
		if (entityWithEntityId == null || !entityWithEntityId.hasPveScoreRank)
		{
			return 0f;
		}
		return entityWithEntityId.pveScoreRank.RelivePercent;
	}

	public static int Get_allKillInfo_TeamCount1()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.Team1.Count;
	}

	public static int Get_allKillInfo_TeamDeadCount1()
	{
		int num = 0;
		for (int i = 0; i < Contexts.sharedInstance.battleRoom.playerInfo.Team1.Count; i++)
		{
			if (Contexts.sharedInstance.battleRoom.playerInfo.Team1[i].IsDead)
			{
				num++;
			}
		}
		return num;
	}

	public static int Get_allKillInfo_TeamDeadCount2()
	{
		int num = 0;
		for (int i = 0; i < Contexts.sharedInstance.battleRoom.playerInfo.Team2.Count; i++)
		{
			if (Contexts.sharedInstance.battleRoom.playerInfo.Team2[i].IsDead)
			{
				num++;
			}
		}
		return num;
	}

	public static long Get_OneKillInfoData_TotalScore(OneKillInfoData val, int idx)
	{
		return Contexts.sharedInstance.gameRule.pveScoreRank.TotalScore;
	}

	public static long Get_OneKillInfoData_FirstScore(OneKillInfoData val, int idx)
	{
		return Contexts.sharedInstance.gameRule.pveScoreRank.FirstScore;
	}

	public static bool Get_RoomData_IsStrike()
	{
		RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
		if (data.ChannelData != 201)
		{
			return data.StrikeLevel > 0;
		}
		return true;
	}

	public static int Get_OneKillInfoData_StrikeScore(OneKillInfoData val, int idx)
	{
		return val.StrikeScore;
	}

	public static int Get_OneKillInfoData_AccessoryScore(OneKillInfoData val, int idx)
	{
		return val.AccessoryScore;
	}

	public static bool Get_PlayerBag_HasBag1()
	{
		return Contexts.sharedInstance.playerBag.GetEntityWithBagId(1) != null;
	}

	public static bool Get_PlayerBag_HasBag2()
	{
		return Contexts.sharedInstance.playerBag.GetEntityWithBagId(2) != null;
	}

	public static bool Get_PlayerBag_HasBag3()
	{
		return Contexts.sharedInstance.playerBag.GetEntityWithBagId(3) != null;
	}

	public static bool Get_PlayerBag_HasBag4()
	{
		return Contexts.sharedInstance.playerBag.GetEntityWithBagId(4) != null;
	}

	public static bool Get_PlayerBag_HasBag5()
	{
		return Contexts.sharedInstance.playerBag.GetEntityWithBagId(5) != null;
	}

	public static bool Get_Player_HasSelectCanBuy()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_SELECT_CAN_BUY.ID);
		}
		return false;
	}

	public static SelectItemList Get_SelectNodeData_SelectItemList()
	{
		return Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList;
	}

	public static int Get_SelectNodeData_SelectItemList_Name()
	{
		if (Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList != null)
		{
			return Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList.Name;
		}
		return -1;
	}

	public static bool Get_SelectNodeData_SelectItemList_Visible()
	{
		if (Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList != null)
		{
			return Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList.Visible;
		}
		return false;
	}

	public static List<SelectItem> Get_SelectNodeData_SelectItemList_ItemList()
	{
		if (Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList != null)
		{
			return Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList.ItemList;
		}
		return null;
	}

	public static List<string> Get_allKillInfo_LootList()
	{
		return Contexts.sharedInstance.battleRoom.roomData.LootList;
	}

	public static string Get_allKillInfo_Loot(string val, int idx)
	{
		return val;
	}

	public static List<HpProgressDataComponent.RuoDian> Get_hpProgressData_BossRuoDian()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossRuoDian;
	}

	public static float Get_hpProgressData_BossRuoDian_HpPercent(HpProgressDataComponent.RuoDian val, int idx)
	{
		return val.HpPercent;
	}

	public static string Get_hpProgressData_BossRuoDian_Texture(HpProgressDataComponent.RuoDian val, int idx)
	{
		return val.Texture;
	}

	public static string Get_hpProgressData_EliteAttribute0()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[0];
	}

	public static string Get_hpProgressData_EliteAttribute1()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[1];
	}

	public static string Get_hpProgressData_EliteAttribute2()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[2];
	}

	public static string Get_hpProgressData_EliteAttribute3()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[3];
	}

	public static string Get_hpProgressData_EliteAttribute4()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[4];
	}

	public static string Get_hpProgressData_EliteAttribute5()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteAttribute[5];
	}

	public static string Get_hpProgressData_BotAttribute0()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[0];
	}

	public static string Get_hpProgressData_BotAttribute1()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[1];
	}

	public static string Get_hpProgressData_BotAttribute2()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[2];
	}

	public static string Get_hpProgressData_BotAttribute3()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[3];
	}

	public static string Get_hpProgressData_BotAttribute4()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[4];
	}

	public static string Get_hpProgressData_BotAttribute5()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotAttribute[5];
	}

	public static string Get_hpProgressData_BossAttribute0()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[0];
	}

	public static string Get_hpProgressData_BossAttribute1()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[1];
	}

	public static string Get_hpProgressData_BossAttribute2()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[2];
	}

	public static string Get_hpProgressData_BossAttribute3()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[3];
	}

	public static string Get_hpProgressData_BossAttribute4()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[4];
	}

	public static string Get_hpProgressData_BossAttribute5()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossAttribute[5];
	}

	public static int Get_rpgPopMsg_TimeQueueCount()
	{
		return Contexts.sharedInstance.message.rpgPopMsg.TimeQueue.Count;
	}

	public static int Get_rpgPopMsg_RightDownQueueCount()
	{
		return Contexts.sharedInstance.message.rpgPopMsg.RightDownQueue.Count;
	}

	public static int Get_rpgPopMsg_MsgQueueCount()
	{
		return Contexts.sharedInstance.message.rpgPopMsg.MsgQueue.Count;
	}

	public static int Get_CurrentWeapon_RpgMaxPower()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			return CurrentWeaponEntity.power.RpgMaxPower;
		}
		return 0;
	}

	public static int Get_CurrentWeapon_Power()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			return CurrentWeaponEntity.power.Power;
		}
		return 0;
	}

	public static int Get_CurrentWeapon_Power2()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			return CurrentWeaponEntity.power.Power2;
		}
		return 0;
	}

	public static int Get_CurrentWeapon_MaxPower()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			return CurrentWeaponEntity.power.MaxPower;
		}
		return 0;
	}

	public static int Get_CurrentWeapon_MaxPower2()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			return CurrentWeaponEntity.power.MaxPower2;
		}
		return 0;
	}

	public static float Get_CurrentWeapon_PowerPercent()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			if (CurrentWeaponEntity.power.MaxPower <= 0)
			{
				return 0f;
			}
			return (float)CurrentWeaponEntity.power.Power / (float)CurrentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	public static float Get_CurrentWeapon_Power2Percent()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasPower)
		{
			if (CurrentWeaponEntity.power.MaxPower2 <= 0)
			{
				return 0f;
			}
			return (float)CurrentWeaponEntity.power.Power2 / (float)CurrentWeaponEntity.power.MaxPower2;
		}
		return 0f;
	}

	public static int Get_CurrentWeapon_SpecialLevel()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasSpecial)
		{
			return CurrentWeaponEntity.special.Level;
		}
		return 0;
	}

	public static bool Get_status_ExplodeDuwu()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.rpg_10300401_pingmuduwu.ID);
		}
		return false;
	}

	public static int Get_lastWeapon_BagId()
	{
		return Contexts.sharedInstance.player.lastWeapon.BagId;
	}

	public static int Get_lastWeapon_WeaponId()
	{
		return Contexts.sharedInstance.player.lastWeapon.WeaponId;
	}

	public static List<AchievementComponent.AchievementInfo> Get_achievement_Achievements()
	{
		return Contexts.sharedInstance.gameRule.achievement.Achievements;
	}

	public static List<OneKillInfoData> Get_allKillInfo_All()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.All;
	}

	public static List<OneKillInfoData> Get_allKillInfo_Team1()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.Team1;
	}

	public static List<OneKillInfoData> Get_allKillInfo_Team2()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.Team2;
	}

	public static List<OneKillInfoData> Get_allKillInfo_TeamMoney1()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.TeamMoney1;
	}

	public static List<OneKillInfoData> Get_allKillInfo_TeamMoney2()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.TeamMoney2;
	}

	public static Dictionary<int, List<string>> Get_allKillInfo_AllHonorDic()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.AllHonorDic;
	}

	public static Dictionary<int, List<string>> Get_allKillInfo_AllCareerDic()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.AllCareerDic;
	}

	public static bool Get_allKillInfo_IndividualVisible()
	{
		return Contexts.sharedInstance.gameRule.individualVisible.IndividualVisible;
	}

	public static List<string> Get_allKillInfo_ObserverList()
	{
		return Contexts.sharedInstance.battleRoom.playerInfo.ObserverList;
	}

	public static int Get_assistsNumData_AssistsNum()
	{
		return UiEventUtils.One;
	}

	public static int Get_beingHit_DamageFrom()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.beingHit.DamageFrom;
		}
		return 0;
	}

	public static BeingHitEventEntityData Get_beingHit_BeinghitData()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.beingHit.BeinghitData;
		}
		return null;
	}

	public static GroupBestKillData Get_bestKillData_GroupBestData()
	{
		return Contexts.sharedInstance.battleRoom.bestKill.GroupBestData;
	}

	public static BiochemicalBestData Get_bestKillData_BiochemicalBestData()
	{
		return Contexts.sharedInstance.battleRoom.bestKill.BiochemicalBestData;
	}

	public static LastMvpData Get_bestKillData_LastMvpData()
	{
		return Contexts.sharedInstance.battleRoom.bestKill.LastMvpData;
	}

	public static List<BigHeadMessageData> Get_bigHeadMessage_BigHeadMessages()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.BigHeadMessages;
	}

	public static bool Get_bigHeadMessage_Changed()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.Changed;
	}

	public static BigHeadMessageType Get_bigHeadMessage_Type()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.Type;
	}

	public static bool Get_bigHeadMessage_WateHeroDebut()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.WateHeroDebut;
	}

	public static bool Get_bigHeadMessage_LastTime()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.LastTime;
	}

	public static int Get_bigHeadMessage_BigHeadKingNum()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.BigHeadKingNum;
	}

	public static int Get_bigHeadMessage_MaxHeroNum()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.MaxHeroNum;
	}

	public static bool Get_bigHeadMessage_CanChangeHero()
	{
		return Contexts.sharedInstance.message.bigHeadMessage.CanChangeHero;
	}

	public static int Get_bigHeadProgress_Lv()
	{
		return Contexts.sharedInstance.gameRule.bigHeadProgress.Lv;
	}

	public static int Get_bigHeadProgress_Progress()
	{
		return Contexts.sharedInstance.gameRule.bigHeadProgress.Progress;
	}

	public static bool Get_CrazyBigHeadMessage()
	{
		return true;
	}

	public static int Get_bio2SkillLvUpData_Lv()
	{
		return Contexts.sharedInstance.gameRule.bio2SkillLvUpData.Lv;
	}

	public static int Get_bio2SkillLvUpData_Exp()
	{
		return Contexts.sharedInstance.gameRule.bio2SkillLvUpData.Exp;
	}

	public static int Get_bio2SkillLvUpData_LvUpExp()
	{
		return Contexts.sharedInstance.gameRule.bio2SkillLvUpData.LvUpExp;
	}

	public static int Get_bio2SkillLvUpData_SkillCount()
	{
		return Contexts.sharedInstance.gameRule.bio2SkillLvUpData.SkillCount;
	}

	public static BioItemsData Get_bioItems_BioItemsData()
	{
		return Contexts.sharedInstance.gameRule.bioItems.BioItemsData;
	}

	public static long Get_broadcastScore_Team1Score()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.Team1Score;
	}

	public static long Get_broadcastScore_Team2Score()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.Team2Score;
	}

	public static int Get_broadcastScore_CurrentScore()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.CurrentScore;
	}

	public static int Get_broadcastScore_WinScore()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.WinScore;
	}

	public static long Get_cameraOwnerData_Hp()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.Hp;
		}
		return 0L;
	}

	public static long Get_cameraOwnerData_MaxHp()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		return 0L;
	}

	public static string Get_cameraOwnerData_Career()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.Career;
		}
		return "";
	}

	public static bool Get_cameraOwnerData_ArmorHead()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.ArmorHead;
		}
		return false;
	}

	public static bool Get_cameraOwnerData_ArmorBody()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.ArmorBody;
		}
		return false;
	}

	public static float Get_cameraOwnerData_TitleId()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.TitleId;
		}
		return 0f;
	}

	public static int Get_cameraOwnerData_Vip()
	{
		return Contexts.sharedInstance.player.myPlayerEntity?.vip.Level ?? 0;
	}

	public static string Get_cameraOwnerData_Name()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			return myPlayerEntity.basicInfo.Current.DName + " " + myPlayerEntity.basicInfo.PlayerName;
		}
		return "";
	}

	public static float Get_cameraOwnerData_ViewHeight()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.move.ViewHeightBase + CameraOwnerEntity.viewHeight.ViewHeightSmoothRemain;
		}
		return 0f;
	}

	public static Vector3D Get_cameraOwnerData_Viewaxi()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.Viewaxis()[0];
		}
		return Vector3D.ZERO;
	}

	public static int Get_cameraOwnerData_PlayerId()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.GetId();
		}
		return 0;
	}

	public static UnityEngine.Vector3 Get_ControlEntityData_Position()
	{
		if (SnapshotEntity.hasSnapshots && SnapshotEntity.snapshots.NowSnapshot.Observer == 0)
		{
			int controlId = SnapshotEntity.snapshots.NowSnapshot.ControlId;
			CameraEntityData value = null;
			if (SnapshotEntity.snapshots.NowSnapshot.CameraEntityDataDict.TryGetValue(controlId, out value))
			{
				return new UnityEngine.Vector3(value.X, value.Y, value.Z);
			}
			SceneItemEntityData value2 = null;
			if (SnapshotEntity.snapshots.NowSnapshot.SceneItemEntityDataDict.TryGetValue(controlId, out value2))
			{
				return new UnityEngine.Vector3(value2.X, value2.Y, value2.Z);
			}
		}
		return Get_cameraOwnerData_Position();
	}

	public static UnityEngine.Vector3 Get_cameraOwnerData_Position()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.GetCompenstatePos(CameraOwnerEntity.fpos.Change.GetPosIndex());
		}
		return UnityEngine.Vector3.zero;
	}

	public static int Get_cameraOwnerData_Team()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.Team;
		}
		return 0;
	}

	public static bool Get_cameraOwnerData_IsDead()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.IsDead;
		}
		return false;
	}

	public static int Get_cameraOwnerData_Observer()
	{
		if (SnapshotEntity != null && SnapshotEntity.hasSnapshots && SnapshotEntity.snapshots != null && SnapshotEntity.snapshots.LatestSnapshot != null)
		{
			return SnapshotEntity.snapshots.LatestSnapshot.Observer;
		}
		return 0;
	}

	public static float Get_ControlEntityData_Yaw()
	{
		if (SnapshotEntity.hasSnapshots && SnapshotEntity.snapshots.NowSnapshot.Observer == 0)
		{
			int controlId = SnapshotEntity.snapshots.NowSnapshot.ControlId;
			CameraEntityData value = null;
			if (SnapshotEntity.snapshots.NowSnapshot.CameraEntityDataDict.TryGetValue(controlId, out value))
			{
				return (float)Contexts.sharedInstance.userCommand.commands.LastCameraYaw() / 100f;
			}
			SceneItemEntityData value2 = null;
			if (SnapshotEntity.snapshots.NowSnapshot.SceneItemEntityDataDict.TryGetValue(controlId, out value2))
			{
				return (float)Contexts.sharedInstance.userCommand.commands.LastCameraYaw() / 100f;
			}
		}
		return Get_cameraOwnerData_Yaw();
	}

	public static float Get_cameraOwnerData_Yaw()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasOrientation)
		{
			return CameraOwnerEntity.orientation.Yaw;
		}
		return 0f;
	}

	public static string Get_cameraOwnerData_PlayerName()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.PlayerName;
		}
		return "";
	}

	public static int Get_cameraOwnerData_Level()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.Lv ?? 0;
	}

	public static long Get_cameraOwnerData_ShieldHp()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.ShieldHp;
		}
		return 0L;
	}

	public static long Get_cameraOwnerData_ShieldMaxHp()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.ShieldMaxHp;
		}
		return 0L;
	}

	public static long Get_cameraOwnerData_SuperShieldHp()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.SuperShieldHp;
		}
		return 0L;
	}

	public static long Get_cameraOwnerData_SuperShieldMaxHp()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.SuperShieldMaxHp;
		}
		return 0L;
	}

	public static int Get_cameraOwnerData_DeadTimer()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.DeadTimer;
		}
		return 0;
	}

	public static int Get_cameraOwnerData_MaxReliveTime()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.MaxReliveTime ?? 0;
	}

	public static bool Get_cameraOwnerData_BiochemicalSerum()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.BiochemicalSerum;
		}
		return false;
	}

	public static bool Get_cameraOwnerData_BiochemicalMagazineFlag()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.BiochemicalMagazineFlag;
		}
		return false;
	}

	public static bool Get_cameraOwnerData_IsThirdPersonView()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.isThirdPersonView;
		}
		return false;
	}

	public static int Get_cameraOwnerData_ParasiticId()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.ParasiticId ?? 0;
	}

	public static int Get_cameraOwnerData_CurrentWeapon()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.Current.CurrentWeapon;
		}
		return 0;
	}

	public static bool Get_cameraOwnerData_TacticsSoundTime()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.GetTacticsSoundTime() > 0;
		}
		return false;
	}

	public static int Get_cameraOwnerData_Money()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.Money ?? 0;
	}

	public static float Get_cameraOwnerData_MetalmanSkillMp()
	{
		return Contexts.sharedInstance.gameRule.metalmanSkillData?.Mp ?? 0f;
	}

	public static int Get_cameraOwnerData_ControlId()
	{
		if (SnapshotEntity != null && SnapshotEntity.hasSnapshots && SnapshotEntity.snapshots != null && SnapshotEntity.snapshots.NowSnapshot != null)
		{
			return SnapshotEntity.snapshots.NowSnapshot.ControlId;
		}
		return 0;
	}

	public static string Get_cameraOwnerData_SkinName()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasBasicInfo)
		{
			return CameraOwnerEntity.basicInfo.SkinName;
		}
		return "";
	}

	public static bool Get_crystalDropData_FirstDrop()
	{
		return Contexts.sharedInstance.gameRule.crystalDropData.FirstDrop;
	}

	public static int Get_crystalDropData_CrystalNum()
	{
		return Contexts.sharedInstance.gameRule.crystalDropData.CrystalNum;
	}

	public static List<DamageData> Get_damageCountData_DamageDataList()
	{
		return Contexts.sharedInstance.message.damageCountData.DamageDataList;
	}

	public static List<SimpleEngineEntityData> Get_engineEntityHeadUiData_HeadList()
	{
		return Contexts.sharedInstance.battleRoom.engineEntity.HeadList;
	}

	public static GrenadeExplosionEventEntityData Get_flashExplosionData_Data()
	{
		return Contexts.sharedInstance.gameRule.flashExplosionData.Data;
	}

	public static FloatingMessageData Get_floatingMessage_DragoonData()
	{
		return Contexts.sharedInstance.message.floatingMessage.DragoonData;
	}

	public static bool Get_gameInfo_IsWoman()
	{
		return Contexts.sharedInstance.battleRoom.roomData.IsWoman;
	}

	public static bool Get_gameOverData_IsGameOver()
	{
		return Contexts.sharedInstance.battleRoom.gameOver.IsGameOver;
	}

	public static bool Get_gameOverData_IsWin()
	{
		return Contexts.sharedInstance.battleRoom.gameOver.IsWin;
	}

	public static string Get_gameOverData_WinnerName()
	{
		return Contexts.sharedInstance.battleRoom.gameOver.WinnerName;
	}

	public static ProgressType Get_gameProgressData_ProgressType()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.ProgressType;
	}

	public static int Get_gameProgressData_ProgressTotalTime()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.ProgressTotalTime;
	}

	public static int Get_gameProgressData_CurrentProgressTime()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.CurrentProgressTime;
	}

	public static float Get_gameProgressData_ProgressSpeed()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.Speed;
	}

	public static string Get_gameProgressData_PlayerName()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.PlayerName;
	}

	public static string Get_gameProgressData_Details()
	{
		return Contexts.sharedInstance.gameRule.gameProgressData.Details;
	}

	public static bool Get_menu_VisibleChanged()
	{
		return UiEventUtils.True;
	}

	public static bool Get_gameSetting_VisibleChanged()
	{
		return UiEventUtils.True;
	}

	public static bool Get_gameSetting_ShowVoiceShield()
	{
		return UiEventUtils.True;
	}

	public static bool Get_menu_HowToPlay()
	{
		return UiEventUtils.True;
	}

	public static int Get_groupGunKingMessageData_Type()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.Type;
	}

	public static int Get_groupGunKingMessageData_Phase()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.Phase;
	}

	public static int Get_groupGunKingMessageData_WinTeam()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.WinTeam;
	}

	public static int Get_groupGunKingMessageData_WinScore()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.WinScore;
	}

	public static int Get_groupGunKingMessageData_LoseScore()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.LoseScore;
	}

	public static int Get_groupGunKingMessageData_PhaseScore()
	{
		return Contexts.sharedInstance.message.groupGunKingMessageData.PhaseScore;
	}

	public static int Get_groupGunKingTeamScoreData_Phase()
	{
		return Contexts.sharedInstance.gameRule.groupGunKingTeamScoreData.Phase;
	}

	public static int Get_groupGunKingTeamScoreData_Team1KillNum()
	{
		return Contexts.sharedInstance.gameRule.groupGunKingTeamScoreData.Team1KillNum;
	}

	public static int Get_groupGunKingTeamScoreData_Team2KillNum()
	{
		return Contexts.sharedInstance.gameRule.groupGunKingTeamScoreData.Team2KillNum;
	}

	public static int Get_groupGunKingTeamScoreData_MaxKillNum()
	{
		return Contexts.sharedInstance.gameRule.groupGunKingTeamScoreData.MaxKillNum;
	}

	public static int Get_groupGunKingTeamScoreData_PhaseScore()
	{
		return Contexts.sharedInstance.gameRule.groupGunKingTeamScoreData.PhaseScore;
	}

	public static int Get_gunKingMessageData_Type()
	{
		return Contexts.sharedInstance.message.gunKingMessageData.Type;
	}

	public static int Get_gunKingTeamScoreData_SelfKillCount()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.SelfKillCount;
	}

	public static int Get_gunKingTeamScoreData_SelfPhaseKillCount()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.SelfPhaseKillCount;
	}

	public static int Get_gunKingTeamScoreData_SelfPhase()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.SelfPhase;
	}

	public static int Get_gunKingTeamScoreData_GunkingKillCount()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.GunkingKillCount;
	}

	public static int Get_gunKingTeamScoreData_GunkingPhaseKillCount()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.GunkingPhaseKillCount;
	}

	public static int Get_gunKingTeamScoreData_GunkingPhase()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.GunkingPhase;
	}

	public static string Get_gunKingTeamScoreData_GunkingPlayerName()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.GunkingPlayerName;
	}

	public static int Get_gunKingTeamScoreData_GunkingPlayerId()
	{
		return Contexts.sharedInstance.gameRule.gunKingTeamScoreData.GunkingPlayerId;
	}

	public static bool Get_jumpGameOver_JumpGameOver()
	{
		return Contexts.sharedInstance.battleRoom.gameOver.IsJumpGameOver;
	}

	public static SimpleProto Get_jumpGameOver_SimpleProto()
	{
		return Contexts.sharedInstance.battleRoom.gameOver.SimpleProto;
	}

	public static Queue<KillPlayerInfoData> Get_killPlayerInfo_InfoList()
	{
		return Contexts.sharedInstance.gameRule.killPlayerInfo.InfoList;
	}

	public static bool Get_killPlayerInfo_Changed()
	{
		return Contexts.sharedInstance.gameRule.killPlayerInfo.Changed;
	}

	public static string Get_killPlayerInfo_KillerName()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasKiller)
		{
			return MyPlayerEntity.killer.Killer;
		}
		return "";
	}

	public static int Get_killPlayerInfo_ShowKillerTime()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null && myPlayerEntity.hasKiller)
		{
			return myPlayerEntity.killer.ShowKillerTime;
		}
		return 0;
	}

	public static List<int> Get_killPlayerInfo_GunGloryList()
	{
		return Contexts.sharedInstance.gameRule.gunGlory.GunGloryList;
	}

	public static int Get_killPlayerInfo_GunGloryDelayShow()
	{
		return Contexts.sharedInstance.gameRule.gunGlory.GunGloryDelayShow;
	}

	public static int Get_kingTreasuryData_Coin()
	{
		return Contexts.sharedInstance.gameRule.kingTreasuryData.Coin;
	}

	public static int Get_kingTreasuryData_Wave()
	{
		return Contexts.sharedInstance.gameRule.kingTreasuryData.Wave;
	}

	public static List<string> Get_mechwarrionRankDate_NameList()
	{
		return Contexts.sharedInstance.gameRule.mechwarrionRankDate.NameList;
	}

	public static List<int> Get_mechwarrionRankDate_ScoreList()
	{
		return Contexts.sharedInstance.gameRule.mechwarrionRankDate.ScoreList;
	}

	public static int Get_mechwarriorHeroGrowupData_CurrentEnergy()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.CurrentEnergy;
	}

	public static int Get_mechwarriorHeroGrowupData_MaxEnergy()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.MaxEnergy;
	}

	public static int Get_mechwarriorHeroGrowupData_EnergySpeed()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.EnergySpeed;
	}

	public static int Get_mechwarriorHeroGrowupData_CurrentExp()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.CurrentExp;
	}

	public static int Get_mechwarriorHeroGrowupData_MaxExp()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.MaxExp;
	}

	public static int Get_mechwarriorHeroGrowupData_Lv()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.Lv;
	}

	public static bool Get_mechwarriorHeroGrowupData_GetEnergy()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.GetEnergy;
	}

	public static string Get_mechwarriorHeroGrowupData_EnergyPlayerName()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.EnergyPlayerName;
	}

	public static int Get_mechwarriorHumanEnergyData_CurrentEnergy()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHumanEnergyData.CurrentEnergy;
	}

	public static int Get_mechwarriorHumanEnergyData_MaxEnergy()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHumanEnergyData.MaxEnergy;
	}

	public static MechWarriorChargeGiftType Get_mechwarriorHumanEnergyData_ChangeGiftType()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHumanEnergyData.ChangeGiftType;
	}

	public static int Get_mechwarriorHumanEnergyData_ChangeGiftTime()
	{
		return Contexts.sharedInstance.gameRule.mechwarriorHumanEnergyData.ChangeGiftTime;
	}

	public static int Get_mechwarriorMessageData_MessageType()
	{
		return Contexts.sharedInstance.message.mechwarriorMessageData.MessageType;
	}

	public static int Get_mechwarriorMessageData_WaitPlayerCount()
	{
		return Contexts.sharedInstance.message.mechwarriorMessageData.WaitPlayerCount;
	}

	public static bool Get_mechwarriorMessageData_IsUltimateTime()
	{
		return Contexts.sharedInstance.message.mechwarriorMessageData.IsUltimateTime;
	}

	public static int Get_mechwarriorMessageData_UltimateTime()
	{
		return Contexts.sharedInstance.message.mechwarriorMessageData.UltimateTime;
	}

	public static bool Get_mechwarriorMessageData_MechLvup()
	{
		return Contexts.sharedInstance.message.mechwarriorMessageData.MechLvup;
	}

	public static bool Get_messageRemindData_Changed()
	{
		return Contexts.sharedInstance.message.messageRemindData.Changed;
	}

	public static string Get_messageRemindData_MessageText()
	{
		return Contexts.sharedInstance.message.messageRemindData.MessageText;
	}

	public static int Get_messageRemindData_MessageShowTime()
	{
		return Contexts.sharedInstance.message.messageRemindData.MessageShowTime;
	}

	public static string Get_messageRemindData_Ak47Message()
	{
		return Contexts.sharedInstance.message.messageRemindData.Ak47Message;
	}

	public static int Get_minimapData_ImageListCount()
	{
		return Contexts.sharedInstance.battleRoom.mapInfo.ImageList.Count;
	}

	public static List<ISmallMapImageItem> Get_minimapData_ImageList()
	{
		return Contexts.sharedInstance.battleRoom.mapInfo.ImageList;
	}

	public static IMapInfo Get_minimapData_MapInfo()
	{
		return Contexts.sharedInstance.battleRoom.mapInfo.MapInfo;
	}

	public static RoomData Get_modeImageData_Changed()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data;
	}

	public static bool Get_newbieGuideData_Changed()
	{
		return Contexts.sharedInstance.gameRule.newbieGuideData.Changed;
	}

	public static int Get_newbieGuideData_NewbieGuideFlag()
	{
		return Contexts.sharedInstance.gameRule.newbieGuideData.NewbieGuideFlag;
	}

	public static NewbieGuideStruct Get_newbieGuideData_NewbieGuideModel()
	{
		return Contexts.sharedInstance.gameRule.newbieGuideData.NewbieGuideModel;
	}

	public static bool Get_ninjiMark_NinjiHhurt()
	{
		return Contexts.sharedInstance.gameRule.ninjiMark.NinjiHhurt;
	}

	public static ObserverInfoData Get_observerInfo_ObserverInfo()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasObserverInfo)
		{
			return CameraOwnerEntity.observerInfo.Data;
		}
		return null;
	}

	public static string Get_observerInfo_ObserverName()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.PlayerName;
		}
		return "";
	}

	public static int Get_observerInfo_ObserverKillNum()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.oneKillInfo.Data != null)
		{
			return CameraOwnerEntity.oneKillInfo.Data.KillNum;
		}
		return 0;
	}

	public static int Get_observerInfo_ObserverBeKillNum()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.oneKillInfo.Data != null)
		{
			return CameraOwnerEntity.oneKillInfo.Data.BeKillNum;
		}
		return 0;
	}

	public static float Get_otherProgress_ProgressVal()
	{
		return Contexts.sharedInstance.gameRule.otherProgress.ProgressVal;
	}

	public static int Get_profit_TotalAllExp()
	{
		return GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel().totalExp;
	}

	public static int Get_profit_TotalCrystal()
	{
		return GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel().totalCrystal;
	}

	public static int Get_profit_TotalExpPer()
	{
		return GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel().totalExpPer;
	}

	public static int Get_profit_TotalAllGp()
	{
		return GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel().totalAllGp;
	}

	public static int Get_profit_TotalGpPer()
	{
		return GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel().totalGpPer;
	}

	public static SelectItemList Get_selectNodeData_SelectItemList()
	{
		return Contexts.sharedInstance.gameRule.selectNodeData.SelectItemList;
	}

	public static float Get_selectNodeData_ReceivedtTime()
	{
		return Contexts.sharedInstance.gameRule.selectNodeData.ReceivedtTime;
	}

	public static bool Get_serverConnection_IsConnected()
	{
		BattleServerEntity battleServerEntity = Contexts.sharedInstance.battleServer.battleServerEntity;
		if (battleServerEntity != null && battleServerEntity.hasHealth)
		{
			return battleServerEntity.health.IsConnected;
		}
		return true;
	}

	public static int Get_serverConnection_ReConnectCount()
	{
		BattleServerEntity battleServerEntity = Contexts.sharedInstance.battleServer.battleServerEntity;
		if (battleServerEntity != null && battleServerEntity.hasHealth)
		{
			return battleServerEntity.health.ReConnectCount;
		}
		return 0;
	}

	public static long Get_serverConnection_ReConnectStartTime()
	{
		BattleServerEntity battleServerEntity = Contexts.sharedInstance.battleServer.battleServerEntity;
		if (battleServerEntity != null && battleServerEntity.hasHealth)
		{
			return battleServerEntity.health.ReConnectStartTime;
		}
		return 0L;
	}

	public static int Get_tdSkillStateData_CurrentMp()
	{
		return Contexts.sharedInstance.gameRule.tdSkillStateData.CurrentMp;
	}

	public static int Get_tdSkillStateData_TotalMp()
	{
		return Contexts.sharedInstance.gameRule.tdSkillStateData.TotalMp;
	}

	public static bool Get_uiBag_CanChangeBag()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.CanChangeBag;
		}
		return false;
	}

	public static int Get_uiBag_CurrentBagId()
	{
		if (MyPlayerEntity == null)
		{
			return 0;
		}
		return MyPlayerEntity.basicInfo.Current.CurrentBagId;
	}

	public static bool Get_uiCareer_IsHumanity()
	{
		if (CameraOwnerEntity == null)
		{
			return false;
		}
		string career = CameraOwnerEntity.basicInfo.Current.Career;
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (PlayerCareerConstantUtility.IsHumanity(career))
		{
			return !PlayerCareerUtil.IsMech2(career);
		}
		return false;
	}

	public static bool Get_uiCareer_IsHero()
	{
		if (CameraOwnerEntity == null)
		{
			return false;
		}
		string career = CameraOwnerEntity.basicInfo.Current.Career;
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		return PlayerCareerConstantUtility.IsHero(career);
	}

	public static bool Get_uiCareer_IsEmpress()
	{
		if (CameraOwnerEntity == null)
		{
			return false;
		}
		return PlayerCareerConstantUtility.IsEmpress(CameraOwnerEntity.basicInfo.Current.Career);
	}

	public static string Get_uiCross_WeaponName()
	{
		if (CurrentWeaponEntity == null || !CurrentWeaponEntity.hasBasicInfo)
		{
			return "";
		}
		return CurrentWeaponEntity.basicInfo.Data.WeaponName;
	}

	public static int Get_uiCross_Fov()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.fov.Fov;
		}
		return 0;
	}

	public static int Get_uiCross_WeaponLevel()
	{
		if (CurrentWeaponEntity == null)
		{
			return 0;
		}
		return CurrentWeaponEntity.basicInfo.Data.Level;
	}

	public static bool Get_uiCross_SpecialMode()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasSpecial)
		{
			return CurrentWeaponEntity.special.SpecialMode;
		}
		return false;
	}

	public static int Get_uiCross_EffectLevel()
	{
		if (CurrentWeaponEntity == null)
		{
			return 0;
		}
		return CurrentWeaponEntity.basicInfo.Data.EffectLevel;
	}

	public static int Get_uiCross_WeaponType()
	{
		if (CurrentWeaponEntity == null)
		{
			return 0;
		}
		return CurrentWeaponEntity.basicInfo.Info.WeaponType;
	}

	public static bool Get_uiCross_AwpVisible()
	{
		return Contexts.sharedInstance.cross.isAwpCross;
	}

	public static int Get_uiCross_ChangRedCrossTime()
	{
		return Contexts.sharedInstance.cross.hitCross.ChangRedTime;
	}

	public static float Get_uiCross_RendSpread()
	{
		return Contexts.sharedInstance.cross.crossSpread.RendSpread;
	}

	public static int Get_uiCross_UpdateFrameInterval()
	{
		return Contexts.sharedInstance.cross.crossSpread.UpdateFrameInterval;
	}

	public static int Get_uiCross_Left()
	{
		return Contexts.sharedInstance.cross.crossSpread.Left;
	}

	public static int Get_uiCross_Right()
	{
		return Contexts.sharedInstance.cross.crossSpread.Right;
	}

	public static int Get_uiCross_Down()
	{
		return Contexts.sharedInstance.cross.crossSpread.Down;
	}

	public static int Get_uiCross_Up()
	{
		return Contexts.sharedInstance.cross.crossSpread.Up;
	}

	public static float Get_uiCross_Scale()
	{
		return Contexts.sharedInstance.cross.crossSpread.Scale;
	}

	public static bool Get_uiCross_AddHp()
	{
		return Contexts.sharedInstance.cross.isAddHpCross;
	}

	public static int Get_uiCross_CrossType()
	{
		return GameSetting.Config.CrossTypeIndex;
	}

	public static int Get_uiCross_CrossColor()
	{
		return GameSetting.Config.CrossColorIndex;
	}

	public static bool Get_uiCross_HideCross()
	{
		return Contexts.sharedInstance.cross.isHideCross;
	}

	public static int Get_uiMyPlayer_VipLevel()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasVip)
		{
			return MyPlayerEntity.vip.Level;
		}
		return 0;
	}

	public static int Get_uiMyPlayer_PlayerId()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetId();
		}
		return 0;
	}

	public static string Get_uiMyPlayer_PlayerName()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.PlayerName;
		}
		return "";
	}

	public static long Get_uiMyPlayer_CID()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.Id;
		}
		return 0L;
	}

	public static int Get_uiMyPlayer_Team()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetTeam();
		}
		return 0;
	}

	public static UnityEngine.Vector3 Get_uiMyPlayer_Position()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasFpos)
		{
			return MyPlayerEntity.GetCompenstatePos(MyPlayerEntity.fpos.Change.GetPosIndex());
		}
		return UnityEngine.Vector3.zero;
	}

	public static string Get_uiMyPlayer_Career()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetCareer();
		}
		return "";
	}

	public static bool Get_uiMyPlayer_C4Flag()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.C4Flag;
		}
		return false;
	}

	public static bool Get_uiMyPlayer_IsDead()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.IsDead();
		}
		return false;
	}

	public static bool Get_uiMyPlayer_IsFakeDead()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.HasStatus(PlayerInfoStatusConstant.FAKE_DEAD.ID);
		}
		return false;
	}

	public static int Get_uiMyPlayer_DeadTimer()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasSmoothDeadTimer)
		{
			return MyPlayerEntity.smoothDeadTimer.DeadTimer;
		}
		return 0;
	}

	public static string Get_uiMyPlayer_TeamName()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasTeamName)
		{
			return MyPlayerEntity.teamName.TeamName;
		}
		return "";
	}

	public static int Get_uiMyPlayer_Lv()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetPlayerInfo().Lv;
		}
		return 0;
	}

	public static bool Get_uiMyPlayer_IsObserver()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.IsObserver();
		}
		return false;
	}

	public static int Get_uiMyPlayer_MaxReliveTime()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.GetPlayerInfo().MaxReliveTime;
		}
		return 0;
	}

	public static int Get_uiMyPlayer_TeamId()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.TeamId;
		}
		return 0;
	}

	public static bool Get_uiMyPlayer_Leader()
	{
		return false;
	}

	public static IPyEngine Get_uiPyEngine_PyEngine()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (!battleRoom.hasPyEngine)
		{
			return null;
		}
		return battleRoom.pyEngine.PyEngine;
	}

	public static int Get_uiPyEngine_DecalsId()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (!battleRoom.hasPyEngine)
		{
			return 0;
		}
		return battleRoom.pyEngine.PyEngine.GetWorld().GetDecalsId();
	}

	public static UnityEngine.Vector3 Get_uiPyEngine_Max()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (!battleRoom.hasPyEngine)
		{
			return UnityEngine.Vector3.zero;
		}
		return battleRoom.pyEngine.Max;
	}

	public static UnityEngine.Vector3 Get_uiPyEngine_Min()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (!battleRoom.hasPyEngine)
		{
			return UnityEngine.Vector3.zero;
		}
		return battleRoom.pyEngine.Min;
	}

	public static int Get_uiRoomData_RaceType()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
	}

	public static int Get_uiRoomData_SubRaceType()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.SubRaceType;
	}

	public static int Get_uiRoomData_ReLiveTime()
	{
		RoomDataComponent roomData = Contexts.sharedInstance.battleRoom.roomData;
		RoomData data = roomData.Data;
		if (roomData.ReLiveTime == 0)
		{
			return data.ReLiveTime;
		}
		return roomData.ReLiveTime;
	}

	public static int Get_uiRoomData_WinScore()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.WinScore;
	}

	public static int Get_uiRoomData_WinCondition()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.WinCondition;
	}

	public static string Get_uiRoomData_RoomTitle()
	{
		return Contexts.sharedInstance.battleRoom.roomData.RoomTitle;
	}

	public static int Get_uiRoomData_LimitNum()
	{
		return Contexts.sharedInstance.battleRoom.roomData.LimitNum;
	}

	public static bool Get_uiRoomData_IsMatch()
	{
		return GameModelLocator.GetInstance().GameModel.IsMatch;
	}

	public static bool Get_uiRoomData_IsMatchWaitPlayer()
	{
		return GameModelLocator.GetInstance().GameModel.IsMatchWaitPlayer;
	}

	public static bool Get_uiRoomData_IsObserver()
	{
		return Contexts.sharedInstance.battleRoom.roomData.IsObserver;
	}

	public static int Get_uiRoomData_PveLevel()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.PveLevel;
	}

	public static IGameRule Get_uiRoomData_GameRule()
	{
		return Contexts.sharedInstance.gameRule.currentRule.Rule;
	}

	public static int Get_uiRoomData_BotLevel()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.BotLevel;
	}

	public static int Get_uiSectionTime_SectionTime()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.SectionTime;
	}

	public static long Get_uiSectionTime_SectionStartTimeClient()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.SectionStartTimeClient;
	}

	public static int Get_uiSectionTime_Passed()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.Passed;
	}

	public static int Get_uiSectionTime_NotMoveTime()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.CannotMoveTime;
	}

	public static int Get_uiSectionTime_Minutes()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.Minutes;
	}

	public static int Get_uiSectionTime_Seconds()
	{
		return Contexts.sharedInstance.battleRoom.sectionTime.Seconds;
	}

	public static bool Get_uiChooseWeapon()
	{
		if (!Contexts.sharedInstance.gameRule.hasChooseWeapon)
		{
			return false;
		}
		return Contexts.sharedInstance.gameRule.chooseWeapon.CanChooseWeapon;
	}

	public static bool Get_uiChooseWeaponChanged()
	{
		if (!Contexts.sharedInstance.gameRule.hasChooseWeapon)
		{
			return false;
		}
		return Contexts.sharedInstance.gameRule.chooseWeapon.ChooseWeaponChanged;
	}

	public static Dictionary<int, SkillInfoData> Get_uiSkill_Skills()
	{
		return UiEventUtils.GetCameraOwnerSkills();
	}

	public static bool Get_uiSkill_HasAuraSpeedBonus()
	{
		return UiEventUtils.GetCameraOwnerSkills()?.ContainsKey(2) ?? false;
	}

	public static bool Get_uiSkill_RpgXpShifang()
	{
		return UiEventUtils.True;
	}

	public static bool Get_uiSkill_RpgXpMingzhong()
	{
		return UiEventUtils.True;
	}

	public static bool Get_weaponCombination_HideFirstPersonView()
	{
		return Contexts.sharedInstance.gameRule.weaponCombination.HideFirstPersonView;
	}

	public static bool Get_weaponPendantDrop_IsStormScore()
	{
		return Contexts.sharedInstance.gameRule.weaponPendantDrop.IsStormScore;
	}

	public static int Get_weaponPendantDrop_Count()
	{
		return Contexts.sharedInstance.gameRule.weaponPendantDrop.Count;
	}

	public static string Get_weaponPendantDrop_PendantId()
	{
		return Contexts.sharedInstance.gameRule.weaponPendantDrop.PendantId;
	}

	public static int Get_weaponPendantDrop_Quality()
	{
		return Contexts.sharedInstance.gameRule.weaponPendantDrop.Quality;
	}

	public static int Get_weaponPendantDrop_Time()
	{
		return Contexts.sharedInstance.gameRule.weaponPendantDrop.Time;
	}

	public static string Get_weaponState_WeaponName()
	{
		return UiEventUtils.GetWeaponName();
	}

	public static int Get_weaponState_WeaponType()
	{
		if (CurrentWeaponEntity == null)
		{
			return 0;
		}
		return CurrentWeaponEntity.basicInfo.Info.WeaponType;
	}

	public static string Get_weaponState_CnWeaponName()
	{
		if (CurrentWeaponEntity != null)
		{
			string text = ScriptLocalization.Get(CurrentWeaponEntity.basicInfo.Data.WeaponName);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			return CurrentWeaponEntity.basicInfo.Info.StringName;
		}
		return "";
	}

	public static int Get_weaponState_ClipCount()
	{
		if (CurrentWeaponEntity != null && CurrentWeaponEntity.hasBasicInfo)
		{
			if (CurrentWeaponEntity.basicInfo.Info.WeaponType == 2)
			{
				return 0;
			}
			string weaponName = CurrentWeaponEntity.basicInfo.Data.WeaponName;
			PlayerBagData playerBagData = (Contexts.sharedInstance.playerBag.isCurrentBag ? Contexts.sharedInstance.playerBag.currentBagEntity.basicInfo.Data : null);
			if (playerBagData != null && playerBagData.MeleeWeapon != null && weaponName == playerBagData.MeleeWeapon.WeaponName)
			{
				return 0;
			}
			C4BagComponent c4BagComponent = (Contexts.sharedInstance.playerBag.hasC4Bag ? Contexts.sharedInstance.playerBag.c4Bag : null);
			if (c4BagComponent != null && c4BagComponent.C4Weapon != null && weaponName == c4BagComponent.C4Weapon.WeaponName)
			{
				return 0;
			}
			PredicationConfig predicationConfig = PredicationConfigFactory.Instance.GetPredicationConfig(weaponName);
			if (predicationConfig != null && WeaponConfigUtils.RealDouble(predicationConfig.GetAttackType()))
			{
				return 2;
			}
			switch (weaponName)
			{
			case "infinite_hand1":
			case "infinite_hand2":
			case "infinite_hand3":
				if (CurrentWeaponEntity.basicInfo.Data.SpecialMode)
				{
					return 2;
				}
				return 1;
			case "infinite_hand1_change_2":
			case "infinite_hand2_change_2":
			case "infinite_hand3_change_2":
				if (CurrentWeaponEntity.basicInfo.Data.SpecialMode)
				{
					return 0;
				}
				return 2;
			case "twins_infinity":
			case "twins_infinity1":
			case "twins_infinity2":
				return 2;
			case "gatling_dou_rage":
			case "gatling_dou_rage1":
			case "gatling_dou_rage2":
			case "gatling_dou_rage_overload":
				return 2;
			default:
				return CurrentWeaponEntity.basicInfo.Info.ClipCount;
			}
		}
		return 0;
	}

	public static int Get_weaponState_CurrentClip1()
	{
		int weaponEffectLevel = UiEventUtils.GetWeaponEffectLevel();
		string weaponName = UiEventUtils.GetWeaponName();
		BaseWeaponData weaponFormBag = UiEventUtils.GetWeaponFormBag();
		if (weaponFormBag == null)
		{
			return 0;
		}
		if (weaponEffectLevel == 2 && (weaponName == "awm_legend_ct" || weaponName == "awm_legend_t"))
		{
			return weaponFormBag.Clip2;
		}
		if (weaponName == "arc_electric_shotgun" && (weaponEffectLevel & 2) > 0)
		{
			return weaponFormBag.Power;
		}
		return weaponFormBag.Clip;
	}

	public static int Get_weaponState_CarryClip1()
	{
		int weaponEffectLevel = UiEventUtils.GetWeaponEffectLevel();
		string weaponName = UiEventUtils.GetWeaponName();
		BaseWeaponData weaponFormBag = UiEventUtils.GetWeaponFormBag();
		if (weaponFormBag == null)
		{
			return 0;
		}
		if (weaponEffectLevel == 2 && (weaponName == "awm_legend_ct" || weaponName == "awm_legend_t"))
		{
			return weaponFormBag.CarryClip2;
		}
		if (weaponName == "arc_electric_shotgun" && (weaponEffectLevel & 2) > 0)
		{
			return weaponFormBag.MaxPower;
		}
		return weaponFormBag.CarryClip;
	}

	public static bool Get_WeaponState_SniperGuard()
	{
		if (Get_uiCross_WeaponName() == "sniper_guardian")
		{
			return (UiEventUtils.GetWeaponEffectLevel() & 2) > 0;
		}
		return false;
	}

	public static int Get_weaponState_CurrentClip2()
	{
		int weaponEffectLevel = UiEventUtils.GetWeaponEffectLevel();
		string weaponName = UiEventUtils.GetWeaponName();
		BaseWeaponData weaponFormBag = UiEventUtils.GetWeaponFormBag();
		if (weaponFormBag == null)
		{
			return 0;
		}
		if (weaponEffectLevel == 2 && (weaponName == "awm_legend_ct" || weaponName == "awm_legend_t"))
		{
			return 0;
		}
		return weaponFormBag.Clip2;
	}

	public static int Get_weaponState_CarryClip2()
	{
		int weaponEffectLevel = UiEventUtils.GetWeaponEffectLevel();
		string weaponName = UiEventUtils.GetWeaponName();
		BaseWeaponData weaponFormBag = UiEventUtils.GetWeaponFormBag();
		if (weaponFormBag == null)
		{
			return 0;
		}
		if (weaponEffectLevel == 2 && (weaponName == "awm_legend_ct" || weaponName == "awm_legend_t"))
		{
			return 0;
		}
		return weaponFormBag.CarryClip2;
	}

	public static string Get_weaponState_GrenadeName1()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons0 != null)
		{
			return currentBag.BombWeapons0.WeaponName;
		}
		return "";
	}

	public static int Get_weaponState_GrenadeNum1()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return 0;
		}
		if (currentBag.BombWeapons0 != null)
		{
			return currentBag.BombWeapons0.Clip;
		}
		return 0;
	}

	public static string Get_weaponState_GrenadeSkin1()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons0 != null)
		{
			return currentBag.BombWeapons0.WeaponSkinName;
		}
		return "";
	}

	public static string Get_weaponState_GrenadeName2()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons1 != null)
		{
			return currentBag.BombWeapons1.WeaponName;
		}
		return "";
	}

	public static int Get_weaponState_GrenadeNum2()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return 0;
		}
		if (currentBag.BombWeapons1 != null)
		{
			return currentBag.BombWeapons1.Clip;
		}
		return 0;
	}

	public static string Get_weaponState_GrenadeSkin2()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons1 != null)
		{
			return currentBag.BombWeapons1.WeaponSkinName;
		}
		return "";
	}

	public static string Get_weaponState_GrenadeName3()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons2 != null)
		{
			return currentBag.BombWeapons2.WeaponName;
		}
		return "";
	}

	public static int Get_weaponState_GrenadeNum3()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return 0;
		}
		if (currentBag.BombWeapons2 != null)
		{
			return currentBag.BombWeapons2.Clip;
		}
		return 0;
	}

	public static string Get_weaponState_GrenadeSkin3()
	{
		PlayerBagData currentBag = UiEventUtils.GetCurrentBag();
		if (currentBag == null)
		{
			return "";
		}
		if (currentBag.BombWeapons2 != null)
		{
			return currentBag.BombWeapons2.WeaponSkinName;
		}
		return "";
	}

	public static bool Get_weaponState_ShowAk47()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.hasAk47Hero;
		}
		return false;
	}

	public static PlayerEntity Get_weaponState_OtherShowAk47()
	{
		if (_otherShowAk47Group == null)
		{
			_otherShowAk47Group = Contexts.sharedInstance.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ShowAk47Hero, PlayerMatcher.Ak47Hero));
		}
		using (IGroup<PlayerEntity>.Enumator enumator = _otherShowAk47Group.GetEnumerator())
		{
			if (enumator.MoveNext())
			{
				return enumator.Current;
			}
		}
		return null;
	}

	public static string Get_weaponState_ClipCountFont()
	{
		string weaponName = UiEventUtils.GetWeaponName();
		int weaponEffectLevel = UiEventUtils.GetWeaponEffectLevel();
		if (!string.IsNullOrEmpty(weaponName))
		{
			if (UiEventUtils.GoldFontWeapons.Contains(weaponName) && weaponEffectLevel > 0)
			{
				return "560";
			}
			if (weaponName == "m4a1_legend2" && (weaponEffectLevel & 8) > 0)
			{
				return "560";
			}
			if (weaponName == "ak47_domination" && (weaponEffectLevel & 4) > 0)
			{
				return "560";
			}
			if (weaponName == "rpk_domination" && (weaponEffectLevel & 1) > 0)
			{
				return "560";
			}
			return "10";
		}
		return "";
	}

	public static string Get_weaponState_SkinName()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasCurrentWeapon)
		{
			return CameraOwnerEntity.currentWeapon.SkinName;
		}
		return "";
	}

	public static int Get_weaponState_EffectLevel()
	{
		return UiEventUtils.GetWeaponEffectLevel();
	}

	public static int Get_addExpData_currentExp()
	{
		return Contexts.sharedInstance.gameRule.addExpData.CurrentExp;
	}

	public static int Get_addExpData_maxExp()
	{
		return Contexts.sharedInstance.gameRule.addExpData.MaxExp;
	}

	public static int Get_addExpData_addExp()
	{
		return Contexts.sharedInstance.gameRule.addExpData.AddExp;
	}

	public static bool Get_addExpData_Dirty()
	{
		return Contexts.sharedInstance.gameRule.addExpData.Dirty;
	}

	public static int Get_bioDamageScoreData_HeroDamageScore()
	{
		return Contexts.sharedInstance.message.bioDamageScoreData.HeroDamageScore;
	}

	public static int Get_bioDamageScoreData_HumanityDamageScore()
	{
		return Contexts.sharedInstance.message.bioDamageScoreData.HumanityDamageScore;
	}

	public static int Get_bioDamageScoreData_HumanityFragment()
	{
		return Contexts.sharedInstance.message.bio3BioDebris.Count;
	}

	public static int Get_bioDamageScoreData_LastHumanityDamageScore()
	{
		return Contexts.sharedInstance.message.bioDamageScoreData.LastHumanityDamageScore;
	}

	public static MessageDataInfo Get_bioMessageData_Message()
	{
		return Contexts.sharedInstance.message.bioMessageData.Message;
	}

	public static int Get_bioMessageData_SkillName()
	{
		return Contexts.sharedInstance.message.bioMessageData.SkillName;
	}

	public static int Get_bioMessageData_Time()
	{
		return Contexts.sharedInstance.message.bioMessageData.Time;
	}

	public static string Get_bioMessageData_Bio2SKillName()
	{
		return Contexts.sharedInstance.message.bioMessageData.Bio2SKillName;
	}

	public static int Get_bioMessageData_Level()
	{
		return Contexts.sharedInstance.message.bioMessageData.Level;
	}

	public static int Get_bioMessageData_WaitingPlayerNum()
	{
		return Contexts.sharedInstance.message.bioMessageData.WaitingPlayerNum;
	}

	public static bool Get_bioMessageData_IsDeathMax()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsDeathMax;
	}

	public static bool Get_bioMessageData_IsChangedDeath()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsChangedDeath;
	}

	public static bool Get_bioMessageData_IsHeroChanged()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsHeroChanged;
	}

	public static bool Get_bioMessageData_IsUltimateTime()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsUltimateTime;
	}

	public static bool Get_bioMessageData_IsTidevariationTime()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsTidevariationTime;
	}

	public static bool Get_bioMessageData_IsUltimateStartTime()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsUltimateStartTime;
	}

	public static bool Get_bioMessageData_IsWaitEultimateTime()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsWaitEultimateTime;
	}

	public static bool Get_bioMessageData_IsChangeMesh()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsChangeMesh;
	}

	public static bool Get_bioMessageData_IsMeshMax()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsMeshMax;
	}

	public static bool Get_bioMessageData_IsChangedQueen()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsChangedQueen;
	}

	public static bool Get_bioMessageData_IsBio2SKillChanged()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsBio2SKillChanged;
	}

	public static bool Get_bioMessageData_IsBio2WaitingPlayerNumChanged()
	{
		return Contexts.sharedInstance.message.bioMessageData.IsBio2WaitingPlayerNumChanged;
	}

	public static int Get_bioNewVariantsGrowUp_Lv()
	{
		return Contexts.sharedInstance.gameRule.bioNewVariantsGrowUp.Lv;
	}

	public static int Get_bioNewVariantsGrowUp_LvUpHp()
	{
		return Contexts.sharedInstance.gameRule.bioNewVariantsGrowUp.LvUpHp;
	}

	public static bool Get_bioNewVariantsGrowUp_IsLvUpDead()
	{
		return Contexts.sharedInstance.gameRule.bioNewVariantsGrowUp.IsLvUpDead;
	}

	public static bool Get_bioSelectAvatarData_HasModel1()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel1;
	}

	public static bool Get_bioSelectAvatarData_HasModel2()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel2;
	}

	public static bool Get_bioSelectAvatarData_HasModel3()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel3;
	}

	public static bool Get_bioSelectAvatarData_HasModel4()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel4;
	}

	public static bool Get_bioSelectAvatarData_HasModel5()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel5;
	}

	public static bool Get_bioSelectAvatarData_HasModel6()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel6;
	}

	public static bool Get_bioSelectAvatarData_HasModel7()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel7;
	}

	public static bool Get_bioSelectAvatarData_HasModel8()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel8;
	}

	public static bool Get_bioSelectAvatarData_HasModel9()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.HasModel9;
	}

	public static int Get_bioSelectAvatarData_CheckedModel()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.CheckedModel;
	}

	public static int Get_bioSelectAvatarData_SelectType()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.SelectType;
	}

	public static int Get_bioSelectAvatarData_SelectTime()
	{
		return Contexts.sharedInstance.gameRule.bioSelectAvatarData.SelectTime;
	}

	public static int Get_humanityGrowUp_GrowUpLevel()
	{
		return Contexts.sharedInstance.gameRule.humanityGrowUp.GrowUpLevel;
	}

	public static int Get_humanityGrowUp_CurrentExp()
	{
		return Contexts.sharedInstance.gameRule.humanityGrowUp.CurrentExp;
	}

	public static int Get_humanityGrowUp_MaxExp()
	{
		return Contexts.sharedInstance.gameRule.humanityGrowUp.MaxExp;
	}

	public static int Get_humanityGrowUp_AddAttack()
	{
		return Contexts.sharedInstance.gameRule.humanityGrowUp.AddAttack;
	}

	public static string Get_blastMessageData_PlayerName()
	{
		return Contexts.sharedInstance.message.blastMessageData.PlayerName;
	}

	public static C4MessageType Get_blastMessageData_Type()
	{
		return Contexts.sharedInstance.message.blastMessageData.Type;
	}

	public static bool Get_blastMessageData_Changed()
	{
		return Contexts.sharedInstance.message.blastMessageData.Changed;
	}

	public static bool Get_blastMessageData_GameOverGuiChanged()
	{
		return Contexts.sharedInstance.message.blastMessageData.GameOverGuiChanged;
	}

	public static bool Get_blastMessageData_GhostMessageChanged()
	{
		return Contexts.sharedInstance.message.blastMessageData.GhostMessageChanged;
	}

	public static bool Get_blastMessageData_GoldMessageChanged()
	{
		return Contexts.sharedInstance.message.blastMessageData.GoldMessageChanged;
	}

	public static bool Get_c4Message_Active()
	{
		return Contexts.sharedInstance.gameRule.c4State.Active;
	}

	public static int Get_c4Message_TotalTime()
	{
		return Contexts.sharedInstance.gameRule.currentRule.Rule.GetC4TotalTime();
	}

	public static int Get_c4Message_RemainTime()
	{
		GameRuleContext gameRule = Contexts.sharedInstance.gameRule;
		if (gameRule.hasC4State)
		{
			return gameRule.currentRule.Rule.GetC4TotalTime() - gameRule.c4State.Time;
		}
		return 0;
	}

	public static bool Get_c4Message_C4Flag()
	{
		return Contexts.sharedInstance.player.myPlayerEntity?.basicInfo.Current.C4Flag ?? false;
	}

	public static bool Get_c4Message_HasC4()
	{
		return Contexts.sharedInstance.player.myPlayerEntity?.basicInfo.Current.HasC4 ?? false;
	}

	public static bool Get_inBreakpoint_InBreakpoint()
	{
		if (Contexts.sharedInstance.player.isMyPlayer)
		{
			return Contexts.sharedInstance.player.myPlayerEntity.isInBreakpoint;
		}
		return false;
	}

	public static int Get_peekabooLikes_LikesCount()
	{
		return Contexts.sharedInstance.gameRule.peekabooLikes.LikesCount;
	}

	public static bool Get_peekabooLikes_ShowBlastLikes()
	{
		return Contexts.sharedInstance.gameRule.peekabooLikes.ShowBlastLikes;
	}

	public static int Get_deathMatchMessage_MessageType()
	{
		return Contexts.sharedInstance.message.deathMatchMessage.MessageType;
	}

	public static string Get_deathMatchMessage_Name()
	{
		return Contexts.sharedInstance.message.deathMatchMessage.Name;
	}

	public static List<DeathMatchMessageComponent.ParyReliveData> Get_deathMatchMessage_ParyMessage()
	{
		return Contexts.sharedInstance.message.deathMatchMessage.ParyMessage;
	}

	public static int Get_deathMatchMessage_CancelPary()
	{
		return Contexts.sharedInstance.message.deathMatchMessage.CancelPary;
	}

	public static bool Get_finalBioMessageData_VariantsGrowupChanged()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.VariantsGrowupChanged;
	}

	public static bool Get_finalBioMessageData_ChangeHumanityChanged()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.ChangeHumanityChanged;
	}

	public static bool Get_finalBioMessageData_SuperbioVariantsChanged()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.SuperbioVariantsChanged;
	}

	public static FinalBioMessageType Get_finalBioMessageData_VariantsGrowupType()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.VariantsGrowupType;
	}

	public static int Get_finalBioMessageData_VariantsGrowupTime()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.VariantsGrowupTime;
	}

	public static FinalBioMessageType Get_finalBioMessageData_ChangeHumanityType()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.ChangeHumanityType;
	}

	public static int Get_finalBioMessageData_ChangeHumanityTime()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.ChangeHumanityTime;
	}

	public static int Get_finalBioMessageData_AntidoteNum()
	{
		return Contexts.sharedInstance.message.finalBioMessageData.AntidoteNum;
	}

	public static bool Get_gameMessageData_Changed()
	{
		return Contexts.sharedInstance.message.gameMessageData.Changed;
	}

	public static int Get_gameMessageData_Type()
	{
		return Contexts.sharedInstance.message.gameMessageData.Type;
	}

	public static bool Get_gameMessageData_ReliveChanged()
	{
		return Contexts.sharedInstance.message.gameMessageData.ReliveChanged;
	}

	public static Dictionary<int, int> Get_gameMessageData_MsgTypeDic()
	{
		return Contexts.sharedInstance.message.gameMessageData.MsgTypeDic;
	}

	public static int Get_gameMessageData_ContinueBattleTimer()
	{
		return Contexts.sharedInstance.message.gameMessageData.ContinueBattleTimer;
	}

	public static GameMessageData Get_gameMessageData_MessageData()
	{
		return Contexts.sharedInstance.message.gameMessageData.MessageData;
	}

	public static SimpleProto Get_gameMessageData_SimpleProto()
	{
		return Contexts.sharedInstance.message.gameMessageData.SimpleProto;
	}

	public static bool Get_weaponParticleEffectLevel_Changed()
	{
		return Contexts.sharedInstance.message.gameMessageData.ParticleEffectLevelChanged;
	}

	public static bool Get_gameTipsData_Changed()
	{
		return Contexts.sharedInstance.message.gameMessageData.Changed;
	}

	public static Dictionary<int, int> Get_gameTipsData_MessageDic()
	{
		return Contexts.sharedInstance.message.gameTipsData.MessageDic;
	}

	public static SprayMessageType Get_sparyMessageData_Type()
	{
		return Contexts.sharedInstance.message.sparyMessageData.Type;
	}

	public static bool Get_sparyMessageData_Changed()
	{
		return Contexts.sharedInstance.message.sparyMessageData.Changed;
	}

	public static BuyPanelData Get_buyPanelData_PanelData()
	{
		return Contexts.sharedInstance.gameRule.buyPanelData.PanelData;
	}

	public static int Get_buyPanelData_GiveWeaponIndex()
	{
		return Contexts.sharedInstance.gameRule.buyPanelData.GiveWeaponIndex;
	}

	public static int Get_buyPanelData_WeaponType()
	{
		return Contexts.sharedInstance.gameRule.buyPanelData.WeaponType;
	}

	public static int Get_buyPanelData_WeaponIndex()
	{
		return Contexts.sharedInstance.gameRule.buyPanelData.WeaponIndex;
	}

	public static bool Get_goldExplodeBuyAreaData_InBuyArea()
	{
		return Contexts.sharedInstance.gameRule.goldExplodeBuyAreaData.InBuyArea;
	}

	public static int Get_goldExplodeBuyAreaData_BuyTime()
	{
		return Contexts.sharedInstance.gameRule.goldExplodeBuyAreaData.BuyTime;
	}

	public static BuyAreaListData Get_goldExplodeBuyAreaData_BuyArea()
	{
		return Contexts.sharedInstance.gameRule.goldExplodeBuyAreaData.BuyArea;
	}

	public static int Get_pveIncentiveTypeView_AchievementType()
	{
		return Contexts.sharedInstance.gameRule.pveIncentiveTypeView.AchievementType;
	}

	public static IntData Get_pveIncentiveView_IncentiveData()
	{
		return Contexts.sharedInstance.gameRule.pveIncentiveView.IncentiveData;
	}

	public static bool Get_pveIncentiveView_Dirty()
	{
		return Contexts.sharedInstance.gameRule.pveIncentiveView.Dirty;
	}

	public static int Get_pveUIMessage_MsgId()
	{
		return Contexts.sharedInstance.message.pveUIMessage.MsgId;
	}

	public static int Get_pveUIMessage_SkillTreeMsgId()
	{
		return Contexts.sharedInstance.message.pveUIMessage.SkillTreeMsgId;
	}

	public static bool Get_pveUIMessage_SkillTreeChanged()
	{
		return Contexts.sharedInstance.message.pveUIMessage.SkillTreeChanged;
	}

	public static int Get_pveUIMessage_Distance()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Distance;
	}

	public static bool Get_pveUIMessage_Visiable()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Visiable;
	}

	public static float Get_pveUIMessage_Rotation()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Rotation;
	}

	public static int Get_pveUIMessage_MaxSpiderEggNum()
	{
		return Contexts.sharedInstance.message.pveUIMessage.MaxSpiderEggNum;
	}

	public static int Get_pveUIMessage_CurSpiderEggNum()
	{
		return Contexts.sharedInstance.message.pveUIMessage.CurSpiderEggNum;
	}

	public static int Get_pveUIMessage_SelectSkillPanel()
	{
		return Contexts.sharedInstance.message.pveUIMessage.SelectSkillPanel;
	}

	public static bool Get_pveUIMessage_CanBuyWeapon()
	{
		return Contexts.sharedInstance.message.pveUIMessage.CanBuyWeapon;
	}

	public static bool Get_pveUIMessage_Reliveteammate()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Reliveteammate;
	}

	public static string Get_pveUIMessage_PlayerName()
	{
		return Contexts.sharedInstance.message.pveUIMessage.PlayerName;
	}

	public static bool Get_pveUIMessage_KillBoss()
	{
		return Contexts.sharedInstance.message.pveUIMessage.KillBoss;
	}

	public static bool Get_pveUIMessage_Copyweapon()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Copyweapon;
	}

	public static string Get_pveUIMessage_Weaponname()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Weaponname;
	}

	public static bool Get_pveUIMessage_Permancentweapon()
	{
		return Contexts.sharedInstance.message.pveUIMessage.Permancentweapon;
	}

	public static PveMessageData Get_pveMessage_PveMessageData()
	{
		return Contexts.sharedInstance.message.pveMessage.PveMessageData;
	}

	public static bool Get_pveMessage_BossWarning()
	{
		return Contexts.sharedInstance.message.pveMessage.BossWarning;
	}

	public static bool Get_pveState_AngryFireScarSkillShifang()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.ANGRY_FIRE_SCAR_SKILL_SHIFANG.ID);
	}

	public static bool Get_pveState_RpgShieldRecorvery()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_SHILED_RECORVERY.ID);
	}

	public static bool Get_pveState_EventUltrasonic()
	{
		return Contexts.sharedInstance.gameRule.pveState.EventUltrasonic;
	}

	public static int Get_pveState_UltrasonicTime()
	{
		return Contexts.sharedInstance.gameRule.pveState.UltrasonicTime;
	}

	public static bool Get_pveState_RpgBossjy2004Chuifeng()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_BOSSJY2004_CHUIFENG.ID);
	}

	public static bool Get_pveState_RpgBossjy6001Sdl()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_BOSSJY6001_SDL.ID);
	}

	public static bool Get_pveState_Anying1State()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.ANYING1_STATE.ID);
	}

	public static bool Get_pveState_Anying2State()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.ANYING2_STATE.ID);
	}

	public static bool Get_pveState_SubHp()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.SubHp ?? false;
	}

	public static bool Get_pveState_InFear()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.InFear ?? false;
	}

	public static bool Get_pveState_InChaos()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.InChaos ?? false;
	}

	public static bool Get_pveState_InHuoYanXianJi()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.InHuoYanXianJi ?? false;
	}

	public static bool Get_CommonState_NezhaSubmp()
	{
		return UiEventUtils.HasCameraOwnerStatus(10421);
	}

	public static bool Get_pveState_Red()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RED.ID);
	}

	public static bool Get_pveState_Yellow()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.YELLOW.ID);
	}

	public static bool Get_pveState_Blue()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.BLUE.ID);
	}

	public static bool Get_pveState_Black()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.BLACK.ID);
	}

	public static bool Get_pveState_Green()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.GREEN.ID);
	}

	public static bool Get_pveState_White()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.WHITE.ID);
	}

	public static bool Get_pveState_ShanDianHuan()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_BOSS10_SHANDIANHUAN.ID);
	}

	public static bool Get_pveState_AddHp()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_GROUP_HP_ADD.ID);
	}

	public static int Get_pveState_AddHpNum()
	{
		return UiEventUtils.GetCameraOwnerStatus(PlayerInfoStatusConstant.RPG_GROUP_HP_ADD.ID);
	}

	public static bool Get_pveState_AddShield()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_GROUP_SHILED_ADD.ID);
	}

	public static int Get_pveState_AddShieldNum()
	{
		return UiEventUtils.GetCameraOwnerStatus(PlayerInfoStatusConstant.RPG_GROUP_SHILED_ADD.ID);
	}

	public static bool Get_pveState_Ammunitionpackage()
	{
		return Contexts.sharedInstance.gameRule.pveState.Ammunitionpackage;
	}

	public static bool Get_pveState_Incentivetask()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.Incentivetask ?? false;
	}

	public static bool Get_pveState_RageSkillUsing()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.RageSkillUsing ?? false;
	}

	public static bool Get_pveState_Gliding()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.Gliding;
		}
		return false;
	}

	public static bool Get_pveState_PlayerWeaponFlashFlag()
	{
		return UiEventUtils.HasCameraOwnerState(16);
	}

	public static bool Get_pveState_BladeshieldDun()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.BLADESHIELD_DUN.ID);
	}

	public static bool Get_pveState_RpgYemolaixi()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_YEMOLAIXI.ID);
	}

	public static bool Get_pveState_P90HeroHuanrao()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.P90_HERO_HUANRAO.ID);
	}

	public static bool Get_pveState_Mp5MrFlag()
	{
		PlayerInfoData cameraOwnerPlayerInfo = UiEventUtils.GetCameraOwnerPlayerInfo();
		if (cameraOwnerPlayerInfo != null)
		{
			return cameraOwnerPlayerInfo.Mp5mrSkillFlag > 0;
		}
		return false;
	}

	public static bool Get_pveState_DartsredFlashBeattack()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.DARTSRED_FLASH_BEATTACK.ID);
	}

	public static bool Get_pveState_FlashBeattack()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.FLASH_BEATTACK.ID);
	}

	public static bool Get_pveState_ShotgunLaserBeattack()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.SHOTGUN_LASER_BEATTACK.ID);
	}

	public static bool Get_pveState_M60E6BloodangerAneer()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.M60E6BLOODANGER_ANEER.ID);
	}

	public static bool Get_pveState_RpgSkillQiji()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_SKILL_QIJI.ID);
	}

	public static bool Get_pveState_M60E6Addhp()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.M60E6_ADDHP.ID);
	}

	public static bool Get_pveState_HeroColdDeathShenhan()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_SHENHAN.ID);
	}

	public static bool Get_pveState_HeroColdDeathHubiBuff()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_HUBI_BUFF.ID);
	}

	public static bool Get_pveState_GRENADE_SHAXING()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.GRENADE_SHAXING.ID);
	}

	public static bool Get_pveState_PollutionShielding()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.POLLUTION_SHIELDING.ID);
	}

	public static bool Get_pveState_SkyDeagleCross()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_CROSS_STATE.ID);
	}

	public static bool Get_pveState_SkyDeagleSkillShifang()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_SHIFANG.ID);
	}

	public static bool Get_pveState_RpgBurstAssaultSkillBz()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_BURST_ASSAULT_SKILL_BZ.ID);
	}

	public static bool Get_pveState_PlayerMedicalpackageFlag()
	{
		return UiEventUtils.HasCameraOwnerState(65536);
	}

	public static bool Get_pveState_Obtainsupplies()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.Obtainsupplies ?? false;
	}

	public static bool Get_pveState_PlayerEnergyshieldSpeedFlag()
	{
		return UiEventUtils.HasCameraOwnerState(262144);
	}

	public static bool Get_pveState_PlayerAccelerateFlag()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (UiEventUtils.HasCameraOwnerState(2) && !RuleUtilty.IsBioMode(raceType))
		{
			return !RuleUtilty.IsRpg(raceType);
		}
		return false;
	}

	public static bool Get_pveState_BioPlayerAccelerateFlag()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (UiEventUtils.HasCameraOwnerState(2))
		{
			return RuleUtilty.IsBioMode(raceType);
		}
		return false;
	}

	public static bool Get_pveState_RpgPlayerAccelerateFlag()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (UiEventUtils.HasCameraOwnerState(2))
		{
			return RuleUtilty.IsRpg(raceType);
		}
		return false;
	}

	public static bool Get_pveState_PlayerHumanUpspeedFlag()
	{
		return UiEventUtils.HasCameraOwnerState(512);
	}

	public static bool Get_pveState_PlayerEnergyshieldFlag()
	{
		if (CameraOwnerEntity != null)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (UiEventUtils.HasCameraOwnerState(64))
			{
				if (PlayerCareerConstantUtility.IsDoun(CameraOwnerEntity.GetCareer()))
				{
					if (raceType != 14 && raceType != 118 && raceType != 20)
					{
						return raceType != 16;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool Get_pveState_AwakePlayerEnergyshieldFlag()
	{
		if (CameraOwnerEntity != null)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (CameraOwnerEntity.HasState(64))
			{
				if (PlayerCareerConstantUtility.IsDoun(CameraOwnerEntity.GetCareer()))
				{
					if (raceType != 20 && raceType != 14 && raceType != 118)
					{
						return raceType == 16;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool Get_pveState_UltimateTime()
	{
		IGameRule rule = Contexts.sharedInstance.gameRule.currentRule.Rule;
		SectionTimeComponent sectionTime = Contexts.sharedInstance.battleRoom.sectionTime;
		if (rule.GetUltimateTime() > 0 && sectionTime.SectionTime > 0)
		{
			return sectionTime.SectionTime < rule.GetUltimateTime();
		}
		return false;
	}

	public static bool Get_pveState_PlayerDeathcallFlag()
	{
		return UiEventUtils.HasCameraOwnerState(32);
	}

	public static bool Get_pveState_UseingSnakeSpirit()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.UseingSnakeSpirit ?? false;
	}

	public static bool Get_pveState_SwordHellSnakeShield()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.SWORD_HELL_SNAKE_SHIELD.ID);
	}

	public static bool Get_pveState_PlayerWarrantDecelerateFlag()
	{
		return UiEventUtils.HasCameraOwnerState(16384);
	}

	public static bool Get_pveState_PlayerDisarmFlag()
	{
		return UiEventUtils.HasCameraOwnerState(4);
	}

	public static bool Get_pveState_AwmLegendLiuxue()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.AWM_LEGEND_LIUXUE.ID);
	}

	public static bool Get_pveState_RpgLiziH()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_LIZI_H.ID);
	}

	public static bool Get_pveState_RpgLiziL()
	{
		if (!UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.RPG_LIZI_L.ID))
		{
			return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.ENEMY_IN_SYMPHONY_SHIELD.ID);
		}
		return true;
	}

	public static bool Get_pveState_XiyaLiangzihudun()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.XIYA_LIANGZIHUDUN.ID);
	}

	public static bool Get_pveState_HeroColdHUBIDeath()
	{
		return UiEventUtils.HasCameraOwnerStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_HUBI_BUFF.ID);
	}

	public static bool Get_pveState_BeDeathCall()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.BeDeathCall ?? false;
	}

	public static bool Get_pveState_Phasetransfer()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.Phasetransfer ?? false;
	}

	public static bool Get_pveState_DamageDeep()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.DamageDeep ?? false;
	}

	public static bool Get_pveState_InCoverSkillUsing()
	{
		return UiEventUtils.GetCameraOwnerPlayerInfo()?.InCoverSkillUsing ?? false;
	}

	public static long Get_pveTeamScore_Score()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.oneKillInfo.Data != null)
		{
			return MyPlayerEntity.oneKillInfo.Data.Score;
		}
		return 0L;
	}

	public static int Get_pveTeamScore_CurRound()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.CurrentScore;
	}

	public static int Get_pveTeamScore_AllRound()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.WinScore;
	}

	public static long Get_pveTeamScore_BotNum()
	{
		return Contexts.sharedInstance.gameRule.broadcastScore.Team2Score;
	}

	public static PlotData Get_dialogue_PlotData()
	{
		return Contexts.sharedInstance.message.dialog.PlotData;
	}

	public static List<RpgTipsEventData> Get_gameTipsShow_TipsEvent()
	{
		return Contexts.sharedInstance.message.gameTipsShow.TipsEvent;
	}

	public static RpgTipsEventData Get_gameTipsShow_RpgGroupWaitPlayer()
	{
		return Contexts.sharedInstance.message.gameTipsShow.RpgGroupWaitPlayer;
	}

	public static int Get_hpProgressData_TargetId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.TargetId;
	}

	public static int Get_hpProgressData_EliteTargetId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteTargetId;
	}

	public static int Get_hpProgressData_BotId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotId;
	}

	public static int Get_hpProgressData_EliteId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteId;
	}

	public static int Get_hpProgressData_BossId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossId;
	}

	public static bool Get_hpProgressData_ShowBossHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.ShowBossHp;
	}

	public static int Get_hpProgressData_HomeId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.HomeId;
	}

	public static int Get_hpProgressData_TowerId()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.TowerId;
	}

	public static string Get_hpProgressData_BotName()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotName;
	}

	public static int Get_hpProgressData_BotLevel()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotLevel;
	}

	public static int Get_hpProgressData_BotShowTime()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotShowTime;
	}

	public static float Get_hpProgressData_BotHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotHpPercent;
	}

	public static float Get_critDefhpProgressData_BotHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritDefHpPercent;
	}

	public static float Get_critRateDefHpPercentData_BotHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefHpPercent;
	}

	public static float Get_critDefhpMaxData_BotHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritDefMaxHp;
	}

	public static float Get_critRateDefHpMaxData_BotHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefMaxHp;
	}

	public static List<string> Get_hpProgressData_BotRaceInfo()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BotRaceInfo;
	}

	public static int Get_hpProgressData_BotTitle()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.titleid;
	}

	public static string Get_hpProgressData_EliteName()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteName;
	}

	public static int Get_hpProgressData_EliteType()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteType;
	}

	public static int Get_hpProgressData_EliteLevel()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteLevel;
	}

	public static float Get_hpProgressData_EliteHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteHpPercent;
	}

	public static float Get_critDefhpProgressData_EliteHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritDefHpPercent;
	}

	public static float Get_critRateDefHpPercentData_EliteHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefHpPercent;
	}

	public static float Get_critDefhpMaxData_EliteHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritDefMaxHp;
	}

	public static float Get_critRateDefHpMaxData_EliteHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefMaxHp;
	}

	public static List<string> Get_hpProgressData_EliteRaceInfo()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.EliteRaceInfo;
	}

	public static string Get_hpProgressData_BossName()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossName;
	}

	public static string Get_CritHpData_BgName()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritHpBgName;
	}

	public static string Get_hpProgressData_BossCareer()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossCareer;
	}

	public static int Get_hpProgressData_BossType()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossType;
	}

	public static int Get_hpProgressData_BossLevel()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossLevel;
	}

	public static float Get_hpProgressData_BossHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHpPercent;
	}

	public static float Get_critDefhpProgressData_BossHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritDefHpPercent;
	}

	public static bool Get_critDefhpProgressData_BossAddResisShow()
	{
		if (!(Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefMaxHp > 0f))
		{
			return Contexts.sharedInstance.gameRule.hpProgressData.CritDefMaxHp > 0f;
		}
		return true;
	}

	public static float Get_critRateDefHpPercentData_BossHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.CritRateDefHpPercent;
	}

	public static bool Get_critDefhpBLData_BossBL()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.IsCritDefBreak;
	}

	public static bool Get_critRateDefHpBSData_BossBS()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.IsCritRateDefBreak;
	}

	public static float Get_hpProgressData_BossHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHp;
	}

	public static float Get_hpProgressData_BossMaxHp()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossMaxHp;
	}

	public static float Get_hpProgressData_BossLockPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.lockPercent;
	}

	public static float Get_hpProgressData_BossHuDunPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHudunPercent;
	}

	public static float Get_hpProgressData_BossCurHdPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHudun;
	}

	public static float Get_hpProgressData_BossMaxHdPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossMaxHudun;
	}

	public static float Get_hpProgressData_BossZhuangJiaPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossZhuangjiaPercent;
	}

	public static float Get_hpProgressData_BossCurZjPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossZhuangjia;
	}

	public static float Get_hpProgressData_BossMaxZjPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossMaxZhuangjia;
	}

	public static float Get_hpProgressData_BossMaxHuDun()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossMaxHudun;
	}

	public static float Get_hpProgressData_BossMaxZhuangJia()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossMaxZhuangjia;
	}

	public static float Get_hpProgressData_BossHuDun()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHudun;
	}

	public static float Get_hpProgressData_BossZhuangJia()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossZhuangjia;
	}

	public static bool Get_hpProgressData_BossLock()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.isLock;
	}

	public static float Get_hpProgressData_BosslockPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.lockPercent;
	}

	public static int Get_hpProgressData_CurrentLifeBarSeq()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.currentLifeBarSeq;
	}

	public static List<int> Get_hpProgressData_BosslifeBarSeq()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.lifeBarSeq;
	}

	public static float Get_hpProgressData_BossCurPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossCurPercent;
	}

	public static string Get_hpProgressData_BossHpBackImage()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHpBackImage;
	}

	public static string Get_hpProgressData_BossHpProgressImage()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossHpProgressImage;
	}

	public static int Get_hpProgressData_BossHpProgressExtraLife()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.ExtraLife;
	}

	public static List<string> Get_hpProgressData_BossRaceInfo()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossRaceInfo;
	}

	public static float Get_hpProgressData_BossShieldPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.BossShieldPercent;
	}

	public static float Get_hpProgressData_HomeHpPercent()
	{
		return Contexts.sharedInstance.gameRule.hpProgressData.HomeHpPercent;
	}

	public static int Get_rpgSkillStateData_CurrentXpEnergy()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.CurrentXpEnergy;
	}

	public static int Get_rpgSkillStateData_TotalXpEnergy()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.TotalXpEnergy;
	}

	public static int Get_rpgSkillStateData_CanChangeBagCount()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.CanChangeBagCount;
	}

	public static bool Get_rpgSkillStateData_IsXpEnergyAddByKill()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.IsXpEnergyAddByKill;
	}

	public static int Get_rpgSkillStateData_Money()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.Money;
	}

	public static int Get_rpgTower_Money()
	{
		return Contexts.sharedInstance.gameRule.rpgSkillStateData.RpgTowerMoney;
	}

	public static int Get_rpgTaskTarget_Wave()
	{
		return Contexts.sharedInstance.gameRule.rpgTaskTarget.Wave;
	}

	public static int Get_rpgTaskTarget_MasteryCoin()
	{
		return Contexts.sharedInstance.gameRule.rpgTaskTarget.MasteryCoin;
	}

	public static int Get_rpgTaskTarget_Obsidian()
	{
		return Contexts.sharedInstance.gameRule.rpgTaskTarget.Obsidian;
	}

	public static List<TaskInfo> Get_task_TaskList()
	{
		return Contexts.sharedInstance.gameRule.task.TaskList;
	}

	public static List<string> Get_selectWeapon_WeaponNameList()
	{
		return Contexts.sharedInstance.gameRule.selectWeapon.WeaponNameList;
	}

	public static List<string> Get_selectWeapon_SecondWeaponNameList()
	{
		return Contexts.sharedInstance.gameRule.selectWeapon.SecondWeaponNameList;
	}

	public static List<bool> Get_selectWeaponType_WeaponTypeList()
	{
		return Contexts.sharedInstance.gameRule.selectWeaponType.WeaponTypeList;
	}

	public static OneKillInfoData Get_CameraOwner_KillInfoData()
	{
		if (CameraOwnerEntity != null && CameraOwnerEntity.hasOneKillInfo)
		{
			return CameraOwnerEntity.oneKillInfo.Data;
		}
		return null;
	}

	public static bool Get_RadarMap_Show()
	{
		return true;
	}

	public static bool Get_RadarMap_Hide()
	{
		return false;
	}

	public static bool Get_MouseYear_TipsCd()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.TipsCd;
	}

	public static bool Get_MouseYear_TipsPick()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.TipsPick;
	}

	public static bool Get_MouseYear_TipsReachPoint()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.TipsReachPoint;
	}

	public static bool Get_MouseYear_TipsStart()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.TipsStart;
	}

	public static bool Get_MouseYear_TipsArrive()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.TipsArrive;
	}

	public static bool Get_MouseYear_ShowDropWeapon()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.ChooseDropWeapon;
	}

	public static bool Get_MouseYear_ShowDropWeaponListUi()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.IsChooseDropWeaponList;
	}

	public static float Get_MouseYear_CarProgress()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.CarProcess;
	}

	public static int Get_MouseYear_EnemyData()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.NowEnemyData;
	}

	public static bool Get_Boss_XuliShow()
	{
		return Contexts.sharedInstance.gameRule.rpg6005.show;
	}

	public static int Get_Boss_XuliProcess()
	{
		return Contexts.sharedInstance.gameRule.rpg6005.currentProcessValue;
	}

	public static bool Get_Boss_LeiyinShow()
	{
		return Contexts.sharedInstance.gameRule.rpg6005.leiyinShow;
	}

	public static int Get_Boss_LeiyinCengshu()
	{
		return Contexts.sharedInstance.gameRule.rpg6005.leiyinCengshu;
	}

	public static bool Get_MouseYear_ShowSkillTree()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.IsShowSkillTree;
	}

	public static int Get_MouseYear_SkillTreePoint()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.SkillPoint;
	}

	public static List<int> Get_MouseYear_SkillTreeActive()
	{
		return Contexts.sharedInstance.gameRule.mouseYear.ActiveSkillList;
	}

	public static bool Get_Addiction()
	{
		if (Contexts.sharedInstance.battleRoom == null || Contexts.sharedInstance.battleRoom.antiAddiction == null || Contexts.sharedInstance.battleRoom.antiAddiction.AntiJObject == null || !Contexts.sharedInstance.battleRoom.antiAddiction.IsRefresh)
		{
			return false;
		}
		return true;
	}

	public static bool Get_Ace()
	{
		if (Contexts.sharedInstance.battleRoom == null || Contexts.sharedInstance.battleRoom.ace == null || !Contexts.sharedInstance.battleRoom.ace.IsRefresh)
		{
			return false;
		}
		return true;
	}

	public static bool Get_Craze_SkillChoose()
	{
		return true;
	}

	public static bool Get_Craze_SkillLearn()
	{
		return true;
	}

	public static int Get_cameraOwnerData_HeroPower()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.HeroPower;
		}
		return 0;
	}

	public static int Get_cameraOwnerData_HeroMaxPower()
	{
		if (CameraOwnerEntity != null)
		{
			return CameraOwnerEntity.basicInfo.Current.HeroMaxPower;
		}
		return 0;
	}

	public static NBioZInitData Get_gameBioZ_TipsEvent()
	{
		return Contexts.sharedInstance.message.bioZInit.BioZInitData;
	}

	public static NBioZDiffWeaponData Get_gameBioZ_DiffWeaponEvent()
	{
		return Contexts.sharedInstance.message.bioZInit.BioZDiffWeaponData;
	}

	public static List<HeJiTabKeyData> Get_StarWalker_MixtureData()
	{
		return Contexts.sharedInstance.gameRule.rpgStarWalker.mixtureDatas;
	}

	public static void Init()
	{
		Cid2PlayerEntity.Clear();
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item.hasBasicInfo)
			{
				Cid2PlayerEntity[item.basicInfo.Cid] = item;
			}
		}
		CameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		MyPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		CurrentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		SnapshotEntity = Contexts.sharedInstance.snapshot.snapshotsEntity;
	}

	public static void Clear()
	{
		CameraOwnerEntity = null;
		CurrentWeaponEntity = null;
		SnapshotEntity = null;
		MyPlayerEntity = null;
		Cid2PlayerEntity.Clear();
	}

	public static bool Get_uiMyPlayer_IsSpeaking()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.voice.Speaking;
		}
		return false;
	}

	public static int Get_uiMyPlayer_Volume()
	{
		return 255;
	}

	public static List<PlayerEntity> Get_allPlayerEntity_SelfSideList()
	{
		PlayerEntityList.Clear();
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			bool flag = RuleUtilty.IsVoiceShowAndNoTeamDiff(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType);
			if (item != null && !item.IsMySelf() && !item.IsBot() && (flag || item.GetTeam() == MyPlayerEntity.GetTeam()))
			{
				PlayerEntityList.Add(item);
			}
		}
		return PlayerEntityList;
	}

	public static string Get_OnePlayerEntityName_Shield(PlayerEntity val, int idx)
	{
		return val.basicInfo.PlayerName;
	}

	public static bool Get_OnePlayerEntityIsShield_Shield(PlayerEntity val, int idx)
	{
		if (MyPlayerEntity == null)
		{
			return false;
		}
		foreach (KeyValuePair<uint, long> item in Contexts.sharedInstance.battleRoom.playerInfo.VoiceShieldDictionary)
		{
			if (item.Key == val.entityId.Value)
			{
				return true;
			}
		}
		return false;
	}
}

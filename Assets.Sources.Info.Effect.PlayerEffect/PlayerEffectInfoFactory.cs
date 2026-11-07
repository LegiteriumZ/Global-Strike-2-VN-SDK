using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;
using Assets.Sources.Info.Effect.PlayerEffect.ViewEffectInfo;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas.Utils;
using SSJJRunTimeDataSample.Utility;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerEffectInfoFactory
{
	private static PlayerEffectInfoFactory _instance;

	private readonly Dictionary<int, CommonPlayerStatusEffectInfo> _playerInfoDictionary;

	private readonly List<int> _ignoreIdList = new List<int>
	{
		61,
		62,
		64,
		65,
		1006,
		1011,
		1012,
		1016,
		1019,
		1020,
		1021,
		1023,
		1027,
		1031,
		1032,
		1033,
		1049,
		1052,
		1053,
		1054,
		1058,
		1062,
		1066,
		1067,
		1068,
		1069,
		1070,
		1078,
		1082,
		1083,
		1084,
		1086,
		1087,
		1090,
		1092,
		1095,
		1096,
		1103,
		1104,
		1105,
		1014,
		1150,
		1117,
		1134,
		1135,
		1140,
		1146,
		1156,
		1157,
		1159,
		1170,
		1211,
		10013,
		10014,
		10015,
		10016,
		10017,
		10046,
		1202,
		10054,
		1220,
		20049,
		1226,
		1231,
		21002,
		21004,
		20061,
		20062,
		21006,
		21005,
		10087,
		1246,
		1247,
		1218,
		21019,
		PlayerInfoStatusConstant.GRENADE_SHAXING.ID,
		PlayerInfoStatusConstant.CLEAR_BUFF.ID,
		PlayerInfoStatusConstant.GRENADE_DRARK_ACTION_DAMAGE_CD.ID,
		PlayerInfoStatusConstant.GRENADE_DRARK_ACTION_CLEAN_CD.ID,
		PlayerInfoStatusConstant.GUARDIAN_YH1_V5_USE_SKILL.ID,
		PlayerInfoStatusConstant.NO_BLOWUP.ID,
		PlayerInfoStatusConstant.SLOW_DOWN_PISTOL_FLAG.ID,
		PlayerInfoStatusConstant.M60E6_ADDHP.ID,
		PlayerInfoStatusConstant.SLOW_DOWN_FLAG.ID,
		PlayerInfoStatusConstant.TEAM_RACES_CAN_NOT_PICKUP.ID,
		PlayerInfoStatusConstant.HURT_DEEP.ID,
		PlayerInfoStatusConstant.Prefab_buff_bai.ID,
		PlayerInfoStatusConstant.Prefab_buff_hong.ID,
		PlayerInfoStatusConstant.Prefab_buff_huang.ID,
		PlayerInfoStatusConstant.Prefab_buff_lan.ID,
		PlayerInfoStatusConstant.SMALLMAP_SEE_TARGETPLAYER.ID,
		PlayerInfoStatusConstant.SYBIL_X_SKILL_STEALH.ID,
		PlayerInfoStatusConstant.USING_ROLE1019_HUAN.ID,
		PlayerInfoStatusConstant.M4A1_JINJIE1.ID,
		PlayerInfoStatusConstant.M4A1_JINJIE2.ID,
		PlayerInfoStatusConstant.M4A1_JINJIE3.ID,
		30006,
		100009,
		PlayerInfoStatusConstant.IMMUNE_CAN_NOT_ATTRACTED.ID,
		PlayerInfoStatusConstant.PLAYER_STEALTH4_FLAG.ID,
		PlayerInfoStatusConstant.ON_SKATE_BOARD.ID,
		PlayerInfoStatusConstant.Bio_Attack.ID,
		PlayerInfoStatusConstant.HIDE_FIRST_VIEW.ID,
		PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_1.ID,
		PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_2.ID,
		PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_3.ID,
		PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_4.ID,
		PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_5.ID
	};

	public static PlayerEffectInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new PlayerEffectInfoFactory();
			}
			return _instance;
		}
	}

	public List<IPlayerEffectInfo> PlayerInfoList { get; private set; }

	public List<IPlayerShowEffectInfo> PlayerEffectInfoShowList { get; private set; }

	public List<IPlayerViewShowEffectInfo> PlayerEffectInfoViewShowList { get; private set; }

	public bool IsIgnored(int playerInfoId)
	{
		return _ignoreIdList.Contains(playerInfoId);
	}

	public PlayerEffectInfoFactory()
	{
		PlayerInfoList = new List<IPlayerEffectInfo>();
		PlayerEffectInfoShowList = new List<IPlayerShowEffectInfo>();
		PlayerEffectInfoViewShowList = new List<IPlayerViewShowEffectInfo>();
		_playerInfoDictionary = new Dictionary<int, CommonPlayerStatusEffectInfo>();
		Init();
	}

	public IPlayerEffectInfo GetPlayerEffectInfoByStatusId(int statusId)
	{
		if (_ignoreIdList.Contains(statusId))
		{
			return null;
		}
		if (!_playerInfoDictionary.ContainsKey(statusId))
		{
			PlayerInfoEffectData playerInfoEffectData = ParticleManager.Instance().GetPlayerInfoEffectData(StringCache.IntToString(statusId));
			if (playerInfoEffectData == null)
			{
				_ = 0;
			}
			if (playerInfoEffectData == null && statusId > 0)
			{
				return null;
			}
			if (playerInfoEffectData.viewShow == 1)
			{
				_playerInfoDictionary[statusId] = new PlayerViewStatusEffectInfo(statusId);
			}
			else
			{
				_playerInfoDictionary[statusId] = new CommonPlayerStatusEffectInfo(statusId);
			}
		}
		return _playerInfoDictionary[statusId];
	}

	private void Init()
	{
		PlayerEffectInfoShowList.Add(new ZiLvShouWeiEffectInfo());
		PlayerEffectInfoShowList.Add(new Boss1023EffectInfo());
		PlayerEffectInfoShowList.Add(new Boss1019EffectInfo());
		PlayerEffectInfoShowList.Add(new GuardianEffectInfo());
		PlayerEffectInfoShowList.Add(new VariationMonsterEffectInfo());
		PlayerEffectInfoShowList.Add(new PlayerHeroGuanZiEffectInfo());
		PlayerEffectInfoShowList.Add(new PlayerHeroSangZhongEffectInfo());
		PlayerEffectInfoViewShowList.Add(new MechNearViewEffectInfo());
		PlayerEffectInfoViewShowList.Add(new PlayerHeroGuanZiViewEffectInfo());
		PlayerEffectInfoViewShowList.Add(new PlayerHeroSangZhongViewEffectInfo());
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x != typeof(CommonPlayerStatusEffectInfo) && x.ImplementsInterface<IPlayerEffectInfo>())
		{
			Instance.PlayerInfoList.Add(Activator.CreateInstance(x) as IPlayerEffectInfo);
		}
	}

	public static void InitTypes()
	{
		Instance.PlayerInfoList.Add(new WidlFireEffectInfo());
		Instance.PlayerInfoList.Add(new WarrantEffectInfo());
		Instance.PlayerInfoList.Add(new WaitUseFearEffectInfo());
		Instance.PlayerInfoList.Add(new UseDartsEffectInfo());
		Instance.PlayerInfoList.Add(new UseAntidoteEffectInfo());
		Instance.PlayerInfoList.Add(new UseAk47HeroSlillEffectInfo());
		Instance.PlayerInfoList.Add(new TreatmentAuraEffectInfo());
		Instance.PlayerInfoList.Add(new ToushiEffectInfo());
		Instance.PlayerInfoList.Add(new TheGripOfDeathEffectInfo());
		Instance.PlayerInfoList.Add(new TacticsSoundEffectInfo());
		Instance.PlayerInfoList.Add(new SkillLockPlayerEffectInfo());
		Instance.PlayerInfoList.Add(new SkillLockIconEffectInfo());
		Instance.PlayerInfoList.Add(new RevolverBattleEffectInfo());
		Instance.PlayerInfoList.Add(new RevolverBattleSkinPurpEffectInfo());
		Instance.PlayerInfoList.Add(new RemoteVariantGunFireEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerUavEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerTailEffectInfo());
		Instance.PlayerInfoList.Add(new ModePlayer3EffectInfo());
		Instance.PlayerInfoList.Add(new ModePlayer2EffectInfo());
		Instance.PlayerInfoList.Add(new ModePlayer1EffectInfo());
		Instance.PlayerInfoList.Add(new PlayerStateEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerSneakEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerShockEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerShadowEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerRobChicken());
		Instance.PlayerInfoList.Add(new PlayerRageEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerInShadowInfo());
		Instance.PlayerInfoList.Add(new PlayerIceBoundEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerGoldWeaponRailEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerGhostEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerEventAlphaShadowEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerLodEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerFlySprintEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerDeadEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerCoverEffectInfo());
		Instance.PlayerInfoList.Add(new PhaseTransferEffectInfo());
		Instance.PlayerInfoList.Add(new MechHpEffectInfo());
		Instance.PlayerInfoList.Add(new LeaderSuggestEffectInfo());
		Instance.PlayerInfoList.Add(new IsBeAbyssSetKillEffectInfo());
		Instance.PlayerInfoList.Add(new IncentivetaskEffectInfo());
		Instance.PlayerInfoList.Add(new InYuanjunEffectInfo());
		Instance.PlayerInfoList.Add(new InWhirlingDeathEffectInfo());
		Instance.PlayerInfoList.Add(new InSnakeSpiritEffectInfo());
		Instance.PlayerInfoList.Add(new InLeitingchongjiEffectInfo());
		Instance.PlayerInfoList.Add(new InHanbingtuxiEffectInfo());
		Instance.PlayerInfoList.Add(new InChongyingEffectInfo());
		Instance.PlayerInfoList.Add(new InBingrenxuanfengEffectInfo());
		Instance.PlayerInfoList.Add(new HeroSuggestEffectInfo());
		Instance.PlayerInfoList.Add(new HelpReliveSuggestEffectInfo());
		Instance.PlayerInfoList.Add(new HasLightningBoundEffectInfo());
		Instance.PlayerInfoList.Add(new GhostShockEffectInfo());
		Instance.PlayerInfoList.Add(new FrostBreathEffectInfo());
		Instance.PlayerInfoList.Add(new EnergyShieldEffectInfo());
		Instance.PlayerInfoList.Add(new DragonWhirlwindLevelUpEffectInfo());
		Instance.PlayerInfoList.Add(new DragonWhirlwindEffectInfo());
		Instance.PlayerInfoList.Add(new DeathCallEffectInfo());
		Instance.PlayerInfoList.Add(new CursedEffectInfo());
		Instance.PlayerInfoList.Add(new ChangedHumanEffectInfo());
		Instance.PlayerInfoList.Add(new BiochemicalShellEffectInfo());
		Instance.PlayerInfoList.Add(new BePhaseTransferEffectInfo());
		Instance.PlayerInfoList.Add(new AddHpEffectInfo());
		Instance.PlayerInfoList.Add(new InVertigoEffectInfo());
		Instance.PlayerInfoList.Add(new AccelerateEffectInfo());
		Instance.PlayerInfoList.Add(new ParasiticSniperEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerRpgLootBufferInfo());
		Instance.PlayerInfoList.Add(new PlayerStealExpertEffectInfo());
		Instance.PlayerInfoList.Add(new ArmamentJxldIconEffectInfo());
		Instance.PlayerInfoList.Add(new PlayerYingyagnHuanyinEffectInfo());
		Instance.PlayerInfoList.Add(new MonsterSkillIconsEffectInfo());
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x != typeof(CommonPlayerStatusEffectInfo) && x.ImplementsInterface<IPlayerEffectInfo>())
		{
			return $"Instance.PlayerInfoList.Add(new {x.Name}());";
		}
		return "";
	}
}

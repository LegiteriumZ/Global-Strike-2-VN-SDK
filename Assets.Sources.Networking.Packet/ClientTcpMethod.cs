using System.Collections.Generic;

namespace Assets.Sources.Networking.Packet;

public class ClientTcpMethod
{
	public const int PolicyResult = -1;

	public const int CallbackLogin = 1;

	public const int TcpConnectionId = 1000;

	public const int SnapshotByTcp = 2;

	public const int OnGameInit = 3;

	public const int BroadcastScore = 4;

	public const int Win = 5;

	public const int KillPlayerInfo = 6;

	public const int BeKill = 7;

	public const int AllKillInfo = 8;

	public const int PlayerLogin = 9;

	public const int PlayerLogout = 10;

	public const int RoomData = 12;

	public const int StartNewSection = 13;

	public const int C4Active = 14;

	public const int StartProgress = 15;

	public const int C4Message = 16;

	public const int LastMvp = 17;

	public const int MissionSuccess = 18;

	public const int MissionFailed = 19;

	public const int DamageCount = 20;

	public const int ResetYaw = 21;

	public const int TacticsSound = 22;

	public const int BioDeadPlayerNum = 23;

	public const int Ping = 24;

	public const int BioMessage = 25;

	public const int BioDamage = 26;

	public const int Skillcdtime = 27;

	public const int Assistsnum = 28;

	public const int GroupBestKill = 29;

	public const int Observerinfo = 30;

	public const int NewBieguidFlag = 31;

	public const int Lockcamera = 33;

	public const int Unlockcamera = 34;

	public const int GameMessage = 35;

	public const int CrystalDrop = 36;

	public const int AddEvent = 37;

	public const int SprayMessage = 38;

	public const int NewPlayerList = 39;

	public const int NewWeaponList = 40;

	public const int Showchangezombi = 41;

	public const int ShowChangeHero = 43;

	public const int GameServerSetup = 44;

	public const int KingOfGunKingInfo = 45;

	public const int KingOfGunSelfInfo = 46;

	public const int ShowWeaponList = 47;

	public const int UpgradeWeaponLv = 48;

	public const int GroupKingOfGunKillNum = 49;

	public const int GroupKingOfGunMessage = 50;

	public const int PlayerSkillAdditional = 51;

	public const int ShowPlayerSkillList = 52;

	public const int RecreationGroupExp = 54;

	public const int ShowChangeHeroWoman = 55;

	public const int DeathMatchMessage = 56;

	public const int UpdatePlayerFriendly = 57;

	public const int FinalBioMessage = 59;

	public const int BiochemicalBest = 60;

	public const int PlayerInfo = 61;

	public const int ClearForNewSection = 62;

	public const int GhostBioMessage = 63;

	public const int BigHeadProgress = 64;

	public const int BigHeadMessage = 65;

	public const int UpdateExp = 66;

	public const int AddExp = 67;

	public const int UpdateMp = 68;

	public const int SkillTreeList = 69;

	public const int ShowHpType = 70;

	public const int PveMessage = 71;

	public const int Achievement = 72;

	public const int PeekabooStarUpdate = 73;

	public const int GameRuleNeedConfig = 74;

	public const int RewardType = 75;

	public const int PeekabooMessageUpdate = 76;

	public const int SendAllSceneItemEntity = 77;

	public const int PeekabooMissionReport = 78;

	public const int PeekabooZhuanPan = 79;

	public const int PeekabooUpPickItem = 80;

	public const int PeekabooLikesCount = 81;

	public const int PeekabooItemChangeList = 82;

	public const int BioLvUp = 83;

	public const int MetalmanSkill = 84;

	public const int UpdateStronghold = 86;

	public const int BladeStrongholdMessage = 87;

	public const int BuyPanel = 88;

	public const int BuyArea = 89;

	public const int UpdateHumanExpAndLv = 90;

	public const int UpdateZombieExpAndLv = 91;

	public const int TideZombieShieldUpdate = 92;

	public const int MechWarriorHumanInfo = 93;

	public const int MechWarriorInfo = 94;

	public const int MechWarriorMessage = 95;

	public const int GameEmoji = 96;

	public const int SimpleUiData = 100;

	public const int MechCharageMessage = 101;

	public const int UpdateMechMaxScoreMessage = 102;

	public const int ShowChangeAvatarMessage = 103;

	public const int UpdateBiochemicalMeshHumanLv = 104;

	public const int ShowServerDebugErrorMessage = 105;

	public const int Bio2LvUp = 106;

	public const int PlugInPlayerList = 107;

	public const int RobChickenMessage = 108;

	public const int ShowWeapon = 109;

	public const int GetWeaponList = 110;

	public const int SendMapInfoWhenLogin = 111;

	public const int RpgCountUpdate = 114;

	public const int UpdateValue = 115;

	public const int SetPlayerStautsValue = 116;

	public const int GameTipsShow = 117;

	public const int SendSystemMessage = 118;

	public const int SceneXmlFile = 119;

	public const int WeaponMasterMessage = 120;

	public const int RewardHintData = 121;

	public const int UavMessage = 122;

	public const int TakeSnapshot = 123;

	public const int RecycleWeapon = 124;

	public const int SceneObjectXmlFile = 125;

	public const int RpgCounterList = 126;

	public const int NeedLoadResource = 127;

	public const int GunGloryMessage = 128;

	public const int NewNpcList = 129;

	public const int LimitYawSpeed = 130;

	public const int HitPlayer = 131;

	public const int VotePanel = 133;

	public const int VoteChange = 134;

	public const int VotePanelClose = 135;

	public const int UnityProxy = 199;

	public const int UpdateWeightlessness = 200;

	public const int ChangeScene = 201;

	public const int RpgPlotData = 202;

	public const int RecycleWeaponSkin = 203;

	public const int CanLeaveRoom = 204;

	public const int CanNotLeaveRoom = 205;

	public const int BeingHitMessage = 428;

	public const int AllObserverName = 42;

	public const int UpdateKingTreasuryCoin = 207;

	public const int UpdateGameRuleDamageEvent = 208;

	public const int BonusWeaponKillInfo = 209;

	public const int SpecialArea = 210;

	public const int FloatingMessage = 211;

	public const int BioItems = 212;

	public const int RecycleCareerSkin = 213;

	public const int Abyssmessage = 214;

	public const int UpdateSelectPanel = 215;

	public const int SceneMapData = 216;

	public const int PosGroupChange = 217;

	public const int AddPopMsg = 218;

	public const int WeaponPendantDrop = 219;

	public const int StormScore = 220;

	public const int NinjaMark = 221;

	public const int OnGetPlayerList = 222;

	public const int UpdateOtherProcess = 223;

	public const int Jump2GameRuleSendedReport = 224;

	public const int SendDeadEyeMessage = 225;

	public const int ShowHp = 226;

	public const int MeshGiddy = 227;

	public const int PlaySound = 228;

	public const int PersonalityList = 229;

	public const int HitMarkPlayer = 230;

	public const int TeamRaceUiMessage = 231;

	public const int PlayerLoginOnInitData = 232;

	public const int KillOtherUiUpdate = 233;

	public const int gameguardData = 234;

	public const int BoneCount = 235;

	public const int GuoQinUiMessage = 236;

	public const int UltKillPlayerInfo = 237;

	public const int PlayerMpInfo = 238;

	public const int Bio3SelectVariant = 239;

	public const int Bio3BioDebris = 240;

	public const int GuoShiWuShuangIcon = 400;

	public const int SceneIrregularitySpecialAreaData = 241;

	public const int LoginDefaultWeapon = 242;

	public const int SimpleWeaponMessage = 401;

	public const int MouseYearShowChooseWeaponUiResponse = 250;

	public const int MouseYearChooseWeaponTypeResponse = 251;

	public const int MouseYearChooseWeaponPushResponse = 252;

	public const int MouseYearCarProgressPush = 253;

	public const int MouseYearPushBuffer = 254;

	public const int MouseYearPowerProgress = 255;

	public const int MouseYearShowBoxChooseWeaponType = 256;

	public const int MouseYearShowBoxRandomWeapon = 257;

	public const int MouseYearShowSkillTreeUiResponse = 258;

	public const int MouseYearWeaponPoolPush = 259;

	public const int RecycleSpray = 259;

	public const int RecycleAccessory = 260;

	public const int RecycleNpc = 261;

	public const int RecycleViewHand = 262;

	public const int AutoVoiceInfo = 263;

	public const int BioPlayerAnger = 264;

	public const int BioPlayerMoral = 265;

	public const int CrazeSkillLearn = 266;

	public const int CrazeSkillChose = 267;

	public const int WeaponPoolPush = 268;

	public const int HeroWeaponData = 269;

	public const int CrazyBigHeadMessage = 270;

	public const int CHECK_GAMEPLUS = 272;

	public const int DestroyBlastMessage = 271;

	public const int BUFF_MESSAGE = 273;

	public const int SKATE_PRESS = 274;

	public const int BLADE_FIGHT = 275;

	public const int STEAL_EXPERT_MATERIAL = 277;

	public const int SKILL_BUFF_MESSAGE = 276;

	public const int SPLIT_SECOND_DATA = 278;

	public const int RANDOM_KING_TIP = 279;

	public const int BOSS_XULI_PROCESS = 280;

	public const int LEIJI_YINJI = 281;

	public const int julong_wing_killinfo = 282;

	public const int RPG_TOWER_SHOW_MAIN = 303;

	public const int RPG_TOWER_LEVEL_UP_TYPE = 304;

	public const int RPG_TOWER_LEVEL_UP_PROPERTY = 305;

	public const int Weapon_List_Load = 331;

	public const int Weapon_Test_Load = 332;

	public const int Room_Event = 333;

	public const int MysteryMessage = 334;

	public const int BroadSwordMessage = 335;

	public const int ProgressInfo = 336;

	public const int mechKingMessage = 337;

	public const int ShowRoleRecipe = 338;

	public const int gunFightMessage = 339;

	public const int NON_STOP_DANCE_MESSAGE = 500;

	public const int BLOCK_DRAGON_PISTOL_MESSAGE = 501;

	public const int dynamicProcess = 340;

	public const int HALO_BUFF_MESSAGE = 341;

	public const int CONSOLE_MESSAGE = 342;

	public const int HU_LAO_GUAN_CAREER = 343;

	public const int newEscapeMessage = 344;

	public const int heroSelectPanelMessage = 345;

	public const int WaitPlayerEnter = 503;

	public const int OutTheZoneCountDown = 504;

	public const int OutTheZoneLoseHp = 505;

	public const int CurModeIndex = 506;

	public const int DerangementValue = 507;

	public const int ACG_BUFF_MESSAGE = 1100;

	public const int ACG_SKILL_TO_CHOOSE = 1101;

	public const int ACG_BUY_INIT_PANEL = 1102;

	public const int ACG_VOTE_MESSAGE = 1103;

	public const int ACG_BOT_DATA = 1104;

	public const int ACG_BENEFIT_PUSH = 1105;

	public const int ACG_MESSAGE = 1106;

	public const int ACG_TASK = 1107;

	public const int AceData = 999;

	public const int HYPERTECH_MESSAGE = 600;

	public const int BRAVEBIEBER_DAMAGE_MESSAGE = 601;

	public const int WEAPON_JOIN_MESSAGE = 602;

	public const int ACE_PUNISH_MESSAGE = 603;

	public const int ULT_CHALLENGE_MESSAGE = 604;

	public const int BUFF_ICON_MESSAGE = 605;

	public const int HOMELAND_INFO_MESSAGE = 606;

	public const int HOMELAND_HISTORY_MESSAGE = 607;

	public const int LIGHT_MAP_ACTION_CHANGE = 610;

	public const int OPEN_CHUANSONG_INIT = 611;

	public const int OPEN_CHUANSONG_UI_OPEN = 612;

	public const int BIO_HUM_CHOSEPANEL = 613;

	public const int BIO_CHOSEPLAYERPANEL = 614;

	public const int CHALLENGE_UI = 620;

	public const int CYBER_RPG_MESSAGE = 701;

	public const int BladeStrongholdNewMessage = 801;

	public const int ProtectBigHeadManMessage = 802;

	public const int BIOZ_INIT = 1108;

	public const int BIOZ_UPDATE_NEW_SKILL = 1109;

	public const int BIOZ_UPDATE_SKILL_PANEL = 1110;

	public const int BIOZ_UPDATE_DIFF_WEAPON_PANEL = 1111;

	public const int BIOZ_SESSION_REPORT = 1112;

	public const int BASE_RUN_UI_INFO = 1113;

	public const int TAN_LAN_READY_UI_ALL = 1200;

	public const int TAN_LAN_READY_UI_WEIGHT = 1201;

	public const int TAN_LAN_READY_UI_ITEM = 1202;

	public const int TAN_LAN_READY_UI_BUFF_LIST = 1203;

	public const int TAN_LAN_SESSION_BATTLE_START = 1204;

	public const int JIN_WU_UI_DATA = 1210;

	public const int JIN_WU_UI_UPDATE = 1211;

	public const int LU_JIN_TI_SHI = 1212;

	public const int HE_JI_TAB_UI = 1213;

	public static List<int> IgnoreTcpList = new List<int> { 203, 124, 213, 242, 31, 259, 260, 261, 262 };
}

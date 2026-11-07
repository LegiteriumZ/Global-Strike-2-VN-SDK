using System;
using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.Mode;

namespace Assets.Sources.Modules.Ui.NewMode;

public class GameUiModeFactory
{
	private readonly Dictionary<int, Type> _dict = new Dictionary<int, Type>();

	public GameUiModeFactory()
	{
		_dict[2] = typeof(ExplodeMode);
		_dict[3] = typeof(GroupMode);
		_dict[4] = typeof(SpecialGroupMode);
		_dict[5] = typeof(PersonalMode);
		_dict[6] = typeof(BiochemicalMode);
		_dict[7] = typeof(HerocraftMode);
		_dict[8] = typeof(RecreationExplodeMode);
		_dict[9] = typeof(KingOfGunMode);
		_dict[10] = typeof(GroupKingOfGunMode);
		_dict[11] = typeof(RecreationGroupMode);
		_dict[12] = typeof(DeathMatchMode);
		_dict[13] = typeof(DeathExplodeMode);
		_dict[14] = typeof(FinalBiochemicalMode);
		_dict[15] = typeof(BladeMode);
		_dict[16] = typeof(SuperBiochemicalMode);
		_dict[17] = typeof(GhostBiochemicalMode);
		_dict[19] = typeof(BigHeadMode);
		_dict[20] = typeof(BioAwakeMode);
		_dict[21] = typeof(HeadkillGroupMode);
		_dict[22] = typeof(Recreation2GroupMode);
		_dict[23] = typeof(GhostExplodeMode);
		_dict[24] = typeof(GroupHeroMode);
		_dict[25] = typeof(PeekabooMode);
		_dict[26] = typeof(BladeStrongholdMode);
		_dict[27] = typeof(ExplodeGoldMode);
		_dict[28] = typeof(BiochemicalTideMode);
		_dict[29] = typeof(MechwarriorMode);
		_dict[30] = typeof(JumpMode);
		_dict[31] = typeof(BiochemicalMechWarriorMode);
		_dict[32] = typeof(GroupRechargeMode);
		_dict[33] = typeof(Biochemical2Mode);
		_dict[34] = typeof(RobChickenMode);
		_dict[35] = typeof(BigHeadKnifeMode);
		_dict[36] = typeof(BigHeadSniperMode);
		_dict[37] = typeof(RobChickenGroupMode);
		_dict[38] = typeof(EscapeMode);
		_dict[39] = typeof(IntelligenceMode);
		_dict[60] = typeof(RocketMode);
		_dict[61] = typeof(ExplodeFairMode);
		_dict[62] = typeof(AnnihilateMode);
		_dict[63] = typeof(UnlimitReliveMode);
		_dict[64] = typeof(WeaponMasterMode);
		_dict[65] = typeof(MadBladeMode);
		_dict[66] = typeof(MadExplodeMode);
		_dict[67] = typeof(MadGroupMode);
		_dict[68] = typeof(MadFinalBiochemicalMode);
		_dict[69] = typeof(MadBiochemicalMode);
		_dict[70] = typeof(ULTIMATE_CHALLENGE_GROUPMode);
		_dict[71] = typeof(ULTIMATE_CHALLENGE_TYPE_1Mode);
		_dict[72] = typeof(ULTIMATE_CHALLENGE_TYPE_2Mode);
		_dict[73] = typeof(EXTREME_WIPE_OUTMode);
		_dict[74] = typeof(FLYING_KNIFEMode);
		_dict[90] = typeof(BigHeadP3Mode);
		_dict[91] = typeof(HighSpeedGroupMode);
		_dict[100] = typeof(FreeMode);
		_dict[101] = typeof(FreeSurviveMode);
		_dict[102] = typeof(FreeSurviveGroupMode);
		_dict[103] = typeof(FreePushcarMode);
		_dict[111] = typeof(FREE_TIT_FOR_TATMode);
		_dict[114] = typeof(MechUnrivaledMode);
		_dict[115] = typeof(VARIATION_MONSTERMode);
		_dict[116] = typeof(ULTIMATE_CHALLENGEMode);
		_dict[117] = typeof(BIOCHEMICAL_3Mode);
		_dict[118] = typeof(FINAL_BIOCHEMICAL_3Mode);
		_dict[119] = typeof(BIOEVOLUTIONMode);
		_dict[120] = typeof(CRAZY_BIG_HEADMode);
		_dict[121] = typeof(BLADE_FIGHTMode);
		_dict[122] = typeof(BIO_EVOLUTION_CHALLENGEMode);
		_dict[123] = typeof(BROAD_SWORDMode);
		_dict[124] = typeof(MECH_KINGMode);
		_dict[125] = typeof(GUN_FIGHTMode);
		_dict[126] = typeof(BIG_HEAD_KNIFE2Mode);
		_dict[127] = typeof(ULTIMATE_CHALLENGE2Mode);
		_dict[128] = typeof(COMPETE_KINGMode);
		_dict[130] = typeof(GOLD_RANKMode);
		_dict[131] = typeof(Knife_FightMode);
		_dict[132] = typeof(NewEscapeModel);
		_dict[133] = typeof(NewEscapeRpgModel);
		_dict[134] = typeof(BIOCHEMICAL_ZMode);
		_dict[135] = typeof(HomeLandModel);
		_dict[140] = typeof(BladeStrongholdNewMode);
		_dict[141] = typeof(ProtectBigHeadMode);
		_dict[145] = typeof(BioUnionBaseMode);
		_dict[146] = typeof(BioUnionBaseMode);
		_dict[147] = typeof(BioUnionBaseMode);
		_dict[160] = typeof(ALL_ROUND_SINGLESMode);
		_dict[1001] = typeof(TdMode);
		_dict[1002] = typeof(TitanLaboratoryMode);
		_dict[1003] = typeof(DieStrikeMode);
		_dict[1004] = typeof(LostTempleMode);
		_dict[1005] = typeof(LostGraveMode);
		_dict[1100] = typeof(CRAZE_RPGMode);
		_dict[2002] = typeof(TEST_WEAPON_UNITYMode);
		_dict[2003] = typeof(BotGroupMode);
		_dict[2019] = typeof(BotBigHeadMode);
		_dict[2041] = typeof(BotKnifeMode);
		_dict[10000] = typeof(GeneralPve00Mode);
		_dict[10001] = typeof(GeneralPve01Mode);
		_dict[10002] = typeof(GeneralPve02Mode);
		_dict[10003] = typeof(GeneralPve03Mode);
		_dict[10004] = typeof(GeneralPve04Mode);
		_dict[10005] = typeof(GeneralPve05Mode);
		_dict[10006] = typeof(GeneralPve06Mode);
		_dict[10007] = typeof(GeneralPve07Mode);
		_dict[10008] = typeof(GeneralPve08Mode);
		_dict[10009] = typeof(GeneralPve09Mode);
		_dict[10010] = typeof(GeneralPve10Mode);
		_dict[10011] = typeof(GeneralPve11Mode);
		_dict[10012] = typeof(GeneralPve12Mode);
		_dict[10013] = typeof(GeneralPve13Mode);
		_dict[10014] = typeof(GeneralPve14Mode);
		_dict[10015] = typeof(GeneralPve15Mode);
		_dict[10016] = typeof(GeneralPve16Mode);
		_dict[10017] = typeof(GeneralPve17Mode);
		_dict[10018] = typeof(GeneralPve18Mode);
		_dict[10019] = typeof(GeneralPve19Mode);
		_dict[10020] = typeof(GeneralPve20Mode);
		_dict[10021] = typeof(GeneralPve21Mode);
		_dict[10022] = typeof(GeneralPve22Mode);
		_dict[10023] = typeof(GeneralPve23Mode);
		_dict[10024] = typeof(GeneralPve24Mode);
		_dict[10025] = typeof(GeneralPve25Mode);
		_dict[10026] = typeof(GeneralPve26Mode);
		_dict[10027] = typeof(GeneralPve27Mode);
		_dict[10028] = typeof(GeneralPve28Mode);
		_dict[10029] = typeof(GeneralPve29Mode);
		_dict[10030] = typeof(GeneralPve30Mode);
		_dict[10031] = typeof(GeneralPve31Mode);
		_dict[10032] = typeof(GeneralPve32Mode);
		_dict[10033] = typeof(GeneralPve33Mode);
		_dict[10034] = typeof(GeneralPve34Mode);
		_dict[10035] = typeof(GeneralPve35Mode);
		_dict[10036] = typeof(GeneralPve36Mode);
		_dict[10037] = typeof(GeneralPve37Mode);
		_dict[10038] = typeof(GeneralPve38Mode);
		_dict[10039] = typeof(GeneralPve39Mode);
		_dict[10040] = typeof(GeneralPve40Mode);
		_dict[10041] = typeof(GeneralPve41Mode);
		_dict[10042] = typeof(GeneralPve42Mode);
		_dict[10043] = typeof(GeneralPve43Mode);
		_dict[10044] = typeof(GeneralPve44Mode);
		_dict[10045] = typeof(GeneralPve45Mode);
		_dict[10046] = typeof(GeneralPve46Mode);
		_dict[10047] = typeof(GeneralPve47Mode);
		_dict[10048] = typeof(GeneralPve48Mode);
		_dict[10049] = typeof(GeneralPve49Mode);
		_dict[10050] = typeof(GeneralPve50Mode);
		_dict[10051] = typeof(GeneralPve51Mode);
		_dict[10052] = typeof(GeneralPve52Mode);
		_dict[10053] = typeof(GeneralPve53Mode);
		_dict[10054] = typeof(GeneralPve54Mode);
		_dict[10055] = typeof(GeneralPve55Mode);
		_dict[10056] = typeof(GeneralPve56Mode);
		_dict[10057] = typeof(GeneralPve57Mode);
		_dict[10058] = typeof(GeneralPve58Mode);
		_dict[10059] = typeof(GeneralPve59Mode);
		_dict[10060] = typeof(GeneralPve60Mode);
		_dict[11000] = typeof(GeneralPve1000Mode);
		_dict[11001] = typeof(GeneralPve1001Mode);
		_dict[11002] = typeof(GeneralPve1002Mode);
		_dict[11003] = typeof(GeneralPve1003Mode);
		_dict[11004] = typeof(GeneralPve1004Mode);
		_dict[11005] = typeof(GeneralPve1005Mode);
		_dict[12000] = typeof(GeneralPve2000Mode);
		_dict[12001] = typeof(GeneralPve2001Mode);
		_dict[12002] = typeof(GeneralPve2002Mode);
		_dict[12003] = typeof(GeneralPve2003Mode);
		_dict[12004] = typeof(GeneralPve2004Mode);
		_dict[12005] = typeof(GeneralPve2005Mode);
		_dict[12006] = typeof(GeneralPve2006Mode);
		_dict[12007] = typeof(GeneralPve2007Mode);
		_dict[12008] = typeof(GeneralPve2008Mode);
		_dict[12009] = typeof(GeneralPve2009Mode);
		_dict[13000] = typeof(GeneralPve3000Mode);
		_dict[13001] = typeof(GeneralPve3001Mode);
		_dict[13002] = typeof(GeneralPve3002Mode);
		_dict[13003] = typeof(GeneralPve3003Mode);
		_dict[13004] = typeof(GeneralPve3004Mode);
		_dict[13005] = typeof(GeneralPve3005Mode);
		_dict[14000] = typeof(GeneralPve4000Mode);
		_dict[14001] = typeof(GeneralPve4001Mode);
		_dict[14002] = typeof(GeneralPve4002Mode);
		_dict[14003] = typeof(GeneralPve4003Mode);
		_dict[14004] = typeof(GeneralPve4004Mode);
		_dict[14005] = typeof(GeneralPve4005Mode);
		_dict[14006] = typeof(GeneralPve4006Mode);
		_dict[14007] = typeof(GeneralPve4007Mode);
		_dict[14500] = typeof(GeneralPve4500Mode);
		_dict[14501] = typeof(GeneralPve4501Mode);
		_dict[14502] = typeof(GeneralPve4502Mode);
		_dict[14503] = typeof(GeneralPve4503Mode);
		_dict[14504] = typeof(GeneralPve4504Mode);
		_dict[14505] = typeof(GeneralPve4505Mode);
		_dict[14506] = typeof(GeneralPve4506Mode);
		_dict[15000] = typeof(RpgGroupMode);
		_dict[15001] = typeof(RpgSurviveMode);
		_dict[15002] = typeof(RpgMinerMode);
		_dict[15003] = typeof(RpgKillImmortalMode);
		_dict[15004] = typeof(RpgKillGodMode);
		_dict[15005] = typeof(RpgKillOtherMode);
		_dict[15006] = typeof(RpgSurvivalPvpMode);
		_dict[15007] = typeof(RpgGroupAnnihilationMode);
		_dict[15008] = typeof(RpgLootMode);
		_dict[15009] = typeof(RpgLootMineMode);
		_dict[15010] = typeof(RpgStealExpertMode);
		_dict[15011] = typeof(RpgSlitSecondMode);
		_dict[15012] = typeof(RPG_DUELMode);
		_dict[15013] = typeof(RPG_ARMAMENTMode);
		_dict[15014] = typeof(RPG_DUEL_DIANFENGMode);
		_dict[16000] = typeof(GeneralPve6000Mode);
		_dict[16005] = typeof(Rpg_6005Mode);
		_dict[17000] = typeof(RpgMysteryMode);
		_dict[17002] = typeof(RpgMarbleStormMode);
		_dict[17003] = typeof(RpgNinjiaMarkMode);
		_dict[17500] = typeof(RpgAbyssMode);
		_dict[18000] = typeof(RpgKingTreasuryMode);
		_dict[18001] = typeof(GoldPigMode);
		_dict[18002] = typeof(RpgTeamRaceMode);
		_dict[18006] = typeof(MouseNewYearMode);
		_dict[18009] = typeof(RPG_GUO_QIN_RACEMode);
		_dict[18010] = typeof(RpgPersonalGroupMode);
		_dict[18011] = typeof(RpgPersonalMineMode);
		_dict[18014] = typeof(RPG_EXPLODE_WDMode);
		_dict[18015] = typeof(OxNewYearMode);
		_dict[18017] = typeof(RPG_DANREN_MINEMode);
		_dict[18018] = typeof(RPG_HOLIDAYMode);
		_dict[18020] = typeof(HuLaoGuanNewYearMode);
		_dict[18023] = typeof(HeroFightingMode);
		_dict[18030] = typeof(Rpg2022NewYeadMode);
		_dict[18031] = typeof(Rpg2022NewYeadMode);
		_dict[18106] = typeof(MouseNewYearSmallMode);
		_dict[18501] = typeof(RPG_TEAM_RACE_18501Mode);
		_dict[18502] = typeof(RPG_TEAM_RACE_18502Mode);
		_dict[18503] = typeof(RPG_TEAM_RACE_18503Mode);
		_dict[19000] = typeof(AcgMode);
		_dict[19999] = typeof(GeneralPve9999Mode);
		_dict[20000] = typeof(RpglastdefenderMode);
		_dict[110001] = typeof(ZHOUNIANQINGMode);
		_dict[110002] = typeof(GUOZHANMode);
		_dict[110003] = typeof(GUOZHAN2Mode);
		_dict[110004] = typeof(GUOZHAN2_1Mode);
		_dict[110005] = typeof(GUOZHAN2_2Mode);
		_dict[110006] = typeof(GUOZHAN2_3Mode);
		_dict[110007] = typeof(GUOZHAN2_4Mode);
		_dict[110008] = typeof(GUOZHAN2_5Mode);
		_dict[110009] = typeof(GUOZHAN2_6Mode);
		_dict[110010] = typeof(GUOZHAN2_7Mode);
		_dict[110011] = typeof(GUOZHAN2_8Mode);
		_dict[110012] = typeof(GUOZHAN2_9Mode);
		_dict[111001] = typeof(RPG_TOWER_1Mode);
		_dict[111002] = typeof(RPG_TOWER_2Mode);
		_dict[111003] = typeof(RPG_TOWER_3Mode);
		_dict[111004] = typeof(RPG_TOWER_4Mode);
		_dict[111005] = typeof(RPG_TOWER_5Mode);
		_dict[111006] = typeof(RPG_TOWER_6Mode);
		_dict[111007] = typeof(RPG_TOWER_7Mode);
		_dict[111008] = typeof(RPG_TOWER_8Mode);
		_dict[111009] = typeof(RPG_TOWER_9Mode);
		_dict[111999] = typeof(RPG_TOWER_MAXMode);
		_dict[150000] = typeof(RPG_SPEED_MINMode);
		_dict[154999] = typeof(RPG_SPEED_MAXMode);
		_dict[155000] = typeof(RPG_ATTACK_TRAINING_MINMode);
		_dict[155099] = typeof(RPG_ATTACK_TRAINING_MAXMode);
		_dict[155100] = typeof(RPG_DEFENSE_TRAINING_MINMode);
		_dict[155199] = typeof(RPG_DEFENSE_TRAINING_MAXMode);
		_dict[200000] = typeof(Acg_WarMode);
		_dict[121003] = typeof(RpgTreasureBossMode);
		_dict[999999999] = typeof(TestWeaponMode);
	}

	public BaseUiMode CreateUiMode(int mode, Contexts contexts)
	{
		if (_dict.TryGetValue(mode, out var value))
		{
			return Activator.CreateInstance(value, contexts) as BaseUiMode;
		}
		return TryCreateDefaultMode(mode, contexts);
	}

	private BaseUiMode TryCreateDefaultMode(int mode, Contexts contexts)
	{
		if (mode == 18000)
		{
			return new RpgKingTreasuryMode(contexts);
		}
		if (RuleUtilty.IsRpgTower(mode))
		{
			return new RPG_TOWER_9Mode(contexts);
		}
		if (RuleUtilty.IsBaseRun(mode))
		{
			return new RpgBaseRunModel(contexts);
		}
		if (RuleUtilty.IsTanLanRun(mode))
		{
			return new RpgTanlanModel(contexts);
		}
		if (RuleUtilty.IsTanLanBoss(mode))
		{
			return new RpgTanlanBossModel(contexts);
		}
		if (RuleUtilty.IsTanLanZhanShu(mode))
		{
			return new RpgTanlanZhanshuModel(contexts);
		}
		if (RuleUtilty.IsStarWalker(mode))
		{
			return new RpgStarWalkerModel(contexts);
		}
		if (RuleUtilty.IsRpgNormal(mode))
		{
			return new GeneralPve00Mode(contexts);
		}
		if (RuleUtilty.IsRpgJy(mode))
		{
			return new GeneralPve1000Mode(contexts);
		}
		if (RuleUtilty.IsRpgShiLian(mode))
		{
			return new GeneralPve2000Mode(contexts);
		}
		if (RuleUtilty.IsRpgWuJin(mode))
		{
			return new GeneralPve4000Mode(contexts);
		}
		if (RuleUtilty.IsRpgPvp(mode))
		{
			return new RpgGroupMode(contexts);
		}
		if (RuleUtilty.IsRpgJueXing(mode))
		{
			return new GeneralPve3000Mode(contexts);
		}
		if (RuleUtilty.IsMultipleRpg(mode))
		{
			return new GeneralPve6000Mode(contexts);
		}
		if (RuleUtilty.IsRpgMystery(mode))
		{
			return new RpgMysteryMode(contexts);
		}
		if (RuleUtilty.IsRpgAbyss(mode))
		{
			return new RpgAbyssMode(contexts);
		}
		if (RuleUtilty.isCyberSpace(mode))
		{
			return new CyberSpaceModel(contexts);
		}
		if (RuleUtilty.isHuntTre(mode))
		{
			return new GuoFengGuMuModel(contexts);
		}
		if (RuleUtilty.IsRpg(mode))
		{
			return new CommonRpgMode(contexts);
		}
		return new DefaultMode(contexts);
	}
}

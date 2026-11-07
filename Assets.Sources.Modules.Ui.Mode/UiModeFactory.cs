using Assets.Sources.Constant;

namespace Assets.Sources.Modules.Ui.Mode;

public class UiModeFactory
{
	public AbstractMode CreateUiMode(int mode, Contexts contexts, UiResourcesLoader loader)
	{
		switch (mode)
		{
		case 128:
			return new CompeteKingMode(contexts);
		case 130:
			return new GoldRankMode(contexts);
		case 131:
			return new KnifeFightMode(contexts);
		case 125:
			return new GunFightMode(contexts);
		case 18018:
			return new RpgHolidayMode(contexts);
		case 15012:
		case 15014:
			return new RpgDuelMode(contexts);
		case 15011:
			return new RpgSplitSecondMode(contexts);
		case 15010:
			return new RpgStealExpertMode(contexts);
		case 15013:
			return new RpgArmamentMode(contexts);
		case 15009:
			return new RpgMineLootMode(contexts);
		case 15008:
			return new RpgLootMode(contexts);
		case 110001:
			return new RpgZhouNianQingMode(contexts);
		case 110003:
			return new RpgZhouNianQingMode(contexts);
		case 110004:
			return new RpgZhouNianQingMode(contexts);
		case 110005:
			return new RpgZhouNianQingMode(contexts);
		case 110006:
			return new RpgZhouNianQingMode(contexts);
		case 110007:
			return new RpgZhouNianQingMode(contexts);
		case 110008:
			return new RpgZhouNianQingMode(contexts);
		case 110009:
			return new RpgZhouNianQingMode(contexts);
		case 110010:
			return new RpgZhouNianQingMode(contexts);
		case 110011:
			return new RpgZhouNianQingMode(contexts);
		case 110012:
			return new RpgZhouNianQingMode(contexts);
		case 110002:
			return new RpgGuoZhanMode(contexts);
		case 18009:
			return new RpgGuoQingRaceMode(contexts);
		case 15007:
			return new RpgGroupAnnihilationMode(contexts);
		case 1100:
			return new CrazeRpgModeMode(contexts);
		case 3:
		case 4:
		case 21:
		case 24:
		case 32:
		case 67:
		case 74:
		case 2003:
			return new NormalTeamMode(contexts);
		case 70:
		case 71:
		case 72:
		case 116:
			return new UltimateChallengeMode(contexts);
		case 127:
			return new UltimateChallenge2Mode(contexts);
		case 73:
			return new UIExtremeWipeOutMode(contexts);
		case 111:
		case 115:
			return new CommonFreeMode(contexts);
		case 100:
			return new CommonFreeMode(contexts);
		case 2:
		case 66:
			return new ExplodeMode(contexts);
		case 19:
		case 35:
		case 36:
		case 90:
		case 126:
		case 2019:
			return new BigHeadMode(contexts);
		case 141:
			return new ProtectBigHeadMode(contexts);
		case 120:
			return new CrazyBigHeadMode(contexts);
		case 8:
		case 13:
		case 23:
			return new ExplodeDefaultMode(contexts);
		case 61:
			return new ExplodeFairMode(contexts);
		case 27:
			return new GoldExplodeMode(contexts);
		case 6:
		case 69:
			return new BiochemicalMode(contexts);
		case 117:
			return new Biochemical3Mode(contexts);
		case 14:
		case 68:
			return new FinalBiochemicalMode(contexts);
		case 118:
			return new FinalBiochemical3Mode(contexts);
		case 119:
		case 122:
			return new BioEvolutionMode(contexts);
		case 5:
			return new PersonalMode(contexts);
		case 15000:
		case 18010:
		case 18011:
			return new RpgGroupMode(contexts);
		case 12:
		case 63:
			return new DeathMatchMode(contexts);
		case 64:
			return new WeaponMasterMode(contexts);
		case 9:
			return new GunKingMode(contexts);
		case 10:
			return new GroupGunKingMode(contexts);
		case 15002:
			return new RpgMinerMode(contexts);
		case 123:
			return new BroadSwordMode(contexts);
		case 15:
		case 65:
			return new BladeMode(contexts);
		case 121:
			return new BladeFightMode(contexts);
		case 16:
			return new SuperBiochemicalMode(contexts);
		case 29:
			return new MechwarriorMode(contexts);
		case 124:
			return new MechKingMode(contexts);
		case 33:
			return new Biochemical2Mode(contexts);
		case 15005:
			return new RpgKillOtherMode(contexts);
		case 15006:
			return new RpgSurvivalPvpMode(contexts);
		case 18002:
		case 18501:
		case 18502:
			return new RpgTeamRaceMode(contexts);
		case 18503:
			return new RpgTeamRaceFinalMode(contexts);
		case 15004:
			return new RpgKillGodMode(contexts);
		case 1005:
			return new LostGraveMode(contexts);
		case 1004:
			return new LostTempleMode(contexts);
		case 1001:
			return new TDMode(contexts);
		case 1002:
			return new TitanLaboratoryMode(contexts);
		case 1003:
			return new DieStrikeMode(contexts);
		case 20000:
			return new RpgLastDefenderMode(contexts);
		case 30:
			return new JumpMode(contexts);
		case 18014:
			return new RpgExplodeWdMode(contexts);
		default:
			if (RuleUtilty.IsTpsAcgMode(mode))
			{
				return new AcgMode(contexts);
			}
			if (RuleUtilty.IsMultipleRpg(mode))
			{
				return new RpgRescueMode(contexts);
			}
			if (RuleUtilty.IsRpgTower(mode))
			{
				return new RpgTowerMode(contexts);
			}
			if (RuleUtilty.IsRpgSpeedMode(mode))
			{
				return new RpgSpecailSpeedMode(contexts);
			}
			if (RuleUtilty.IsRpg(mode))
			{
				return new RpgMode(contexts);
			}
			return new DefaultMode(contexts);
		}
	}
}

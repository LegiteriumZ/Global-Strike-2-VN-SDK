using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Config;
using NetData;
using SSJJBase.SimpleJson;

namespace Assets.Sources.Constant;

public class RuleUtilty
{
	private static bool _isUltimate;

	private static bool _isAvatarUltimate;

	private static bool _isAvatarUltimateWipeOut;

	private static int _reportState = -1;

	public static bool IsTpsMode()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (IsAcgWar(raceType))
		{
			return true;
		}
		if (IsTpsAcgMode(raceType))
		{
			return true;
		}
		return false;
	}

	public static bool IsAcgWar(int rule)
	{
		return rule == 200000;
	}

	public static bool IsBaseRun(int raceType)
	{
		if (raceType >= 122101 && raceType <= 123100)
		{
			return true;
		}
		return false;
	}

	public static bool IsTpsAcgMode(int rule)
	{
		if (rule != 19000)
		{
			return rule == 200000;
		}
		return true;
	}

	public static bool IsRpgSpecailMode(int rule)
	{
		switch (rule)
		{
		case 15009:
		case 110001:
		case 110002:
		case 110003:
		case 110004:
		case 110005:
		case 110006:
		case 110007:
		case 110008:
		case 110009:
		case 110010:
		case 110011:
		case 110012:
			return true;
		default:
			return false;
		}
	}

	public static bool IsRpgTower(int raceType)
	{
		if (raceType >= 111001 && raceType <= 111999)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgTreasureBoss(int raceType)
	{
		if (raceType == 121003)
		{
			return true;
		}
		return false;
	}

	public static void InitUltimateChallenge()
	{
		int raceType = GetRaceType();
		string freeType = GetFreeType();
		if (raceType == 116)
		{
			_isUltimate = true;
		}
		if (freeType == "UltimateChallenge")
		{
			_isUltimate = true;
		}
		if (raceType == 70)
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
		if (raceType == 71)
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
		if (raceType == 72)
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
		if (raceType == 73)
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
		if (freeType == "UltimateChallengeGroup")
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
		if (raceType == 73)
		{
			_isAvatarUltimateWipeOut = true;
		}
		if (raceType == 127)
		{
			_isUltimate = (_isAvatarUltimate = true);
		}
	}

	public static bool IsUltimateChallenge()
	{
		return _isUltimate;
	}

	public static bool IsAvatarUltimateChallenge()
	{
		return _isAvatarUltimate;
	}

	public static bool IsAvatarUltimateWipeOut()
	{
		return _isAvatarUltimateWipeOut;
	}

	public static bool IsFreeSurvive()
	{
		string freeType = GetFreeType();
		if (freeType == "survive" || freeType == "surviveGroup")
		{
			return true;
		}
		return false;
	}

	public static bool CanPress(int state)
	{
		return false;
	}

	public static bool SupportUnloadThirdRes()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom != null && battleRoom.roomData != null && battleRoom.roomData.Data != null)
		{
			int raceType = battleRoom.roomData.Data.RaceType;
			if (IsBigHeadModel(raceType))
			{
				return true;
			}
			if (IsBioMode(raceType))
			{
				return true;
			}
			if (IsExplode(raceType))
			{
				return true;
			}
			if (IsGroupModel(raceType))
			{
				return true;
			}
			if (IsRpg(raceType))
			{
				return true;
			}
			if (IsPve(raceType))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsNotMoveRule(int rule)
	{
		if (IsExplode(rule) || IsDeathRule(rule) || rule == 29 || rule == 39 || rule == 62 || rule == 64)
		{
			return true;
		}
		return false;
	}

	public static bool IsUnityScene(int sceneId)
	{
		return sceneId == 3400;
	}

	public static bool EnableAvater()
	{
		RoomDataComponent roomData = Contexts.sharedInstance.battleRoom.roomData;
		if (roomData.Data != null && IsUnityScene(roomData.Data.SceneId) && GameController.Instance != null && GameController.Instance.OpenAvater)
		{
			return IsAvatarUltimateChallenge();
		}
		return false;
	}

	public static bool IsLadderTT()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		int subRaceType = Contexts.sharedInstance.battleRoom.roomData.Data.SubRaceType;
		if (raceType == 5 && subRaceType == 51)
		{
			return true;
		}
		if (raceType == 4 && subRaceType == 41)
		{
			return true;
		}
		if (raceType == 100 && Contexts.sharedInstance.battleRoom.roomData.Data.FreeType == "gunKingGroup")
		{
			return true;
		}
		if (raceType == 114 && subRaceType == 1)
		{
			return true;
		}
		return false;
	}

	public static string GetFreeType()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom != null && battleRoom.hasRoomData && battleRoom.roomData.Data != null)
		{
			return Contexts.sharedInstance.battleRoom.roomData.Data.FreeType;
		}
		return "";
	}

	public static int GetRaceType()
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom != null && battleRoom.hasRoomData && battleRoom.roomData.Data != null)
		{
			return Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		}
		return 0;
	}

	public static bool IsRpg(int rule)
	{
		if (rule != 2002 && (rule < 10000 || rule > 20000) && !IsRpgTower(rule) && !IsRpgSpeedMode(rule) && !IsTpsAcgMode(rule) && rule != 18023 && (rule < 121000 || rule > 122000) && rule != 135 && !isCyberSpace(rule) && !IsBaseRun(rule) && !IsTanLanRun(rule) && !IsTanLanBoss(rule) && !IsTanLanZhanShu(rule))
		{
			return IsStarWalker(rule);
		}
		return true;
	}

	public static bool IsRpgLastDefender(int rule)
	{
		return rule == 20000;
	}

	public static bool IsNeedSelectNodeRule(int rule)
	{
		return rule == 20000;
	}

	public static bool IsGroupModel(int rule)
	{
		if (rule == 3 || rule == 12 || rule == 62 || rule == 11 || rule == 32 || rule == 21 || rule == 22 || rule == 24 || rule == 2003 || rule == 141)
		{
			return true;
		}
		return false;
	}

	public static bool IsOldPve(int rule)
	{
		if (1001 == rule || 1002 == rule || 1003 == rule || 1004 == rule || 1005 == rule || 1100 == rule)
		{
			return true;
		}
		return false;
	}

	public static int GetConfigRule(int raceType)
	{
		if (IsRpgSpeedMode(raceType))
		{
			return 150000;
		}
		if (IsDimensionalFissure(raceType))
		{
			return 300000;
		}
		if (isHuntTre(raceType))
		{
			return 121100;
		}
		if (IsBaseRun(raceType))
		{
			return 122101;
		}
		if (IsTanLanRun(raceType))
		{
			return 123101;
		}
		if (IsTanLanZhanShu(raceType))
		{
			return 125001;
		}
		if (IsStarWalker(raceType))
		{
			return 126000;
		}
		return raceType;
	}

	public static bool IsDimensionalFissure(int raceType)
	{
		if (raceType >= 300000)
		{
			return raceType <= 399998;
		}
		return false;
	}

	public static bool IsRpgSpeedMode(int raceType)
	{
		if (IsAttackTrainingMode(raceType))
		{
			return true;
		}
		if (IsDefenseTrainingMode(raceType))
		{
			return true;
		}
		if (raceType >= 150000)
		{
			return raceType <= 154999;
		}
		return false;
	}

	public static bool IsAttackTrainingMode(int raceType)
	{
		if (raceType >= 155000)
		{
			return raceType <= 155099;
		}
		return false;
	}

	public static bool IsDefenseTrainingMode(int raceType)
	{
		if (raceType >= 155100)
		{
			return raceType <= 155199;
		}
		return false;
	}

	public static bool IsPve(int rule)
	{
		if (IsOldPve(rule) || IsGeneralPve(rule) || isCyberSpace(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgAbyss(int rule)
	{
		if (rule >= 17500 && rule <= 17999)
		{
			return true;
		}
		return false;
	}

	public static bool IsGeneralPve(int rule)
	{
		if (IsCopyActivity(rule) || IsRpgNormal(rule) || IsRpgJy(rule) || IsRpgShiLian(rule) || IsRpgJueXing(rule) || IsRpgWuJin(rule) || IsRpgPvp(rule) || IsKingTreasury(rule) || IsRpgSurvive(rule) || IsMultipleRpg(rule) || rule == 17000 || IsRpgAbyss(rule) || IsRpgSpeedMode(rule) || IsRpgMystery(rule) || IsRpgLastDefender(rule) || IsJuedouchang(rule) || IsRpgTower(rule) || rule == 18017 || rule == 133 || IsDimensionalFissure(rule) || isCyberSpace(rule) || rule == 19001 || isHuntTre(rule) || IsTanLanRun(rule) || IsTanLanBoss(rule) || IsTanLanZhanShu(rule) || IsStarWalker(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsJuedouchang(int rule)
	{
		if (rule >= 18901 && rule <= 18999)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgPve(int rule)
	{
		if (IsRpgNormal(rule) || IsRpgJy(rule) || IsRpgShiLian(rule) || IsRpgJueXing(rule) || IsRpgWuJin(rule) || IsKingTreasury(rule) || IsRpgSurvive(rule) || IsMultipleRpg(rule) || rule == 17000 || IsRpgAbyss(rule) || IsRpgMystery(rule) || IsRpgLastDefender(rule) || IsJuedouchang(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgMystery(int rule)
	{
		if (rule >= 17000 && rule < 17500)
		{
			return true;
		}
		return false;
	}

	public static bool IsKillOther(int rule)
	{
		if (rule == 15005)
		{
			return true;
		}
		return false;
	}

	public static bool IsKingTreasury(int rule)
	{
		if (rule >= 18000 && rule < 18500)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgSurvive(int raceType)
	{
		if (raceType == 15001)
		{
			return true;
		}
		return false;
	}

	public static bool IsSurvivalPvp(int rule)
	{
		if (rule == 15006)
		{
			return true;
		}
		return false;
	}

	public static bool IsTanLanBoss(int raceType)
	{
		return raceType switch
		{
			124101 => true, 
			124102 => true, 
			124103 => true, 
			_ => false, 
		};
	}

	public static bool IsTanLanZhanShu(int raceType)
	{
		if (raceType >= 125001 && raceType <= 125999)
		{
			return true;
		}
		return false;
	}

	public static bool IsTanLanRun(int raceType)
	{
		if (raceType >= 123101 && raceType <= 124100)
		{
			return true;
		}
		return false;
	}

	public static bool IsStarWalker(int raceType)
	{
		if (raceType >= 126000 && raceType <= 126999)
		{
			return true;
		}
		return false;
	}

	public static bool IsBioUnion(int rule)
	{
		if (rule == 146 || rule == 145 || rule == 147)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgPvp(int rule)
	{
		if (IsRpgGroup(rule) || rule == 15002 || rule == 15004 || rule == 15008 || rule == 15011 || rule == 15009 || rule == 15005 || IsSurvivalPvp(rule) || rule == 18002 || rule == 15010 || rule == 15012 || rule == 15014 || rule == 15013 || IsTeamRace(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgGroup(int rule)
	{
		if (rule == 15000 || rule == 18010 || rule == 18011 || rule == 15007)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgNormal(int rule)
	{
		if (rule >= 10000 && rule < 11000)
		{
			return true;
		}
		if (rule >= 121000 && rule < 121100)
		{
			return true;
		}
		if (IsBaseRun(rule))
		{
			return true;
		}
		return false;
	}

	public static bool isGPUAnimScreen()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (raceType >= 10000 && raceType < 11000)
		{
			return true;
		}
		return false;
	}

	public static bool IsMechwarrior2(string freeType)
	{
		if (freeType.Equals("mechWarrior2"))
		{
			return true;
		}
		return false;
	}

	public static bool IsHowToPlayerShow(int raceType, string freeType)
	{
		if (IsMechwarrior2(freeType))
		{
			return true;
		}
		return false;
	}

	public static bool IsVoiceShowAndNoTeamDiff(int rule)
	{
		if (IsGeneralPve(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgJy(int rule)
	{
		if (rule >= 11000 && rule < 12000)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgShiLian(int rule)
	{
		if (rule >= 12000 && rule < 13000)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgWuJin(int rule)
	{
		if (rule >= 14000 && rule < 15000)
		{
			return true;
		}
		return false;
	}

	public static bool IsNewRpgPvp(int rule)
	{
		if (rule >= 15008 && rule < 15100)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgJueXing(int rule)
	{
		if (rule >= 13000 && rule < 14000)
		{
			return true;
		}
		return false;
	}

	public static bool IsTurnBasedModel(int rule)
	{
		if (IsBioMode(rule))
		{
			return true;
		}
		if (IsExplode(rule))
		{
			return true;
		}
		if (IsDeathRule(rule))
		{
			return true;
		}
		if (IsBigHeadModel(rule))
		{
			return true;
		}
		if (22 == rule)
		{
			return true;
		}
		if (24 == rule)
		{
			return true;
		}
		if (25 == rule)
		{
			return true;
		}
		if (29 == rule)
		{
			return true;
		}
		if (IsJuedouchang(rule))
		{
			return true;
		}
		return false;
	}

	public static int GetSuperModel(int rule)
	{
		if (IsBioMode(rule))
		{
			return 6;
		}
		if (IsExplode(rule))
		{
			return 2;
		}
		if (IsBlade(rule))
		{
			return 15;
		}
		if (IsDeathRule(rule))
		{
			return 12;
		}
		if (IsRecreationMode(rule))
		{
			return 11;
		}
		if (IsBigHeadModel(rule))
		{
			return 19;
		}
		if (IsChickenMode(rule))
		{
			return 37;
		}
		if (IsRocketMode(rule))
		{
			return 60;
		}
		return rule;
	}

	public static bool IsRocketMode(int rule)
	{
		if (rule == 60)
		{
			return true;
		}
		return false;
	}

	public static bool IsKnife(int rule)
	{
		if (35 == rule || 126 == rule || 2041 == rule || 26 == rule || 15 == rule || 65 == rule || 123 == rule)
		{
			return true;
		}
		return false;
	}

	public static bool IsBigHeadModel(int rule)
	{
		if (19 == rule || 90 == rule || 35 == rule || 36 == rule || 2019 == rule || 120 == rule || rule == 126 || IsBioUnion(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsNeedSkillSmallIcon(int rule)
	{
		if (rule == 1003 || rule == 1002 || rule == 1005 || rule == 1004 || rule == 1001 || rule == 24)
		{
			return true;
		}
		return false;
	}

	public static bool IsRecreationMode(int rule)
	{
		if (rule == 11 || rule == 22 || rule == 24)
		{
			return true;
		}
		return false;
	}

	public static bool IsKnife(int rule, int subRule)
	{
		if (rule == 26 || rule == 35 || rule == 126 || rule == 123 || rule == 15 || (rule == 4 && subRule == 41) || (rule == 5 && subRule == 52))
		{
			return true;
		}
		return false;
	}

	public static bool IsKnifeRule(int rule, int subRule)
	{
		if (rule == 26 || rule == 35 || rule == 15 || (rule == 4 && subRule == 41) || (rule == 5 && subRule == 52))
		{
			return true;
		}
		return false;
	}

	public static bool IsBlade(int rule)
	{
		if (15 == rule || 123 == rule || 26 == rule || 65 == rule || rule == 121)
		{
			return true;
		}
		return false;
	}

	public static bool IsCompetitive(int rule, int subRule)
	{
		if (IsGroupModel(rule) || IsExplode(rule) || IsBioMode(rule) || IsBigHeadModel(rule) || 5 == rule || 4 == rule || IsKnifeRule(rule, subRule) || IsBlade(rule) || IsBotMode(rule) || 29 == rule || 114 == rule || isMechKingMode(rule) || 125 == rule || 130 == rule || 9 == rule || 25 == rule || 60 == rule || 30 == rule || 101 == rule || 102 == rule)
		{
			return true;
		}
		return false;
	}

	public static bool IsBioEvoLutionMode(int rule)
	{
		if (rule == 119 || rule == 122)
		{
			return true;
		}
		return false;
	}

	public static bool IsBattleRoyaleMode(int rule)
	{
		if (rule == 132 || rule == 133)
		{
			return true;
		}
		return false;
	}

	public static bool IsBio3Mode(int rule)
	{
		if (rule == 117 || rule == 118)
		{
			return true;
		}
		return false;
	}

	public static bool IsBioMode(int rule)
	{
		if (rule == 6 || rule == 33 || rule == 7 || rule == 14 || rule == 16 || rule == 17 || rule == 20 || rule == 28 || rule == 31 || 38 == rule || rule == 69 || rule == 68 || rule == 117 || rule == 118 || rule == 119 || rule == 122 || rule == 133 || rule == 132 || rule == 134)
		{
			return true;
		}
		return false;
	}

	public static bool isMechKingMode(int rule)
	{
		if (rule == 124)
		{
			return true;
		}
		return false;
	}

	public static bool IsChickenMode(int rule)
	{
		if (37 == rule || 34 == rule)
		{
			return true;
		}
		return false;
	}

	public static bool IsBotMode(int rule)
	{
		if (rule == 2003 || rule == 2019 || rule == 2041)
		{
			return true;
		}
		return false;
	}

	public static bool IsExplode(int rule)
	{
		if (rule == 2 || rule == 8 || rule == 13 || rule == 23 || rule == 27 || rule == 61 || rule == 66)
		{
			return true;
		}
		return false;
	}

	public static bool isRpgDuelDianfeng(int rule)
	{
		if (rule == 15014)
		{
			return true;
		}
		return false;
	}

	public static bool IsDeathRule(int rule)
	{
		if (IsBlade(rule))
		{
			return true;
		}
		if (rule == 12 || rule == 13 || rule == 23 || rule == 63 || rule == 64)
		{
			return true;
		}
		return false;
	}

	public static bool ShowRpgHelpRelive(int raceType)
	{
		if (IsPveModel(raceType))
		{
			if (15001 == raceType || 15006 == raceType || 15007 == raceType || IsMultipleRpg(raceType))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static bool IsMultipleRpg(int raceType)
	{
		if (raceType >= 16000 && raceType < 17000)
		{
			return true;
		}
		if (IsRpgSpecailMode(raceType))
		{
			return true;
		}
		return false;
	}

	public static bool IsNeedBossWarning(int raceType)
	{
		if (raceType != 1001 && raceType != 1002 && raceType != 1005 && !IsGeneralPve(raceType))
		{
			return raceType == 1003;
		}
		return true;
	}

	public static bool IsSneakRule(int rule)
	{
		if (rule == 10031 || rule == 10034)
		{
			return true;
		}
		return false;
	}

	public static bool IsRpgProtectMode(int rule)
	{
		if (rule == 12005)
		{
			return false;
		}
		if (IsRpgShiLian(rule) || IsRpgWuJin(rule))
		{
			return true;
		}
		if ((uint)(rule - 10006) <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool IsCopyActivity(int raceType)
	{
		if (raceType >= 18601 && raceType <= 18699)
		{
			return true;
		}
		return false;
	}

	public static void GetFilterRuleSet(int ruleId, out HashSet<int> ruleSet)
	{
		ruleSet = new HashSet<int> { -1, ruleId };
		if (IsGeneralPve(ruleId) || IsRpg(ruleId))
		{
			ruleSet.Add(-3);
		}
		if (IsPve(ruleId))
		{
			ruleSet.Add(-2);
		}
		if (IsBioMode(ruleId))
		{
			ruleSet.Add(-4);
		}
		if (GetSuperModel(ruleId) != ruleId)
		{
			ruleSet.Add(GetSuperModel(ruleId));
		}
		if (IsDeathRule(ruleId))
		{
			ruleSet.Add(12);
		}
	}

	public static bool IsPlayBioStartSoundMode(int rule)
	{
		if (rule == 6 || rule == 33 || rule == 7 || rule == 14 || rule == 16 || rule == 17 || rule == 20 || rule == 28 || rule == 31 || rule == 69 || rule == 117 || rule == 118 || rule == 119 || rule == 122)
		{
			return true;
		}
		return false;
	}

	public static bool IsPersonlKillInfo(int rule)
	{
		if (30 == rule || 9 == rule || 5 == rule || IsBioMode(rule) || IsPveModel(rule) || 25 == rule || 34 == rule)
		{
			if (IsRpgPvp(rule))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsPveModel(int rule)
	{
		if (IsOldPve(rule) || IsGeneralPve(rule))
		{
			return true;
		}
		return false;
	}

	public static bool IsFlyingKnife(int rule)
	{
		return rule == 74;
	}

	public static bool IsCameraFrozenWhenDead(int rule)
	{
		if (IsPveModel(rule))
		{
			return false;
		}
		if (IsBlade(rule))
		{
			return false;
		}
		if (rule == 25 || rule == 12 || rule == 13 || rule == 23)
		{
			return false;
		}
		return true;
	}

	public static bool IsPitRule(BattleRoomContext battleRoom)
	{
		if (battleRoom.roomData.Data.RaceType == 100 && battleRoom.roomData.Data.FreeType.Equals("pit"))
		{
			return true;
		}
		return false;
	}

	public static bool IsRuleCanSwitchObserveMode(int rule)
	{
		if (rule == 115)
		{
			return false;
		}
		if (IsBioMode(rule))
		{
			return false;
		}
		return true;
	}

	public static int GetDefaultObserveMode(int rule)
	{
		if (IsBioMode(rule))
		{
			return 2;
		}
		if (rule == 115)
		{
			return 2;
		}
		return 1;
	}

	public static int GetRealRaceType(BattleRoomContext battleRoom)
	{
		int result = 0;
		RoomData data = battleRoom.roomData.Data;
		if (data.RaceType == 100)
		{
			int num = data.FreeType.LastIndexOf("freeRpg_");
			result = ((num < 0) ? ReplaceRaceFreeType(battleRoom) : (int.Parse(data.FreeType.Substring(num + "freeRpg_".Length)) % 100000 + 10000));
		}
		return result;
	}

	private static int ReplaceRaceFreeType(BattleRoomContext battleRoom)
	{
		return battleRoom.roomData.Data.FreeType switch
		{
			"DeformedMen" => 115, 
			"UltimateChallenge" => 116, 
			"titForTat" => 111, 
			_ => 100, 
		};
	}

	public static bool IsCanSwitchThirdFirstMode(BattleRoomContext battleRoom)
	{
		if (battleRoom.roomData.Data.RaceType == 123)
		{
			return true;
		}
		return false;
	}

	public static bool MustThirdObserveMode(BattleRoomContext battleRoom)
	{
		int raceType = battleRoom.roomData.Data.RaceType;
		if (IsBioMode(raceType))
		{
			return true;
		}
		if (IsBigHeadModel(raceType))
		{
			return true;
		}
		return false;
	}

	public static bool AllowThirdObserveMode(BattleRoomContext battleRoom)
	{
		int realRaceType = GetRealRaceType(battleRoom);
		if (MustThirdObserveMode(battleRoom))
		{
			return true;
		}
		if (realRaceType == 115)
		{
			return true;
		}
		return false;
	}

	public static bool IsNewBio3Rule(int raceType)
	{
		if ((uint)(raceType - 117) <= 2u || raceType == 122)
		{
			return true;
		}
		return false;
	}

	public static bool IsBladeFightModel(int raceType)
	{
		if (raceType == 121)
		{
			return true;
		}
		return false;
	}

	public static bool EnableFreeMark(BattleRoomContext battleRoom)
	{
		if (IsUltimateChallenge())
		{
			return true;
		}
		return false;
	}

	public static bool IsTeamRace(int raceType)
	{
		switch (raceType)
		{
		case 18002:
		case 18501:
		case 18502:
		case 18503:
			return true;
		case 18504:
		case 18505:
		case 18506:
		case 18507:
		case 18508:
		case 18509:
		case 18510:
		case 18511:
		case 18512:
		case 18513:
		case 18514:
		case 18515:
		case 18516:
		case 18517:
		case 18518:
		case 18519:
		case 18520:
		case 18521:
		case 18522:
		case 18523:
		case 18524:
		case 18525:
		case 18526:
		case 18527:
		case 18528:
		case 18529:
		case 18530:
		case 18531:
		case 18532:
		case 18533:
		case 18534:
		case 18535:
		case 18536:
		case 18537:
		case 18538:
		case 18539:
		case 18540:
		case 18541:
		case 18542:
		case 18543:
		case 18544:
		case 18545:
		case 18546:
		case 18547:
		case 18548:
		case 18549:
		case 18550:
		case 18551:
		case 18552:
		case 18553:
		case 18554:
		case 18555:
		case 18556:
		case 18557:
		case 18558:
		case 18559:
		case 18560:
		case 18561:
		case 18562:
		case 18563:
		case 18564:
		case 18565:
		case 18566:
		case 18567:
		case 18568:
		case 18569:
		case 18570:
		case 18571:
		case 18572:
		case 18573:
		case 18574:
		case 18575:
		case 18576:
		case 18577:
		case 18578:
		case 18579:
		case 18580:
		case 18581:
		case 18582:
		case 18583:
		case 18584:
		case 18585:
		case 18586:
		case 18587:
		case 18588:
		case 18589:
		case 18590:
		case 18591:
		case 18592:
		case 18593:
		case 18594:
		case 18595:
		case 18596:
		case 18597:
		case 18598:
		case 18599:
			return true;
		default:
			return false;
		}
	}

	public static bool isCyberSpace(int raceType)
	{
		if (raceType >= 300000)
		{
			return raceType < 399999;
		}
		return false;
	}

	public static bool isHuntTre(int raceType)
	{
		if (raceType >= 121100)
		{
			return raceType < 122100;
		}
		return false;
	}

	public static bool IsNeedOpenAce(int raceType)
	{
		if (raceType != 3)
		{
			return raceType == 2;
		}
		return true;
	}

	public static bool isPersonMode(int raceType)
	{
		return raceType == 5;
	}

	public static bool isSpecialMode(int raceType)
	{
		return raceType == 4;
	}

	public static bool hasReportHandle()
	{
		if (IsLadderTT())
		{
			return true;
		}
		if (_reportState != -1)
		{
			return _reportState == 1;
		}
		_reportState = 0;
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		string gameStartJsonAttribute = TplManager.Instance.GameBootConfig.GameStartJsonAttribute;
		if (gameStartJsonAttribute != null && JsonDecoder.Decode(gameStartJsonAttribute).ObjectValue.TryGetValue("pluginReportRuleList", out var value))
		{
			List<JObject> arrayValue = value.ArrayValue;
			for (int i = 0; i < arrayValue.Count; i++)
			{
				if (!string.IsNullOrEmpty(arrayValue[i].StringValue) && arrayValue[i].StringValue == raceType.ToString())
				{
					_reportState = 1;
					break;
				}
			}
		}
		return _reportState == 1;
	}

	public static bool isFogMode(int raceType)
	{
		if (raceType != 18031)
		{
			return raceType == 18030;
		}
		return true;
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgMouseYear;
using Assets.Sources.Ui.Model.RpgMystery;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgMode : AbstractMode
{
	public RpgMode(Contexts contexts)
		: base(contexts)
	{
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		if (raceType == 17003)
		{
			AddPlaybackSystem(new RPGNanjiMarkModel());
		}
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		if (raceType != 17000 && raceType != 17002 && raceType != 17003 && raceType != 15007 && raceType != 1100)
		{
			AddPlaybackSystem(new PveTeamScoreModel());
		}
		if (raceType != 17000 && raceType != 17002 && raceType != 17003 && raceType != 15007 && raceType != 18017)
		{
			AddPlaybackSystem(new PveFirstWinModel());
		}
		if (raceType == 18006)
		{
			AddPlaybackSystem(new RpgChooseWeaponModel());
			AddPlaybackSystem(new RpgMouseYearCDModel());
			AddPlaybackSystem(new RpgMouseYearBuffersModel());
			AddPlaybackSystem(new RpgMouseYearCarProgressModel());
			AddPlaybackSystem(new RpgMouseYearChooseDropWeaponModel());
			AddPlaybackSystem(new RpgMouseYearAllKillInfoModel());
			AddPlaybackSystem(new RpgMouseYearEnemgyModel());
			AddPlaybackSystem(new RpgMouseYearTipsModel());
			AddPlaybackSystem(new RpgMouseYearSkillTreeModel());
		}
		if (raceType == 18106)
		{
			AddPlaybackSystem(new RpgMouseYearCDModel());
			AddPlaybackSystem(new RpgMouseYearBuffersModel());
			AddPlaybackSystem(new RpgMouseYearCarProgressModel());
			AddPlaybackSystem(new RpgMouseYearAllKillInfoModel());
			AddPlaybackSystem(new RpgMouseYearEnemgyModel());
			AddPlaybackSystem(new RpgMouseYearTipsModel());
			AddPlaybackSystem(new RpgMouseYearBuffTreeModel());
		}
		if (raceType == 18015)
		{
			AddPlaybackSystem(new RpgMouseYearBuffersModel());
			AddPlaybackSystem(new RpgMouseYearCDModel());
			AddPlaybackSystem(new RpgMouseYearAllKillInfoModel());
			RemovePlayerbackSystem<RadarMapModel>();
			RemovePlayerbackSystem<MiniMapModel>();
			RemovePlayerbackSystem<PveAllKillInfoModel>();
		}
		if (raceType == 17000)
		{
			AddPlaybackSystem(new LightFireStatusModel());
		}
		AddPlaybackSystem(new WeaponStateModel());
		if (raceType != 17003)
		{
			AddPlaybackSystem(new RpgSkillStateModel());
		}
		AddPlaybackSystem(new RoleSkill1018ProgressModel());
		AddPlaybackSystem(new RpgBossHpModel());
		AddPlaybackSystem(new RpgEliteHpModel());
		if (raceType != 15007 && raceType != 1100)
		{
			AddPlaybackSystem(new RpgBotHpModel());
		}
		AddPlaybackSystem(new PveHomeHpModel());
		AddPlaybackSystem(new RpgPlayerStateModel());
		AddPlaybackSystem(new RpgCommonplayerhonoraryModel());
		if (raceType != 15007)
		{
			AddPlaybackSystem(new PlayerRebornModel());
		}
		AddPlaybackSystem(new StrokeAnalysisModel());
		if (raceType != 15007)
		{
			AddPlaybackSystem(new CommonGameOverModel());
		}
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new PveBotHitModel());
		AddPlaybackSystem(new RpgStateProgressModel());
		if (raceType != 18017)
		{
			AddPlaybackSystem(new RpgBossWarningModel());
		}
		AddPlaybackSystem(new RpgDialogueModel());
		AddPlaybackSystem(new KillMessageModel());
		if (RuleUtilty.IsRpgWuJin(raceType))
		{
			AddPlaybackSystem(new RpgTaskTargetModel());
			AddPlaybackSystem(new RpgEndlessStatisticsModel());
		}
		if (raceType == 18000)
		{
			AddPlaybackSystem(new RpgExploreTargetModel());
		}
		if (!RuleUtilty.IsRpgWuJin(raceType) && raceType != 17000 && raceType != 17002 && raceType != 17003 && !RuleUtilty.IsTeamRace(raceType) && raceType != 18009 && raceType != 15007)
		{
			AddPlaybackSystem(new PveScoreRankModel());
		}
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new RpgShieldBrokenModel());
		AddPlaybackSystem(new RpgShieldRecoveryModel());
		AddPlaybackSystem(new PveMaskModel());
		AddPlaybackSystem(new RpgAngerFireScarModel());
		AddPlaybackSystem(new RpgFrameEffectModel());
		AddPlaybackSystem(new RpgRuoDianHpModel());
		AddPlaybackSystem(new AchievementModel());
		AddPlaybackSystem(new RpgXpSkillModel());
		AddPlaybackSystem(new RpgDragonModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
		if (raceType != 17000 && raceType != 17002 && raceType != 17003 && raceType != 18006 && raceType != 18106 && raceType != 15007)
		{
			AddPlaybackSystem(new RpgTableTaskModel());
		}
		if (raceType != 17000 && raceType != 17002 && raceType != 17003)
		{
			AddPlaybackSystem(new RpgMessageModel());
		}
		if (raceType != 17000 && raceType != 17002 && raceType != 17003 && raceType != 18006 && raceType != 18015 && raceType != 18106 && raceType != 15007)
		{
			AddPlaybackSystem(new PveAllKillInfoModel());
		}
		AddPlaybackSystem(new PlayerBufferModel());
	}
}

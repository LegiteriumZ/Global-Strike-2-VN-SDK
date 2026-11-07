using Assets.Sources.Constant;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Rpg6005;
using Assets.Sources.Ui.Model.RpgRescue;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgRescueMode : AbstractMode
{
	public RpgRescueMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PveTeamScoreModel());
		AddPlaybackSystem(new PveFirstWinModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new RpgSkillStateModel());
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new RpgBossHpModel());
		AddPlaybackSystem(new RpgEliteHpModel());
		AddPlaybackSystem(new RpgBotHpModel());
		AddPlaybackSystem(new PveHomeHpModel());
		AddPlaybackSystem(new RpgPlayerStateModel());
		AddPlaybackSystem(new CommonPlayerHonoraryModel());
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new CommonGameOverModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new RpgTableTaskModel());
		AddPlaybackSystem(new PveBotHitModel());
		AddPlaybackSystem(new RpgStateProgressModel());
		AddPlaybackSystem(new RpgBossWarningModel());
		AddPlaybackSystem(new RpgDialogueModel());
		AddPlaybackSystem(new KillMessageModel());
		if (RuleUtilty.IsRpgWuJin(contexts.battleRoom.roomData.Data.RaceType))
		{
			AddPlaybackSystem(new RpgTaskTargetModel());
			AddPlaybackSystem(new RpgEndlessStatisticsModel());
		}
		else
		{
			AddPlaybackSystem(new RpgRescueScoreRankModel());
		}
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new RpgMessageModel());
		AddPlaybackSystem(new RpgShieldBrokenModel());
		AddPlaybackSystem(new RpgShieldRecoveryModel());
		AddPlaybackSystem(new PveMaskModel());
		AddPlaybackSystem(new RpgAngerFireScarModel());
		AddPlaybackSystem(new RpgFrameEffectModel());
		AddPlaybackSystem(new RpgRuoDianHpModel());
		AddPlaybackSystem(new AchievementModel());
		AddPlaybackSystem(new RpgXpSkillModel());
		AddPlaybackSystem(new RpgDragonModel());
		AddPlaybackSystem(new RpgRescueAllKillInfoModel());
		if (contexts.battleRoom.roomData.Data.RaceType == 16005)
		{
			AddPlaybackSystem(new Rpg6005XuliModel());
			AddPlaybackSystem(new Rpg6005jianModel());
			AddPlaybackSystem(new Rpg6005dunModel());
			AddPlaybackSystem(new Rpg6005LeiyinModel());
		}
	}
}

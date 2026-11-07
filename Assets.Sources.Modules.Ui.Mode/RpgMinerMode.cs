using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgGroup;

namespace Assets.Sources.Modules.Ui.Mode;

internal class RpgMinerMode : AbstractMode
{
	public RpgMinerMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new TeamScoreModel());
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
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new PveBotHitModel());
		AddPlaybackSystem(new RpgStateProgressModel());
		AddPlaybackSystem(new KillMessageModel());
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
		AddPlaybackSystem(new WaitPlayerModel());
		AddPlaybackSystem(new RpgGroupWaitPlayerModel());
		AddPlaybackSystem(new RpgGroupIndividualInfoModel());
		AddPlaybackSystem(new PlayerBufferModel());
	}
}

using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Rpg6005;
using Assets.Sources.Ui.Model.RpgRescue;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class Rpg_6005Mode : BaseUiMode
{
	public Rpg_6005Mode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem<AceReportModel>();
		AddPlaybackSystem<MenuModel>();
		AddPlaybackSystem<ReportModel>();
		AddPlaybackSystem<ReportAlertModel>();
		AddPlaybackSystem<HowToPlayModel>();
		AddPlaybackSystem<CommonMessageModel>();
		AddPlaybackSystem<CommonCrossModel>();
		AddPlaybackSystem<SniperCrossModel>();
		AddPlaybackSystem<HitCrossModel>();
		AddPlaybackSystem<AntiAddictionModel>();
		AddPlaybackSystem<ChattingBigHornModel>();
		AddPlaybackSystem<ChattingLiveModel>();
		AddPlaybackSystem<ChatPanelModel>();
		AddPlaybackSystem<CommonTacticsSoundModel>();
		AddPlaybackSystem<SkillProgressModel>();
		AddPlaybackSystem<McGameSettingModel>();
		AddPlaybackSystem<MessageRemindModel>();
		AddPlaybackSystem<ReLinkModel>();
		AddPlaybackSystem<ObtainSuppliesModel>();
		AddPlaybackSystem<BeingHitModel>();
		AddPlaybackSystem<ObserverPlayerDataModel>();
		AddPlaybackSystem<ObserverAllKillInfoModel>();
		AddPlaybackSystem<ObserverShadowModel>();
		AddPlaybackSystem<FlashExplosionModel>();
		AddPlaybackSystem<ModeTitleModel>();
		AddPlaybackSystem<PlayerShowTimeModel>();
		AddPlaybackSystem<CrystalModel>();
		AddPlaybackSystem<KillStateModel>();
		AddPlaybackSystem<GunGloryModel>();
		AddPlaybackSystem<WeaponPendantDropModel>();
		AddPlaybackSystem<SceneBuffMessageModel>();
		AddPlaybackSystem<VoiceModel>();
		AddPlaybackSystem<VoiceShieldModel>();
		AddPlaybackSystem<PveTeamScoreModel>();
		AddPlaybackSystem<PveFirstWinModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<RpgSkillStateModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<RpgBossHpModel>();
		AddPlaybackSystem<RpgEliteHpModel>();
		AddPlaybackSystem<RpgBotHpModel>();
		AddPlaybackSystem<PveHomeHpModel>();
		AddPlaybackSystem<RpgPlayerStateModel>();
		AddPlaybackSystem<CommonPlayerHonoraryModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<CommonGameOverModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<RpgTableTaskModel>();
		AddPlaybackSystem<PveBotHitModel>();
		AddPlaybackSystem<RpgStateProgressModel>();
		AddPlaybackSystem<RpgBossWarningModel>();
		AddPlaybackSystem<RpgDialogueModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<RpgRescueScoreRankModel>();
		AddPlaybackSystem<RpgMessageModel>();
		AddPlaybackSystem<RpgShieldBrokenModel>();
		AddPlaybackSystem<RpgShieldRecoveryModel>();
		AddPlaybackSystem<PveMaskModel>();
		AddPlaybackSystem<RpgAngerFireScarModel>();
		AddPlaybackSystem<RpgFrameEffectModel>();
		AddPlaybackSystem<RpgRuoDianHpModel>();
		AddPlaybackSystem<AchievementModel>();
		AddPlaybackSystem<RpgXpSkillModel>();
		AddPlaybackSystem<RpgDragonModel>();
		AddPlaybackSystem<RpgRescueAllKillInfoModel>();
		AddPlaybackSystem<Rpg6005XuliModel>();
		AddPlaybackSystem<Rpg6005jianModel>();
		AddPlaybackSystem<Rpg6005dunModel>();
		AddPlaybackSystem<Rpg6005LeiyinModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 16005;
	}
}

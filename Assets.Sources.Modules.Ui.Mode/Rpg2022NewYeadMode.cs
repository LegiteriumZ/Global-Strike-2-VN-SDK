using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Rpg2022newyeadMode;
using Assets.Sources.Ui.Model.RpgArmament;
using Assets.Sources.Ui.Model.RpgGroup;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.Mode;

public class Rpg2022NewYeadMode : BaseUiMode
{
	public Rpg2022NewYeadMode(Contexts contexts)
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
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<RpgSkillStateModel>();
		AddPlaybackSystem<RoleSkill1018ProgressModel>();
		AddPlaybackSystem<RpgBossHpModel>();
		AddPlaybackSystem<RpgEliteHpModel>();
		AddPlaybackSystem<PveHomeHpModel>();
		AddPlaybackSystem<RpgPlayerStateModel>();
		AddPlaybackSystem<RpgCommonplayerhonoraryModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<CommonGameOverModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<PveBotHitModel>();
		AddPlaybackSystem<RpgBotHpModel>();
		AddPlaybackSystem<RpgStateProgressModel>();
		AddPlaybackSystem<RpgDialogueModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<RpgShieldBrokenModel>();
		AddPlaybackSystem<RpgShieldRecoveryModel>();
		AddPlaybackSystem<PveMaskModel>();
		AddPlaybackSystem<RpgAngerFireScarModel>();
		AddPlaybackSystem<RpgFrameEffectModel>();
		AddPlaybackSystem<RpgRuoDianHpModel>();
		AddPlaybackSystem<AchievementModel>();
		AddPlaybackSystem<RpgXpSkillModel>();
		AddPlaybackSystem<RpgDragonModel>();
		AddPlaybackSystem<RpgExplodeoilModel>();
		AddPlaybackSystem<RpgMessageModel>();
		AddPlaybackSystem<PlayerBufferModel>();
		AddPlaybackSystem<RpgArmamentIndividualInfoModel>();
		AddPlaybackSystem<RpgArmamentTeamScoreModel>();
		AddPlaybackSystem<RpgGroupWaitPlayerModel>();
		AddPlaybackSystem<RpgArmamentPickInfoModel>();
		AddPlaybackSystem<Rpg2022NewYeadgLeftModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		if (racetype != 18030)
		{
			return racetype == 18031;
		}
		return true;
	}
}

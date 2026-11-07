using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Pve;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.RpgCraze;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class CRAZE_RPGMode : BaseUiMode
{
	public CRAZE_RPGMode(Contexts contexts)
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
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<CommonGameOverModel>();
		AddPlaybackSystem<CommonKillBroadModel>();
		AddPlaybackSystem<PvetdmessageModel>();
		AddPlaybackSystem<PveBotHitModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<PveplayerstateModel>();
		AddPlaybackSystem<PveTeamScoreModel>();
		AddPlaybackSystem<PveskillstateModel>();
		AddPlaybackSystem<PveTDGetMoneyExpModel>();
		AddPlaybackSystem<PvetdbothpModel>();
		AddPlaybackSystem<PveBossHpModel>();
		AddPlaybackSystem<PveHomeHpModel>();
		AddPlaybackSystem<PveTDChemicalSerumModel>();
		AddPlaybackSystem<PvetdbuyweaponModel>();
		AddPlaybackSystem<PveFirstWinModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<AchievementModel>();
		AddPlaybackSystem<PlayerScoreInfoModel>();
		AddPlaybackSystem<CommonPlayerHonoraryModel>();
		AddPlaybackSystem<CrazeLearnTabModel>();
		AddPlaybackSystem<CrazeSkillChooseModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 1100;
	}
}

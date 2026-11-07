using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.GoldExplode;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class ExplodeGoldMode : BaseUiMode
{
	public ExplodeGoldMode(Contexts contexts)
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
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<PlayerStateModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<CommonPlayerHonoraryModel>();
		AddPlaybackSystem<PlayerScoreInfoModel>();
		AddPlaybackSystem<CommonKillBroadModel>();
		AddPlaybackSystem<BlastLikesModel>();
		AddPlaybackSystem<BlastByLikesModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<BlastModelTeamScoreModel>();
		AddPlaybackSystem<BlastModelStartGameModel>();
		AddPlaybackSystem<C4StateProgressBarModel>();
		AddPlaybackSystem<BlastModelC4Model>();
		AddPlaybackSystem<BlastMessageModel>();
		AddPlaybackSystem<BlastGameOverModel>();
		AddPlaybackSystem<GoldExplodeIndividualScoreInfoModel>();
		AddPlaybackSystem<GoldExplodeIndividualMoneyModel>();
		AddPlaybackSystem<GoldExplodeMoneyModel>();
		AddPlaybackSystem<GoldExplodeBuyWeaponModel>();
		AddPlaybackSystem<GoldExplodeInBuyAreaModel>();
		AddPlaybackSystem<GoldExplodeMessageModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<BlastTacticsSoundModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 27;
	}
}

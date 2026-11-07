using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.DeathMatch;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.WeaponMaster;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class WeaponMasterMode : BaseUiMode
{
	public WeaponMasterMode(Contexts contexts)
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
		AddPlaybackSystem<DeathMatchBestKillModel>();
		AddPlaybackSystem<DeathMatchIndividualScoreInfoModel>();
		AddPlaybackSystem<DeathMatchStrikeIndividualScoreInfoModel>();
		AddPlaybackSystem<DeathMatchReliveProgressModel>();
		AddPlaybackSystem<DeathMatchMessageModel>();
		AddPlaybackSystem<WeaponMasterSelectWeaponTypeModel>();
		AddPlaybackSystem<WeaponMasterSelectWeaponModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 64;
	}
}

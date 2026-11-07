using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.BigHead;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class BIG_HEAD_KNIFE2Mode : BaseUiMode
{
	public BIG_HEAD_KNIFE2Mode(Contexts contexts)
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
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<TeamScoreModel>();
		AddPlaybackSystem<BigHeadIndividualScoreInfoModel>();
		AddPlaybackSystem<BigHeadStrikeIndividualScoreInfoModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<PlayerStateModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<BigHeadHonoraryModel>();
		AddPlaybackSystem<PlayerScoreInfoModel>();
		AddPlaybackSystem<CommonKillBroadModel>();
		AddPlaybackSystem<CommonGameOverModel>();
		AddPlaybackSystem<BigHeadProgressModel>();
		AddPlaybackSystem<BigHeadMessageModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<AddHpCrossModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 126;
	}
}

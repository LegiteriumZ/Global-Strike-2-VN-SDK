using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.HulaoguanModel;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgGroup;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class HuLaoGuanNewYearMode : BaseUiMode
{
	public HuLaoGuanNewYearMode(Contexts contexts)
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
		AddPlaybackSystem<RpgGroupWaitPlayerModel>();
		AddPlaybackSystem<MyPlayerStateModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<TeamScoreModel>();
		AddPlaybackSystem<RpgStateProgressModel>();
		AddPlaybackSystem<PveAllKillInfoModel>();
		AddPlaybackSystem<RpgBossHpModel>();
		AddPlaybackSystem<HuLaoGuanNewYearLeftModel>();
		AddPlaybackSystem<HuLaoGuanNewYearDownModel>();
		AddPlaybackSystem<HuLaoGuanNewYearProfessionModel>();
		AddPlaybackSystem<HuLaoGuanNewYearRightModel>();
		AddPlaybackSystem<HuLaoGuanNewYearMessageModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 26;
	}
}

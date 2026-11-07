using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical2;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class Biochemical2Mode : BaseUiMode
{
	public Biochemical2Mode(Contexts contexts)
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
		AddPlaybackSystem<BiochemicalHonoraryModel>();
		AddPlaybackSystem<Biochemical2StartGameModel>();
		AddPlaybackSystem<BiochemicalKillBroadModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<BiochemicalTeamScoreModel>();
		AddPlaybackSystem<BiochemicalHeroKillDamageModel>();
		AddPlaybackSystem<BiochemicalDamageScoreModel>();
		AddPlaybackSystem<BiochemicalSkillIconModel>();
		AddPlaybackSystem<BiochemicalSkillProgressBarModel>();
		AddPlaybackSystem<BiochemicalDecisiveBattleModel>();
		AddPlaybackSystem<BiochemicalSelectHeroWeaponModel>();
		AddPlaybackSystem<BiochemicalSelectVariantModel>();
		AddPlaybackSystem<BiochemicalCarboxylicModel>();
		AddPlaybackSystem<BiochemicalSerumModel>();
		AddPlaybackSystem<Biochemical2IndividualScoreInfoModel>();
		AddPlaybackSystem<BiochemicalGameOverModel>();
		AddPlaybackSystem<BiochemicalMessageModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<WaitPlayerModel>();
		AddPlaybackSystem<Biochemical2SkillBoardModel>();
		AddPlaybackSystem<Biochemical2SkillBarModel>();
		AddPlaybackSystem<Biochemical2SkillMessageModel>();
		AddPlaybackSystem<Biochemical3SelectVariantModel>();
		AddPlaybackSystem<RpgExplodeoilModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 33;
	}
}

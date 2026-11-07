using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.BioEvolution;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class BIOCHEMICAL_3Mode : BaseUiMode
{
	public BIOCHEMICAL_3Mode(Contexts contexts)
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
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<BiochemicalHonoraryModel>();
		AddPlaybackSystem<BiochemicalStartGameModel>();
		AddPlaybackSystem<BiochemicalKillBroadModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<BiochemicalHeroKillDamageModel>();
		AddPlaybackSystem<BiochemicalDamageScoreModel>();
		AddPlaybackSystem<BiochemicalSkillProgressBarModel>();
		AddPlaybackSystem<BiochemicalDecisiveBattleModel>();
		AddPlaybackSystem<BiochemicalSelectHeroWeaponModel>();
		AddPlaybackSystem<BiochemicalCarboxylicModel>();
		AddPlaybackSystem<BiochemicalIndividualScoreInfoModel>();
		AddPlaybackSystem<BiochemicalGameOverModel>();
		AddPlaybackSystem<BiochemicalMessageModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<BioEvolutionSelectVariantModel>();
		AddPlaybackSystem<Biochemical3TeamScoreModel>();
		AddPlaybackSystem<Biochemical3VariantGrowUpModel>();
		AddPlaybackSystem<Biochemical3VariantPlayerStateModel>();
		AddPlaybackSystem<Biochemical3HumanityPlayerStateModel>();
		AddPlaybackSystem<Biochemical3ItemModel>();
		AddPlaybackSystem<Biochemical3SkillModel>();
		AddPlaybackSystem<Biochemical3HumanityGrowUpModel>();
		AddPlaybackSystem<Biochemical3WeaponStateModel>();
		AddPlaybackSystem<RpgExplodeoilModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 117;
	}
}

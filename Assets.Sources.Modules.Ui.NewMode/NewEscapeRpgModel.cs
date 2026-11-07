using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.NewescapeModel;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class NewEscapeRpgModel : BaseUiMode
{
	public NewEscapeRpgModel(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem<NewEscapeLeftModel>();
		AddPlaybackSystem<NewEscapeTopModel>();
		AddPlaybackSystem<NewEscapeTipsModel>();
		AddPlaybackSystem<NewEscapeTimeModel>();
		AddPlaybackSystem<NewEscapeWaitingModel>();
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
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<BiochemicalHonoraryModel>();
		AddPlaybackSystem<BiochemicalNewVariantsGrowUpModel>();
		AddPlaybackSystem<BiochemicalKillBroadModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<BiochemicalTeamScoreModel>();
		AddPlaybackSystem<BiochemicalHeroKillDamageModel>();
		AddPlaybackSystem<BiochemicalDamageScoreModel>();
		AddPlaybackSystem<BiochemicalSkillProgressBarModel>();
		AddPlaybackSystem<BiochemicalDecisiveBattleModel>();
		AddPlaybackSystem<BiochemicalSelectHeroWeaponModel>();
		AddPlaybackSystem<BiochemicalSelectVariantModel>();
		AddPlaybackSystem<BiochemicalCarboxylicModel>();
		AddPlaybackSystem<BiochemicalSerumModel>();
		AddPlaybackSystem<BiochemicalIndividualScoreInfoModel>();
		AddPlaybackSystem<BiochemicalGameOverModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<Biochemical3SelectVariantModel>();
		AddPlaybackSystem<NewBiochemicalSkillIconModel>();
		AddPlaybackSystem<NewBiochemicalMessageModel>();
		AddPlaybackSystem<RpgSkillStateModel>();
		AddPlaybackSystem<RpgPlayerStateModel>();
		AddPlaybackSystem<BlastTacticsSoundModel>();
		AddPlaybackSystem<RpgExplodeoilModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		if (racetype != 132)
		{
			return racetype == 133;
		}
		return true;
	}
}

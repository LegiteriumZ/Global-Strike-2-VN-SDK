using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.BioChemical_Z;
using Assets.Sources.Ui.Model.BioEvolution;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical2;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.FinalBio;
using Assets.Sources.Ui.Model.NewescapeModel;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class BIOCHEMICAL_ZMode : BaseUiMode
{
	public BIOCHEMICAL_ZMode(Contexts contexts)
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
		AddPlaybackSystem<PlayerShowTimeModel>();
		AddPlaybackSystem<CrystalModel>();
		AddPlaybackSystem<KillStateModel>();
		AddPlaybackSystem<GunGloryModel>();
		AddPlaybackSystem<WeaponPendantDropModel>();
		AddPlaybackSystem<SceneBuffMessageModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<BiochemicalNewVariantsGrowUpModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<BiochemicalHeroKillDamageModel>();
		AddPlaybackSystem<BiochemicalSelectHeroWeaponModel>();
		AddPlaybackSystem<BiochemicalCarboxylicModel>();
		AddPlaybackSystem<BiochemicalGameOverModel>();
		AddPlaybackSystem<BiochemicalKillBroadModel>();
		AddPlaybackSystem<FinalBioChangeHumanityModel>();
		AddPlaybackSystem<FinalBioQueenWeaponModel>();
		AddPlaybackSystem<BestKillModel>();
		AddPlaybackSystem<BioEvolutionSelectVariantModel>();
		AddPlaybackSystem<BioEvolutionShortcutKeyModel>();
		AddPlaybackSystem<Biochemical3ItemModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<BioEvolutionVariantGrowUpModel>();
		AddPlaybackSystem<BioEvolutionHuManGrowUpModel>();
		AddPlaybackSystem<BioEvolutionPickUpModel>();
		AddPlaybackSystem<Biochemical2IndividualScoreInfoModel>();
		AddPlaybackSystem<RpgExplodeoilModel>();
		AddPlaybackSystem<BioChemical_Z_Shop_WeaponModel>();
		AddPlaybackSystem<BioChemical_Z_Shop_SkllModel>();
		AddPlaybackSystem<BioZSkillModel>();
		AddPlaybackSystem<BioChemical_ZBtnListModel>();
		AddPlaybackSystem<BioChemical_ZExpUIModel>();
		AddPlaybackSystem<BioChemical_ZGoldModel>();
		AddPlaybackSystem<BioChemical_ZLevelUpEffectModel>();
		AddPlaybackSystem<BioChemical_ZPlayerDesModel>();
		AddPlaybackSystem<BioChemical_ZPlayerInfoModel>();
		AddPlaybackSystem<BioChemical_ZPlayerSelectModel>();
		AddPlaybackSystem<BioChemical_ZSkillDesModel>();
		AddPlaybackSystem<BioChemical_ZMsglDesModel>();
		AddPlaybackSystem<BioChemical_ZUltimateTimerDesModel>();
		AddPlaybackSystem<BioChemical_ZStartDesModel>();
		AddPlaybackSystem<BioChemical_ZEndDesModel>();
		AddPlaybackSystem<NewEscapeLeftModel>();
		AddPlaybackSystem<Bio_ZchemicalMessageModel>();
		AddPlaybackSystem<BlastTacticsSoundModel>();
		AddPlaybackSystem<WaitPlayerModel>();
		AddPlaybackSystem<BioChemical_ZTeamScoreModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 134;
	}
}

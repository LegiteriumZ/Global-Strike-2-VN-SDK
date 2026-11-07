using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class RPG_TEAM_RACEMode : BaseUiMode
{
	public RPG_TEAM_RACEMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem<MenuModel>();
		AddPlaybackSystem<HowToPlayModel>();
		AddPlaybackSystem<CommonCrossModel>();
		AddPlaybackSystem<SniperCrossModel>();
		AddPlaybackSystem<HitCrossModel>();
		AddPlaybackSystem<ChatPanelModel>();
		AddPlaybackSystem<ChattingBigHornModel>();
		AddPlaybackSystem<ChattingLiveModel>();
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
		AddPlaybackSystem<CommonTacticsSoundModel>();
		AddPlaybackSystem<PveTeamScoreModel>();
		AddPlaybackSystem<PveFirstWinModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<RpgSkillStateModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<RpgBossHpModel>();
		AddPlaybackSystem<RpgEliteHpModel>();
		AddPlaybackSystem<RpgBotHpModel>();
		AddPlaybackSystem<PveHomeHpModel>();
		AddPlaybackSystem<RpgPlayerStateModel>();
		AddPlaybackSystem<CommonPlayerHonoraryModel>();
		AddPlaybackSystem<PlayerRebornModel>();
		AddPlaybackSystem<StrokeAnalysisModel>();
		AddPlaybackSystem<CommonGameOverModel>();
		AddPlaybackSystem<PlayerBagModel>();
		AddPlaybackSystem<RpgTableTaskModel>();
		AddPlaybackSystem<PveBotHitModel>();
		AddPlaybackSystem<RpgStateProgressModel>();
		AddPlaybackSystem<RpgBossWarningModel>();
		AddPlaybackSystem<RpgDialogueModel>();
		AddPlaybackSystem<KillMessageModel>();
		AddPlaybackSystem<PveScoreRankModel>();
		AddPlaybackSystem<CommonMessageModel>();
		AddPlaybackSystem<RpgMessageModel>();
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
		AddPlaybackSystem<PveAllKillInfoModel>();
		AddPlaybackSystem<PlayerBufferModel>();
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 18002;
	}
}

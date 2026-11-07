using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;

namespace Assets.Sources.Modules.Ui.NewMode;

public class FreeMode : BaseUiMode
{
	public FreeMode(Contexts contexts)
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
		AddPlaybackSystem<ObserverShadowModel>();
		AddPlaybackSystem<FlashExplosionModel>();
		AddPlaybackSystem<PlayerShowTimeModel>();
		AddPlaybackSystem<CrystalModel>();
		AddPlaybackSystem<KillStateModel>();
		AddPlaybackSystem<GunGloryModel>();
		AddPlaybackSystem<WeaponPendantDropModel>();
		AddPlaybackSystem<SceneBuffMessageModel>();
		AddPlaybackSystem<RadarMapModel>();
		AddPlaybackSystem<MiniMapModel>();
		AddPlaybackSystem<WeaponStateModel>();
		AddPlaybackSystem<CommonKillBroadModel>();
		if (!Contexts.battleRoom.roomData.Data.FreeType.Equals("titForTat"))
		{
			AddPlaybackSystem<ObserverPlayerDataModel>();
		}
		if (!Contexts.battleRoom.roomData.Data.FreeType.Equals("titForTat"))
		{
			AddPlaybackSystem<ObserverAllKillInfoModel>();
		}
		if (!Contexts.battleRoom.roomData.Data.FreeType.Equals("UltimateChallenge"))
		{
			AddPlaybackSystem<KillMessageModel>();
		}
		switch (contexts.battleRoom.roomData.Data.FreeType)
		{
		case "bioPushcar":
			AddPlaybackSystem<BiochemicalSkillIconModel>();
			break;
		case "titForTat":
			AddPlaybackSystem<AchievementModel>();
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "narrowRoad":
			AddPlaybackSystem<PlayerBagModel>();
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "BulletStorm":
			AddPlaybackSystem<PlayerBagModel>();
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "pit":
			AddPlaybackSystem<PlayerBagModel>();
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "mechWarrior2":
			AddPlaybackSystem<PlayerBagModel>();
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "DeformedMen":
			AddPlaybackSystem<PlayerBagModel>();
			break;
		case "gunKingGroup":
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "gunKingPersonal":
			AddPlaybackSystem<PlayerScoreInfoModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		case "survive":
			AddPlaybackSystem<PlayerRebornModel>();
			AddPlaybackSystem<StrokeAnalysisModel>();
			break;
		}
	}

	protected override bool IsMatchMode(int racetype)
	{
		return racetype == 100;
	}
}

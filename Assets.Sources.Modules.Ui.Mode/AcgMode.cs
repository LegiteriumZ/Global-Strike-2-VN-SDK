using Assets.Sources.Ui.Model.AcgCommon;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.Mode;

public class AcgMode : AbstractMode
{
	public AcgMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		AddPlaybackSystem(new MenuModel());
		AddPlaybackSystem(new ReportModel());
		AddPlaybackSystem(new ReportAlertModel());
		AddPlaybackSystem(new HowToPlayModel());
		AddPlaybackSystem(new AceReportModel());
		AddPlaybackSystem(new McGameSettingModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new AntiAddictionModel());
		AddPlaybackSystem(new BeingHitModel());
		AddPlaybackSystem(new AcgPlayerStatusBoardModel());
		AddPlaybackSystem(new AcgWeaponStatusBoardModel());
		AddPlaybackSystem(new AcgEnemyStatusBoardModel());
		AddPlaybackSystem(new AcgTeamStatusBoardModel());
		AddPlaybackSystem(new AcgSkillBoardModel());
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new HitCrossModel());
		AddPlaybackSystem(new AcgPowerUpCoinBoardModel());
		AddPlaybackSystem(new AcgTradeWindowModel());
		AddPlaybackSystem(new AcgPowerUpWindowModel());
		AddPlaybackSystem(new AcgTabWindowModel());
		AddPlaybackSystem(new AcgInstructionWindowModel());
		AddPlaybackSystem(new AcgDamageRankBoardModel());
		AddPlaybackSystem(new AcgMessageBoardModel());
		AddPlaybackSystem(new AcgTextNotificationBoardModel());
		AddPlaybackSystem(new AcgQuestBoardModel());
		AddPlaybackSystem(new AcgStateProgressModel());
	}
}
